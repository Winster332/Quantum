using System;
using System.Reflection;
using Quantum.DOM;
using Quantum.Parser;
using Quantum.Platform.Core;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace Quantum.Platform
{
    public class QuantumBuilder
    {
        private DesktopWindow _window;
        private QuantumBuilderOptions _options;
        public SKColor ClearColor { get; set; }
        public Window Window { get; set; }

        private QuantumBuilder(QuantumBuilderOptions options)
        {
            _options = options;
            ClearColor = SKColors.AliceBlue;
        }

        public void Startup(string pathToFileIndex)
        {
            var loader = new HtmlLoader();
            Window = new Window();
            Window.Document = new Document();
            loader.LoadFromFile(pathToFileIndex, Assembly.GetEntryAssembly()).ForEach(root =>
            {
                Window.Document.ChildNodes.Add(root);
            });
            
            RunWindow();
        }
        
        public void Startup(Uri uri)
        {
            // TODO: Impl
            
            RunWindow();
        }

        private void RunWindow()
        {
            try
            {
                using (var window = new DesktopWindow(_options.Width, _options.Height))
                {
                    window.PaintSurface += WindowOnPaintSurface;
                    window.Run(_options.UpdatesPerSeconds, _options.FramesPerSeconds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WindowOnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            
            canvas.Clear(ClearColor);
        }

        public static QuantumBuilder Config(QuantumBuilderOptions options = null)
        {
            if (options == null)
            {
                options = new QuantumBuilderOptions();
            }

            var builder = new QuantumBuilder(options);

            return builder;
        }
    }
}
using System;
using System.Collections.Generic;
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
            Window = loader.LoadFromFile(pathToFileIndex, typeof(QuantumBuilder).Assembly);
            
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

        public class Position
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        private void WindowOnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            
            canvas.Clear(ClearColor);

            var pos = new Position
            {
                X = 350, 
                Y = 100
            };
            DrawElements(canvas, Window.Document.Body.Children, ref pos);
        }

        private void DrawElements(SKCanvas canvas, List<Element> elements, ref Position pos)
        {
            foreach (var element in elements)
            {
                if (element.NodeType == NodeType.TextNode)
                {
                    canvas.DrawText(element.TextContent, pos.X, pos.Y, new SKPaint
                    {
                        IsAntialias = true,
                        Color = SKColors.DarkOrange,
                        TextSize = 20
                    });
                }
                else
                {
                    canvas.DrawText(element.ToString(), pos.X, pos.Y, new SKPaint
                    {
                        IsAntialias = true,
                        Color = SKColors.Gray,
                        FakeBoldText = true,
                        TextSize = 20
                    });
                }

                pos.Y += 25;

                if (element.Children.Count != 0)
                {
                    pos.X += 25;
                    DrawElements(canvas, element.Children, ref pos);
                    pos.X -= 25;
                }

            }
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
using System;
using System.Collections.Generic;
using System.Reflection;
using Quantum.DOM;
using Quantum.Parser;
using Quantum.Platform.Core;
using Quantum.Platform.Graphics;
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
        private HtmlRenderer _renderer;

        private QuantumBuilder(QuantumBuilderOptions options)
        {
            _options = options;
            ClearColor = SKColors.AliceBlue;
        }

        public void Startup(string pathToFileIndex)
        {
            var loader = new HtmlLoader();
            Window = loader.LoadFromFile(pathToFileIndex, typeof(QuantumBuilder).Assembly);
//            Window.Document.Body
            
            _renderer = new HtmlRenderer(Window);
            
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
                X = 300, 
                Y = 100
            };
            DrawTreeElements(canvas, Window.Document.Body.Children, ref pos);
            
            _renderer.Render(canvas);
        }

        private void DrawTreeElements(SKCanvas canvas, List<Element> elements, ref Position pos)
        {
            foreach (var element in elements)
            {
                if (element.NodeType == NodeType.TextNode)
                {
                    canvas.DrawText(element.TextContent, pos.X, pos.Y, new SKPaint
                    {
                        IsAntialias = true,
                        Color = SKColors.DarkOrange,
                        TextSize = 15
                    });

                    var textPen = new SKPaint
                    {
                      IsAntialias = true,
                      Color = new SKColor(110, 102, 244),
                      TextSize = 15
                    };
                    var bounds = new SKRect();
                    textPen.MeasureText(element.TextContent, ref bounds);
                    canvas.DrawText(element.TextContent, pos.X, pos.Y, textPen);
                    canvas.DrawLine(bounds.Left + pos.X, bounds.Bottom + pos.Y, bounds.Right + pos.X, bounds.Bottom + pos.Y, new SKPaint
                    {
                      IsAntialias = true,
                      Style = SKPaintStyle.Stroke,
                      StrokeWidth = 1,
                      Color = textPen.Color
                    });
                }
                else
                {
                    canvas.DrawText(element.ToString(), pos.X, pos.Y, new SKPaint
                    {
                        IsAntialias = true,
                        Color = SKColors.Gray,
                        FakeBoldText = true,
                        TextSize = 15
                    });
                }

                var startLineX = pos.X;
                var startLineY = pos.Y;
                pos.Y += 25;

                if (element.Children.Count != 0)
                {
                    pos.X += 25;
                    DrawTreeElements(canvas, element.Children, ref pos);
                    pos.X -= 25;
                    
                    canvas.DrawLine(startLineX+5, startLineY+5, pos.X+5, pos.Y-15, new SKPaint
                    {
                      IsAntialias = true,
                      Style = SKPaintStyle.Stroke,
                      Color = SKColors.Cyan
                    });
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
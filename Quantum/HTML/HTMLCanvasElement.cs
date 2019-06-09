using System;
using Quantum.DOM;
using Quantum.Drawing;
using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLCanvasElement : HTMLElement
    {
        private RenderingContext _context;
        
        public float Width
        {
            get
            {
                if (float.TryParse(Attributes.GetNamedItem("width")?.Value, out var result))
                {
                    return result;
                }

                return 0;
            }
            set
            {
                Attributes.SetNamedItem(new Attr
                {
                    Name = "width",
                    Value = value.ToString()
                });
            }
        }
        
        public float Height
        {
            get
            {
                if (float.TryParse(Attributes.GetNamedItem("height")?.Value, out var result))
                {
                    return result;
                }

                return 0;
            }
            set
            {
                Attributes.SetNamedItem(new Attr
                {
                    Name = "height",
                    Value = value.ToString()
                });
            }
        }

        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
            if (_context != null)
            {
                _context.Canvas = canvas;
                _context.Render();
            }

            return false;
        }

        public RenderingContext GetContext(CanvasContextType type)
        {
            if (type == CanvasContextType.Use2D)
            {
                return new CanvasRenderingContext2D
                {
                    HTMLCanvas = this
                };
            }
            
            throw new NotSupportedException();
        }
    }
}
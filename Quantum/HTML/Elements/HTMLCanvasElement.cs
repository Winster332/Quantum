using System;
using Quantum.DOM;
using Quantum.Drawing;
using Quantum.Drawing.Canvas;
using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("canvas")]
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
                _context.sk = canvas;
                _context.Render();
            }

            return false;
        }

        public CanvasCaptureMediaStreamTrack CaptureStream()
        {
            return null;
        }

        public CanvasRenderingContext2D GetContext2d()
        {
          _context =
            new CanvasRenderingContext2D
            {
              HTMLCanvas = this
            };
          return _context as CanvasRenderingContext2D;
        }

        public Uri ToDataUri()
        {
            return null;
        }

        public Blob ToBlob()
        {
            return null;
        }

        public OffscreenCanvas TransferControlToOffscreen()
        {
            return null;
        }
        
        // TODO: need added events
    }
}
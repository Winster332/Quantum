using Quantum.HTML;
using SkiaSharp;

namespace Quantum.Drawing
{
    public abstract class RenderingContext
    {
        internal HTMLCanvasElement HTMLCanvas { get; set; }
        internal SKCanvas Canvas;
        internal abstract void Render();
    }
}
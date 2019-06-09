using Quantum.HTML;
using Quantum.HTML.Elements;
using Quantum.HTML.Elements.Scripting;
using SkiaSharp;

namespace Quantum.Drawing
{
    public abstract class RenderingContext
    {
        internal HTMLCanvasElement HTMLCanvas { get; set; }
        internal SKCanvas sk;
        internal abstract void Render();
    }
}
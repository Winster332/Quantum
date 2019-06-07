using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLUnknownElement : HTMLElement
    {
        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
            return false;
        }
    }
}

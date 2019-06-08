using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("head")]
    public class HTMLHeadElement : HTMLElement
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

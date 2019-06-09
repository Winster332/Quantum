using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("p")]
    public class HTMLParagraphElement : HTMLElement
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

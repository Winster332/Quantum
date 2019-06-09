using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("menu")]
    public class HTMLMenuElement : HTMLElement
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

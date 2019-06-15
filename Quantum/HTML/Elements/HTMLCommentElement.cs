using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("!--")]
    public class HTMLCommentElement : HTMLElement
    {
        internal override void Load()
        {
            Init("COMMENT");
        }

        internal override bool Draw(SKCanvas canvas)
        {
            return false;
        }
    }
}
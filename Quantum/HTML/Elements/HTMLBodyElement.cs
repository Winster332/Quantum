using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("body")]
    public class HTMLBodyElement : HTMLElement
    {
        // TODO: Added event handlers
        public HTMLBodyElement()
        {
            Init("BODY");
        }

        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
            DrawChildren(canvas);
            
            return false;
        }
    }
}

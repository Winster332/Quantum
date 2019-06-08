using SkiaSharp;

namespace Quantum.HTML
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
          return false;
        }
    }
}
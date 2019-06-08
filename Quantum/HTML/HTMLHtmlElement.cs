using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("html")]
    public class HTMLHtmlElement : HTMLElement
    {
        public HTMLHtmlElement()
        {
            Init("HTML");
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
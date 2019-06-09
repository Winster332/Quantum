using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("span")]
    public class HTMLSpanElement : HTMLElement
    {
        public HTMLSpanElement()
        {
            Init("SPAN");
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
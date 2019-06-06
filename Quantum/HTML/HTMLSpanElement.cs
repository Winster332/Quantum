using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLSpanElement : HTMLElement
    {
        public HTMLSpanElement()
        {
            Init("SPAN");
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
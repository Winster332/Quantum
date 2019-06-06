using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLBodyElement : HTMLElement
    {
        // TODO: Added event handlers
        public HTMLBodyElement()
        {
            Init("BODY");
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
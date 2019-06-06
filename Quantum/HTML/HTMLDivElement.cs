using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLDivElement : HTMLElement
    {
        public HTMLDivElement()
        {
            Init("DIV");
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
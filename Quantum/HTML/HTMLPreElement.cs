using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLPreElement : HTMLElement
    {
        public HTMLPreElement()
        {
            Init("PRE");
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
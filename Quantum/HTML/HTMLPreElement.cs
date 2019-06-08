using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("pre")]
    public class HTMLPreElement : HTMLElement
    {
        public HTMLPreElement()
        {
            Init("PRE");
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
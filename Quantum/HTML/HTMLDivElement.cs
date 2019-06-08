using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("div")]
    public class HTMLDivElement : HTMLElement
    {
        public HTMLDivElement()
        {
            Init("DIV");
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
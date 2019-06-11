using SkiaSharp;

namespace Quantum.HTML.Elements.Text
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
using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLTitleElement : HTMLElement
    {
        public string Text { get; set; }

        public HTMLTitleElement()
        {
            Init("TITLE");
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
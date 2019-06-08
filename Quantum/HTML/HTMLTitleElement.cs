using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("title")]
    public class HTMLTitleElement : HTMLElement
    {
        public string Text { get; set; }

        public HTMLTitleElement()
        {
            Init("TITLE");
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
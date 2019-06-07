using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLLabelElement : HTMLElement
    {
        public HTMLElement Control { get; set; }
        public HTMLFormElement Form { get; set; }
        public string HtmlFor { get; set; }

        public HTMLLabelElement()
        {
            Init("LABEL");
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
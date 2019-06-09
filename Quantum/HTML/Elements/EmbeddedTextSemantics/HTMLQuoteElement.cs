using SkiaSharp;

namespace Quantum.HTML.Elements.EmbeddedTextSemantics
{
    [HtmlName("quote")]
    public class HTMLQuoteElement : HTMLElement
    {
        public string Cite { get; set; }
        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
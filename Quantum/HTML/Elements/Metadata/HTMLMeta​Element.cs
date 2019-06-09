using SkiaSharp;

namespace Quantum.HTML.Elements.Metadata
{
    [HtmlName("meta")]
    public class HTMLMetaElement : HTMLElement
    {
        public string Content { get; set; }
        public string HttpEquiv { get; set; }
        public string Name { get; set; }

        public HTMLMetaElement()
        {
            IsNeedClose = false;
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
using System;
using Quantum.CSSOM;
using Quantum.Parser;
using SkiaSharp;

namespace Quantum.HTML
{
    [HtmlName("style")]
    public class HTMLStyleElement : HTMLElement, ILinkStyle
    {
        public string Media { get; set; }
        public string Type { get; set; }
        public bool Disabled { get; set; }
        public CSSStyleSheet Sheet { get; set; }

        public HTMLStyleElement()
        {
            Init("STYLE");
        }

        internal override void Load()
        {
            if (FirstChild == null) return;

            if (FirstChild is HTMLTextElement textElement)
            {
                var loader = new CssLoader();
                var text = textElement.TextContent;
                
                Sheet = loader.LoadSource(text);
                OwnerDocument.StyleSheets.Add(Sheet);
            }
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
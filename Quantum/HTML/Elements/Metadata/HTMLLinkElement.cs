using System;
using Quantum.CSSOM;
using Quantum.Parser;
using SkiaSharp;

namespace Quantum.HTML.Elements.Metadata
{
    [HtmlName("link")]
    public class HTMLLinkElement : HTMLElement, ILinkStyle
    {
        public CSSStyleSheet Sheet { get; set; }
        public string As { get; set; }
        public string CrossOrigin { get; set; }
        public bool Disabled { get; set; }
        public string Href { get; set; }
        public string Hreflang { get; set; }
        public string Media { get; set; }
        public string Rel { get; set; }
        public string Type { get; set; }

        public HTMLLinkElement()
        {
            Init("LINK");
            TextContent = null;
            IsNeedClose = false;
        }

        internal override void Load()
        {
            var href = GetAttribute("href");

            if (href == null) return;
            
            var pathToFile = href.Value.Replace("\"", "");

            var cssLoader = new CssLoader();
            Sheet = cssLoader.LoadFromFile(pathToFile);
            Sheet.Href = pathToFile;
            Sheet.OwnerNode = this;
                
            OwnerDocument.StyleSheets.Add(Sheet);
        }

        internal override bool Draw(SKCanvas canvas)
        {
          if (NodeValue == null)
          {
            return false;
          }

          
          return true;
        }
    }
}
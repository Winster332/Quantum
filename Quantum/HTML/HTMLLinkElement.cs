using Quantum.CSSOM;

namespace Quantum.HTML
{
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
        
    }
}
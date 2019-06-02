using Quantum.CSSOM;

namespace Quantum.HTML
{
    public class HTMLStyleElement : HTMLElement, ILinkStyle
    {
        public string Media { get; set; }
        public string Type { get; set; }
        public bool Disabled { get; set; }
        public CSSStyleSheet Sheet { get; set; }

        public HTMLStyleElement()
        {
        }
    }
}
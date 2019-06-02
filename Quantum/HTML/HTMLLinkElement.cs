using Quantum.CSSOM;

namespace Quantum.HTML
{
    public class HTMLLinkElement : HTMLElement, ILinkStyle
    {
        public CSSStyleSheet Sheet { get; set; }
    }
}
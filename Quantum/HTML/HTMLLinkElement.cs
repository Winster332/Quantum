using Quantum.DOM.CSS;

namespace Quantum.HTML
{
    public class HTMLLinkElement : HTMLElement, ILinkStyle
    {
        public CSSStyleSheet Sheet { get; set; }
    }
}
namespace Quantum.CSSOM
{
    public class CSSPageRule : CSSRule
    {
        public string SelectorText { get; set; }
        public CSSStyleDeclaration Style { get; set; }
    }
}
namespace Quantum.CSSOM
{
    public class CSSRule
    {
        public string CssText { get; set; }
        public CSSRule ParentRule { get; set; }
        public CSSStyleSheet ParentStyleSheet { get; set; }
        public CSSRuleType Type { get; set; }
    }
}
namespace Quantum.CSSOM.Rules
{
    public class CSSKeyframeRule : CSSRule
    {
        public string KeyText { get; set; }
        public CSSStyleDeclaration Style { get; set; }
    }
}
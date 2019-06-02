namespace Quantum.CSSOM
{
    public class CSSKeyframeRule : CSSRule
    {
        public string KeyText { get; set; }
        public CSSStyleDeclaration Style { get; set; }
    }
}
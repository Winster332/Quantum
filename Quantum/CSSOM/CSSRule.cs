using System;

namespace Quantum.CSSOM
{
    public class CSSRule : ICloneable
    {
        public string CssText { get; set; }
        public CSSRule ParentRule { get; set; }
        public CSSStyleSheet ParentStyleSheet { get; set; }
        public string SelectorText { get; set; }
        public CSSRuleType Type { get; set; }
        public CSSStyleDeclaration Style { get; set; }

        public CSSRule()
        {
        }

        public object Clone()
        {
          var rule = new CSSRule
          {
            CssText = CssText,
            ParentRule = ParentRule?.Clone() as CSSRule,
            ParentStyleSheet = ParentStyleSheet,
            SelectorText = SelectorText,
            Type = Type,
            Style = Style.Clone() as CSSStyleDeclaration
          };

          return rule;
        }
    }
}
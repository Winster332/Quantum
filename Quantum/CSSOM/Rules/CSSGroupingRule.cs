using System.Collections.Generic;

namespace Quantum.CSSOM.Rules
{
    public class CSSGroupingRule : CSSRule
    {
        public List<CSSRule> CssRules { get; set; }

        public CSSGroupingRule()
        {
            CssRules = new List<CSSRule>();
        }
        
        public void DeleteRule(CSSRule rule)
        {
            CssRules.Remove(rule);
        }

        public void InsertRule(CSSRule rule)
        {
            CssRules.Add(rule);
        }
    }
}
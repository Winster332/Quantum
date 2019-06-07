using System.Collections.Generic;
using System.Linq;
using Quantum.DOM.Exceptions;

namespace Quantum.CSSOM
{
    public class CSSStyleSheet : StyleSheet
    {
        public List<CSSRule> CssRules { get; set; }
        public CSSRule OwnerRule { get; set; }
        
        public CSSStyleSheet()
        {
            CssRules = new List<CSSRule>();
        }

        public void DeleteRule(int index)
        {
            CssRules.RemoveAt(index);
        }

        public int InsertRule(string rule, int index)
        {
            if (index > CssRules.Count)
            {
                throw new IndexSizeError();
            }
            
            /// TODO: If rule cannot be inserted at index 0 due to some CSS constraint, the method aborts with a HierarchyRequestError.
            
            /// TODO: If more than one rule is given in the rule parameter, the method aborts with a SyntaxError.
            
            /// TODO: If trying to insert an @import at-rule after a style rule, the method aborts with a HierarchyRequestError.
            
            /// If rule is @namespace and the rule-list has more than just @import at-rules and/or @namespace at-rules, the method aborts with an InvalidStateError.
            ///
            var cssRule = new CSSRule();
            cssRule.ParentStyleSheet = this;
            cssRule.CssText = rule;

//            CssRules.Add(index, cssRule);
//            CssRules = CssRules.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            return index;
        }
    }
}
using System.Collections.Generic;

namespace Quantum.CSSOM.Rules
{
    public class CSSKeyframesRule : CSSRule
    {
        /// <summary>
        ///  TODO: CHECK
        /// </summary>
        public string Name { get; set; }
        public List<CSSRule> CssRules { get; set; }

        public CSSKeyframesRule()
        {
            CssRules = new List<CSSRule>();
        }

        public void AppendRule()
        {
            // TODO: Impl
        }

        public void DeleteRule()
        {
            // TODO: Impl
        }

        public void FindRule()
        {
            // TODO: Impl
        }
    }
}
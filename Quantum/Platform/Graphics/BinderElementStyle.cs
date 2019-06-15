using System.Collections.Generic;
using System.Linq;
using Quantum.CSSOM;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Platform.Graphics
{
    public class BinderElementStyle
    {
        private Document _document;
        private List<CSSStyleSheet> _styleSheets;

        public BinderElementStyle(Document document)
        {
            _document = document;
            _styleSheets = document.StyleSheets.OfType<CSSStyleSheet>().ToList();
        }

        public List<CSSRule> Bind(HTMLElement element)
        {
            var styles = new List<CSSRule>();
            
            if (element == null)
            {
                return styles;
            }

            var classes = FindClasses(element);
            styles.AddRange(classes);

            var tags = FindTags(element);
            styles.AddRange(tags);

            return styles;
        }

        private List<CSSRule> FindTags(HTMLElement element)
        {
            var styles = new List<CSSRule>();

            var elementName = element.TagName;

            styles = _styleSheets.SelectMany(x => x.CssRules)
                .Where(x => x.SelectorText.Replace("\"", "").Replace("#", "") == elementName)
                .ToList();
            
            return styles;
        }

        private List<CSSRule> FindClasses(HTMLElement element)
        {
            var styles = new List<CSSRule>();
            
            var className = element.GetAttribute("class")?.Value.Replace("\"", "").Replace(".", "");
            if (className != null)
            {
                styles = _styleSheets
                    .SelectMany(x => x.CssRules)
                    .Where(x => x.SelectorText.Replace(".", "").Replace("\"", "") == className)
                    .ToList();
            }

            return styles;
        }
    }
}
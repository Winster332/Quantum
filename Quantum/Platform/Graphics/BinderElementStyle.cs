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
        private List<CSSRule> _rules;

        public BinderElementStyle(Document document)
        {
            _document = document;
            _styleSheets = _document.StyleSheets.OfType<CSSStyleSheet>().ToList();
            _rules = _styleSheets.SelectMany(x => x.CssRules).ToList();
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

            var all = FindByAll();
            styles.AddRange(all);

            var attrs = FindAttributes();
            styles.AddRange(attrs);
            
            return styles;
        }

        private List<CSSRule> FindAttributes()
        {
            var styles = _rules.Where(x => x.SelectorText.FirstOrDefault() == '[' && x.SelectorText.FirstOrDefault() == ']')
                .ToList();
            return styles;
        }
        
        private List<CSSRule> FindByAll()
        {
            var styles = _rules.Where(x => x.SelectorText == "*")
                .ToList();
            return styles;
        }

        private List<CSSRule> FindTags(HTMLElement element)
        {
            var styles = new List<CSSRule>();

            var elementName = element.TagName;

            styles = _rules.Where(x => CleanUp(x.SelectorText, "\"", "#") == elementName)
                .ToList();
            
            return styles;
        }

        private List<CSSRule> FindClasses(HTMLElement element)
        {
            var styles = new List<CSSRule>();
            
            var className = element.GetAttribute("class")?.Value.Replace("\"", "").Replace(".", "");
            if (className != null)
            {
                styles = _rules.Where(x => CleanUp(x.SelectorText, "\"", ".") == className)
                    .ToList();
            }

            return styles;
        }

        private string CleanUp(string text, params string[] symbols)
        {
            foreach (var symbol in symbols)
            {
                text = text.Replace(symbol, "");
            }

            return text;
        }
    }
}
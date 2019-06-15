using System.Collections.Generic;
using System.Linq;
using Quantum.CSSOM;
using Quantum.HTML;

namespace Quantum.Platform.Graphics
{
    public class RenderLayout
    {
        public List<RenderLayout> Layouts { get; set; }
        public RenderLayout Parent { get; set; }
        public HTMLElement Element { get; set; }
        public CSSRule CssRule { get; set; }

        public RenderLayout()
        {
            Layouts = new List<RenderLayout>();
            Parent = null;
        }

        public void AddLayout(RenderLayout layout)
        {
            layout.Parent = this;
            Layouts.Add(layout);
        }

        public override string ToString()
        {
            return $"Layouts - {Layouts.Count}";
        }

        public CSSRule MerageStyleWithParent()
        {
          if (Parent != null && Parent.CssRule != null)
          {
            var parentRule = Parent.CssRule.Clone() as CSSRule;

            // TODO: Need merge
          }

          return Parent?.CssRule;
        }
    }
}
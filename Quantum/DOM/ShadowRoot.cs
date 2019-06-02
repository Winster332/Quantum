using System.Collections.Generic;
using Quantum.DOM.CSS;

namespace Quantum.DOM
{
    public class ShadowRoot
    {
        public Element Host { get; set; }
        public ShadowRootMode Mode { get; set; }
        public Element ActiveElement { get; set; }
        public List<StyleSheet> StyleSheets { get; set; }

        public ShadowRoot()
        {
            StyleSheets = new List<StyleSheet>();
        }

        public Selection GetSelection()
        {
            return null;
        }

        public Element ElementFromPoint(float x, float y)
        {
            // TODO: Impl
            return null;
        }
        
        public List<Element> ElementsFromPoint(float x, float y)
        {
            // TODO: Impl
            return null;
        }

        public Range CaretPositionFromPoint()
        {
            // TODO: Impl
            return null;
        }
    }
}
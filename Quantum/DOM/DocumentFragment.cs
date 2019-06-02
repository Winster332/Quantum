using System.Collections.Generic;

namespace Quantum.DOM
{
    public class DocumentFragment : Node
    {
        public List<Element> Children { get; set; }
        public Element FirstElementChild => FirstChild as Element;
        public Element LastElementChild => LastChild as Element;
        public int ChildElementCount => ChildNodes.Count;

        public DocumentFragment()
        {
            Children = new List<Element>();
        }

        public Element QuerySelector(string selectors)
        {
            // TODO: Impl
            return null;
        }
        
        public List<Element> QuerySelectorAll(string selectors)
        {
            // TODO: Impl
            return null;
        }

        public Element GetElementById()
        {
            // TODO: Impl
            return null;
        }
    }
}
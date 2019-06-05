using System.Collections.Generic;
using Quantum.DOM;

namespace Quantum.HTML
{
    public class HTMLFormControlsCollection
    {
        private Dictionary<string, Element> _elements;
        public int Count => _elements.Count;

        public HTMLFormControlsCollection()
        {
            _elements = new Dictionary<string, Element>();
        }
        
        public Element NamedItem(string value)
        {
            return _elements[value];
        }
    }
}
namespace Quantum.DOM
{
    public class Element : Node
    {
        public NamedNodeMap Attributes { get; set; }
        public DOMTokenList ClassList { get; set; }
        public HTMLCollection<Element> Children { get; set; }

        public Element()
        {
            Attributes = new NamedNodeMap();
            ClassList = new DOMTokenList();
            Children = new HTMLCollection<Element>();
        }
    }
}
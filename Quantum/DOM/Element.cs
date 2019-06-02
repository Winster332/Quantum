using System.Linq;

namespace Quantum.DOM
{
    public class Element : Node
    {
        public NamedNodeMap Attributes { get; set; }
        public DOMTokenList ClassList { get; set; }
        public int ChildElementCount => Children.Count;
        public HTMLCollection<Element> Children { get; set; }
        public string ClassName { get; set; }
        public float ClientHeight { get; set; }
        public float ClientLeft { get; set; }
        public float ClientTop { get; set; }
        public float ClientWidth { get; set; }
        public Element FirstElementChild => Children.FirstOrDefault().Value;
        public string Id { get; set; }
        public string InnerHTML { get; set; }
        public Element LastElementChild => Children.LastOrDefault().Value;
        public Element NextElementSibling => NextSibling as Element;
        public Element PreviousElementSibling => PreviousSibling as Element;
        public float ScrollHeight { get; set; }
        public float ScrollLeft { get; set; }
        public float ScrollTop { get; set; }
        public float ScrollWidth { get; set; }

        public Element()
        {
            Attributes = new NamedNodeMap();
            ClassList = new DOMTokenList();
            Children = new HTMLCollection<Element>();
            ClassName = string.Empty;
            NodeType = NodeType.ElementNode;
            ClientHeight = float.NaN;
            ClientLeft = float.NaN;
            ClientTop = float.NaN;
            ClientWidth = float.NaN;
        }
    }
}
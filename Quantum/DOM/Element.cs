namespace Quantum.DOM
{
    public class Element : Node
    {
        public NamedNodeMap Attributes { get; set; }

        public Element()
        {
            Attributes = new NamedNodeMap();
        }
    }
}
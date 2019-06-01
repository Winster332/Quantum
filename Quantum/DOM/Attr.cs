using System;

namespace Quantum.DOM
{
    public class Attr : Node
    {
        public string Name { get; set; }
        public Uri NamespaceURI { get; set; }
        public string LocalName { get; set; }
        public string Prefix { get; set; }
        public Element OwnerElement { get; set; }
        public string Value { get; set; }

        public Attr()
        {
            NodeType = NodeType.AttributeNode;
        }
    }
}
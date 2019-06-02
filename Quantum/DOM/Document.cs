using System;
using System.Collections.Generic;
using System.Text;
using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public class Document : Node
    {
        public string ContentType { get; set; }
        public Encoding CharacterSet { get; set; }
        public DocumentType DocType { get; set; }
        public Element DocumentElement { get; set; }
        
        public Document()
        {
            ContentType = "text/html";
            CharacterSet = Encoding.UTF8;
            DocType = new DocumentType(this);
        }

        public Range CreateRange()
        {
            var range = new Range(this);

            return range;
        }

        public DocumentFragment CreateDocumentFragment()
        {
            var nodes = new Node[ChildNodes.Count];
            ChildNodes.CopyTo(nodes, 0);
            
            return new DocumentFragment
            {
                ChildNodes = nodes,
                NodeType = NodeType.DocumentFragmentNode,
                OwnerDocument = this,
                ParentNode = this
            };
        }

//        public void CreateEvent<T>()
//        {
//            var eventType = typeof(T);
//            
//            AddEventListener<T>();
//        }
    }
}
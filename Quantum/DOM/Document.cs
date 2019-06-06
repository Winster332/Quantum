using System;
using System.Collections.Generic;
using System.Text;
using Quantum.CSSOM;
using Quantum.DOM.Events;
using Quantum.HTML;

namespace Quantum.DOM
{
    public class Document : Node
    {
        public string ContentType { get; set; }
        public Encoding CharacterSet { get; set; }
        public List<StyleSheet> StyleSheets { get; set; }
        public DocumentType DocType { get; set; }
        public Element DocumentElement => FirstChild as Element;
        public HTMLBodyElement Body { get; set; }
        public HTMLHeadElement Head { get; set; }
        public string Title { get; set; }
        public List<HTMLScriptElement> Scripts { get; set; }
        
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
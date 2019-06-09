using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quantum.CSSOM;
using Quantum.DOM.Events;
using Quantum.Extensions;
using Quantum.HTML;

namespace Quantum.DOM
{
    public class Document : Node
    {
        public Storage LocalStorage { get; set; }
        public string ContentType { get; set; }
        public Encoding CharacterSet { get; set; }
        public List<StyleSheet> StyleSheets { get; set; }
        public DocumentType DocType { get; set; }
        public Element DocumentElement => FirstChild as Element;

        public HTMLBodyElement Body
        {
            get => GetBody();
            set => SetBody(value);
        }

        public HTMLHeadElement Head
        {
            get
            {
                if (!(FirstChild is HTMLHtmlElement)) return null;
                
                foreach (var childNode in FirstChild.ChildNodes)
                {
                    if (childNode is HTMLHeadElement head)
                    {
                        return head;
                    }
                }

                return null;
            }
            set
            {
                foreach (var childNode in ChildNodes)
                {
                    if (childNode is HTMLHeadElement head)
                    {
                        head = value;
                        break;
                    }
                }
                
                AppendChild(value);
            }
        }
        public string Title { get; set; }
        public List<HTMLScriptElement> Scripts { get; set; }
        
        public Document()
        {
            ContentType = "text/html";
            CharacterSet = Encoding.UTF8;
            DocType = new DocumentType(this);
            StyleSheets = new List<StyleSheet>();
            Scripts = new List<HTMLScriptElement>();
            LocalStorage = new Storage();
        }

        private HTMLBodyElement GetBody()
        {
            if (!(FirstChild is HTMLHtmlElement)) return null;
            
            foreach (var element in FirstChild.ChildNodes)
            {
                if (element is HTMLBodyElement bodyElement)
                {
                    return bodyElement;
                }
            }

            return null;
        }

        private void SetBody(HTMLBodyElement value)
        {
            var body = GetBody();

            if (body != null)
            {
                body = value;
            }
            else
            {
                if (FirstChild is HTMLHtmlElement html)
                {
                    html.AppendChild(value);
                }
                else
                {
                    AppendChild(value);
                }
            }
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

        public Element CreateElement<T>() where T : HTMLElement
        {
            var type = typeof(T);
            var element = Activator.CreateInstance(type) as HTMLElement;

            return element;
        }

        public HTMLElement GetElementById(string id)
        {
            var element = Body.Children
                .GraphLookup()
                .Where(x => x.GetAttribute("id") != null)
                .FirstOrDefault(x => x.GetAttribute("id").Value.Replace("\"", "") == id);

            return element as HTMLElement;
        }

        public List<HTMLElement> GetElementsByClassName(string className)
        {
            return Body.GetElementsByClassName(className);
        }

//        public void CreateEvent<T>()
//        {
//            var eventType = typeof(T);
//            
//            AddEventListener<T>();
//        }
    }
}
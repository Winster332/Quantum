using System.Collections.Generic;
using System.Linq;
using Quantum.DOM.Events;
using Quantum.Extensions;
using Quantum.HTML;

namespace Quantum.DOM
{
    public class Element : Node
    {
        public NamedNodeMap Attributes { get; set; }
        public DOMTokenList ClassList { get; set; }
        public int ChildElementCount => Children.Count;

        public List<Element> Children
        {
            get => ChildNodes.Select(x => (Element)x).ToList();
            set => ChildNodes = value.ToList<Node>();
        }

        public string ClassName { get; set; }
        public float ClientHeight { get; set; }
        public float ClientLeft { get; set; }
        public float ClientTop { get; set; }
        public float ClientWidth { get; set; }
        public Element FirstElementChild => Children.FirstOrDefault();
        public string Id { get; set; }
        public string InnerHTML { get; set; }
        public Element LastElementChild => Children.LastOrDefault();
        public Element NextElementSibling => NextSibling as Element;
        public Element PreviousElementSibling => PreviousSibling as Element;
        public float ScrollHeight { get; set; }
        public float ScrollLeft { get; set; }
        public float ScrollTop { get; set; }
        public float ScrollWidth { get; set; }
        public ShadowRoot ShadowRoot { get; set; }
        public string TagName { get; set; }

        public DOMEventHandler<IGotPointerCapture> OnGotPointerCapture { get; set; }
        public DOMEventHandler<ILostPointerCapture> OnLostPointerCapture { get; set; }
        
        public Element()
        {
            Attributes = new NamedNodeMap();
            ClassList = new DOMTokenList();
            Children = new List<Element>();
            ClassName = string.Empty;
            NodeType = NodeType.ElementNode;
            ClientHeight = float.NaN;
            ClientLeft = float.NaN;
            ClientTop = float.NaN;
            ClientWidth = float.NaN;
            OnGotPointerCapture = new DOMEventHandler<IGotPointerCapture>(this);
            OnLostPointerCapture = new DOMEventHandler<ILostPointerCapture>(this);
        }

        public void Closest(string selectors)
        {
            /// TODO: Impl
        }

        public void CreateShadowRoot()
        {
            /// TODO: Impl
        }

        public void Find()
        {
            /// TODO: Impl
        }
        
        public void FindAll()
        {
            /// TODO: Impl
        }

        public Attr GetAttribute(string name)
        {
            return Attributes.GetNamedItem(name);
        }

        public DOMRect Get​Bounding​Client​Rect()
        {
            /// TODO: Impl
            return null;
        }
        
        public List<DOMRect> GetClientRects()
        {
            /// TODO: Impl
            return null;
        }

        public List<HTMLElement> GetElementsByClassName(string className)
        {
            className = className.ToLower();
            
            var elements = Children
                .GraphLookup()
                .Where(x => x.GetAttribute("class") != null)
                .Select(x => new
                {
                    Segments = x.GetAttribute("class").Value
                        .Replace("\"", "")
                        .Split(' ')
                        .Select(c => c.ToLower())
                        .ToList(),
                    Element = x
                })
                .Where(x => x.Segments.Contains(className))
                .Select(x => x.Element as HTMLElement)
                .ToList();

            return elements;
        }
        
        public List<Element> GetElementsByTagName()
        {
            /// TODO: Impl
            return null;
        }
        
        public bool HasAttribute(string name)
        {
            return Attributes.GetNamedItem(name) != null;
        }
        
        public void InsertAdjacentHTML(int position, string text)
        {
            /// TODO: Impl
        }

        public bool Matches()
        {
            /// TODO: Impl
            return false;
        }

        public Node QuerySelector(string selector)
        {
            /// TODO: Impl
            return null;
        }

        public List<Node> QuerySelectorAll(string selector)
        {
            /// TODO: Impl
            return null;
        }

        public void Remove()
        {
            ParentNode?.ChildNodes.Remove(this);
        }

        public void RemoveAttribute(string name)
        {
            Attributes.RemoveNamedItem(name);
        }

        public void setAttribute(string name, Attr value)
        {
            Attributes.RemoveNamedItem(name);
            Attributes.SetNamedItem(value);
        }
        
        public void SetPointerCapture()
        {
            /// TODO: Impl
        }
    }
}
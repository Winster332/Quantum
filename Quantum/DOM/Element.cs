using System.Collections.Generic;
using System.Linq;
using Quantum.CSSOM;
using Quantum.DOM.Events;
using Quantum.Extensions;
using Quantum.HTML;

namespace Quantum.DOM
{
    public class Element : Node
    {
        public NamedNodeMap Attributes { get; set; }
        public DOMTokenList ClassList => GetClassList();
        public int ChildElementCount => Children.Count;

        public CSSStyleDeclaration Style => CSSStyleDeclaration.Parse(Attributes.GetNamedItem("style").Value
            .Replace("\"", "")
            .Split(' ')
            .ToDictionary(x => x.Split('=').FirstOrDefault(), x => x.Split('=').LastOrDefault()));

        public List<Element> Children
        {
            get => ChildNodes.Select(x => (Element)x).ToList();
            set => ChildNodes = value.ToList<Node>();
        }

        private DOMTokenList GetClassList()
        {
            var list = new DOMTokenList();
            
            foreach (var s in Attributes.GetNamedItem("class")?.Value.Split(' ').ToList())
            {
                list.Add(s);
            }

            return list;
        }

        public string ClassName => Attributes.GetNamedItem("class")?.Value;
        public float ClientHeight { get; set; }
        public float ClientLeft { get; set; }
        public Element OffsetParent => ParentNode as Element;

        public float ClientTop { get; set; }
        public float ClientWidth { get; set; }
        private float _offsetTop;
        private float _offsetLeft;
        private float _offsetWidth;
        private float _offsetHeight;
        public float OffsetLeft
        {
          get => OffsetParent?.OffsetLeft + _offsetLeft ?? _offsetLeft;
          set => _offsetLeft = value;
        }

        public float OffsetTop
        {
          get => OffsetParent?.OffsetTop + _offsetTop ?? _offsetTop;
          set => _offsetTop = value;
        }
        public float OffsetWidth
        {
          get
          {
            var width = 0.0f;
            Children.ForEach(child => width += child.OffsetWidth);
            return _offsetWidth + width;
          }
          set => _offsetWidth = value;
        }

        public float OffsetHeight
        {
          get
          {
            return _offsetHeight;
          } 
          set => _offsetHeight = value;
        }
        public Element FirstElementChild => Children.FirstOrDefault();
        public string Id => GetAttribute("id")?.Value;
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
            Children = new List<Element>();
            NodeType = NodeType.ElementNode;
            ClientHeight = float.NaN;
            ClientLeft = float.NaN;
            ClientTop = float.NaN;
            ClientWidth = float.NaN;
            OnGotPointerCapture = new DOMEventHandler<IGotPointerCapture>(this);
            OnLostPointerCapture = new DOMEventHandler<ILostPointerCapture>(this);
            OffsetLeft = 5;
            OffsetTop = 15;
            OffsetWidth = 0;
            OffsetHeight = 0;
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
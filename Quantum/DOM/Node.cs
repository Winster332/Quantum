using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public class Node : EventTarget
    {
        public Uri BaseURI { get; set; }
        public IList<Node> ChildNodes { get; set; }
        public Node FirstChild => ChildNodes.FirstOrDefault();
        public Node LastChild => ChildNodes.LastOrDefault();

        public Node NextSibling
        {
            get
            {
                for (var i = 0; i < ParentNode?.ChildNodes.Count; i++)
                {
                    var node = ParentNode.ChildNodes[i];

                    if (node == this)
                    {
                        if (i >= 0 && i < ParentNode.ChildNodes.Count - 1)
                        {
                            return ParentNode?.ChildNodes[i+1];
                        }
                    }
                }

                return null;
            }
        }
        public string NodeName { get; set; }
        public NodeType NodeType { get; set; }
        public string NodeValue { get; set; }
        public Document OwnerDocument { get; set; }
        public Node ParentNode { get; set; }

        public Node PreviousSibling
        {
            get
            {
                for (var i = 0; i < ParentNode?.ChildNodes.Count; i++)
                {
                    var node = ParentNode.ChildNodes[i];

                    if (node == this)
                    {
                        if (i >= 1 && i < ParentNode.ChildNodes.Count)
                        {
                            return ParentNode?.ChildNodes[i-1];
                        }
                    }
                }

                return null;
            }
        }
        public string TextContent { get; set; }

        public Node()
        {
            ChildNodes = new List<Node>();
        }

        public void AppendChild(Node node)
        {
            node.ParentNode = this;
            ChildNodes.Add(node);
        }

        public bool HasChildNodes()
        {
            return ChildNodes.Count != 0;
        }

        public void RemoveChild(Node node)
        {
            ChildNodes.Remove(node);
        }

        public override string ToString()
        {
            return $"#{NodeName}";
        }
    }
}
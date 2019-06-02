using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantum.DOM
{
    public class Range
    {
        public bool Collapsed => StartOffset == EndOffset;
        public Node CommonAncestorContainer { get; set; }
        public Node EndContainer { get; set; }
        public int EndOffset { get; set; }
        public Node StartContainer { get; set; }
        public int StartOffset { get; set; }
        private Document _document;

        public Range(Document document)
        {
            _document = document;
            CommonAncestorContainer = document;
            StartContainer = document;
            EndContainer = document;
            StartOffset = 0;
            EndOffset = 0;
        }

        public void SetStart(Node startNode, int startOffset)
        {
            StartContainer = startNode;
            StartOffset = startOffset;

            EndOffset = 0;
            EndContainer = startNode;
        }

        public void SetEnd(Node endNode, int endOffset)
        {
            EndContainer = endNode;
            EndOffset = endOffset;
        }

        public void SetStartBefore(Node referenceNode)
        {
            StartContainer = referenceNode.PreviousSibling;
        }

        public void SetStartAfter(Node referenceNode)
        {
            StartContainer = referenceNode.NextSibling;
        }

        public void SetEndBefore(Node referenceNode)
        {
            EndContainer = referenceNode.PreviousSibling;
        }

        public void SetEndAfter(Node referenceNode)
        {
            EndContainer = referenceNode.NextSibling;
        }

        public void SelectNode(Node referenceNode)
        {
            StartOffset = 0;
            for (var i = 0; i < referenceNode.ParentNode.ChildNodes.Count; i++)
            {
                var targetNode = referenceNode.ParentNode.ChildNodes[i];

                StartOffset++;

                if (targetNode == referenceNode)
                {
                    EndOffset = StartOffset + 1;
                    StartContainer = targetNode.ParentNode;
                    EndContainer = targetNode.ParentNode;
                    break;
                }
            }

            CommonAncestorContainer = GetCommonAncestorContainer(referenceNode);
        }

        public void SelectNodeContents(Node referenceNode)
        {
            StartContainer = referenceNode;
            EndContainer = referenceNode;
            StartOffset = 0;
            EndOffset = 0;
            CommonAncestorContainer = GetCommonAncestorContainer(referenceNode);
            
            for (var i = 0; i < referenceNode.ParentNode.ChildNodes.Count; i++)
            {
                var targetNode = referenceNode.ParentNode.ChildNodes[i];

                if (targetNode.NodeType != NodeType.TextNode)
                {
                    StartOffset++;
                }

                if (StartOffset != 0 && targetNode.NodeType != NodeType.TextNode)
                {
                    EndOffset++;
                }

                if (targetNode == referenceNode)
                {
                    if (targetNode.ParentNode.NodeType != NodeType.TextNode)
                    {
                        StartContainer = targetNode.ParentNode;
                        EndContainer = targetNode.ParentNode;
                    }

                    break;
                }
            }
        }

        private Node GetCommonAncestorContainer(Node referenceNode)
        {
            var current = referenceNode;
            var result = referenceNode;
            do
            {
                if (current.NodeType != NodeType.TextNode)
                {
                    result = current;
                    break;
                }

                current = current.ParentNode;
            } while (current != null);

            return result;
        }

        public void Collapse(bool toStart)
        {
            StartContainer.AppendChild(EndContainer);
            StartOffset = 0;
            EndOffset = 0;
            // Impl
        }

        public void DeleteContents()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void ExtractContents()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void InsetNode()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void SurroundContents()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void CompareBoundaryPoints()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void Detach()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public int ComparePoint()
        {
            // TODO: Impl
            throw new NotSupportedException();
            return -1;
        }

        public DocumentFragment CreateContextualFragment()
        {
            // TODO: Impl
            throw new NotSupportedException();
            return _document.CreateDocumentFragment();
        }

        public DOMRect GetBoundingClientRect()
        {
            // TODO: Impl
            throw new NotSupportedException();
            return null;
        }

        public List<DOMRect> getClientRects()
        {
            // TODO: Impl
            throw new NotSupportedException();
            return null;
        }

        public void IntersectsNode()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public void IsPointInRange()
        {
            // TODO: Impl
            throw new NotSupportedException();
        }

        public override string ToString()
        {
            var result = string.Empty;
            
            if (StartContainer.NodeType == NodeType.TextNode)
            {
                var startText = StartContainer.TextContent.Substring(StartOffset, StartContainer.TextContent.Length - StartOffset);
                var endText = EndContainer.TextContent.Substring(0, EndOffset);

                result = $"{startText}\n{endText}";
            }

            return result;
        }
    }
}
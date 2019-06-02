using System.Collections.Generic;

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
            var current = referenceNode;

            StartOffset = 0;
            for (var i = 0; i < referenceNode.ParentNode.ChildNodes.Count; i++)
            {
                var targetNode = referenceNode.ParentNode.ChildNodes[i];

                StartOffset++;

                if (targetNode == referenceNode)
                {
                    EndOffset = StartOffset + 1;
                    StartContainer = targetNode;
                    EndContainer = targetNode;
                    break;
                }
            }

            CommonAncestorContainer = referenceNode;
        }

        public void SelectNodeContents(Node referenceNode)
        {
            StartContainer = referenceNode.FirstChild;
            EndContainer = referenceNode.LastChild;

            StartOffset = 0;
            EndOffset = referenceNode.ChildNodes.Count;
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
        }

        public void ExtractContents()
        {
            // TODO: Impl
        }

        public void InsetNode()
        {
            // TODO: Impl
        }

        public void SurroundContents()
        {
            // TODO: Impl
        }

        public void CompareBoundaryPoints()
        {
            // TODO: Impl
        }

        public void Detach()
        {
            // TODO: Impl
        }

        public int ComparePoint()
        {
            // TODO: Impl
            return -1;
        }

        public DocumentFragment CreateContextualFragment()
        {
            // TODO: Impl
            return _document.CreateDocumentFragment();
        }

        public DOMRect GetBoundingClientRect()
        {
            // TODO: Impl
            return null;
        }

        public List<DOMRect> getClientRects()
        {
            // TODO: Impl
            return null;
        }

        public void IntersectsNode()
        {
            // TODO: Impl
        }

        public void IsPointInRange()
        {
            // TODO: Impl
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
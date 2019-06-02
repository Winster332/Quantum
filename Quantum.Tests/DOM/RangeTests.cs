using System;
using System.Linq;
using FluentAssertions;
using Quantum.DOM;
using Quantum.DOM.Events;
using Xunit;

namespace Quantum.Tests.DOM
{
    public class RangeTests
    {
        public Document Document;
        public Node RootNode { get; set; }
        public RangeTests()
        {
            RootNode = CreateNode("root");
            Document = new Document();
            Document.AppendChild(RootNode);
            
            CreateNodesForChild(RootNode, "one", 10);
            CreateNodesForChild(RootNode, "two", 10);
            CreateNodesForChild(RootNode, "three", 10);
            CreateNodesForChild(RootNode, "four", 10);
        }

        [Fact]
        public void CreateRange()
        {
            var range = Document.CreateRange();

            range.Collapsed.Should().BeTrue();
            range.StartContainer.Should().BeEquivalentTo(Document);
            range.EndContainer.Should().BeEquivalentTo(Document);
            range.StartOffset.Should().BeGreaterOrEqualTo(0);
            range.EndOffset.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void SetStart()
        {
            var range = Document.CreateRange();
            var startNode = RootNode.ChildNodes[1];
            
            range.SetStart(startNode, 0);
            
            range.Collapsed.Should().BeTrue();
            range.StartContainer.Should().BeEquivalentTo(startNode);
            range.EndContainer.Should().BeEquivalentTo(startNode);
            range.StartOffset.Should().BeGreaterOrEqualTo(0);
            range.EndOffset.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void SetEnd()
        {
            var range = Document.CreateRange();
            var root = RootNode.FirstChild;
            var startNode = root.ChildNodes[0];
            var startOffset = 3;
            var endNode = root.ChildNodes[1];
            var endOffset = 5;
            
            range.SetStart(startNode, startOffset);
            range.SetEnd(endNode, endOffset);

            var result = range.ToString();
            
            range.Collapsed.Should().BeFalse();
            range.StartContainer.Should().BeEquivalentTo(startNode);
            range.EndContainer.Should().BeEquivalentTo(endNode);
            range.StartOffset.Should().BeGreaterOrEqualTo(startOffset);
            range.EndOffset.Should().BeGreaterOrEqualTo(endOffset);
            range.ToString().Should().BeEquivalentTo("-0-text\none-1");
        }

        [Fact]
        public void RangeWithSelectNode()
        {
            var root = CreateNode("root");
            root.AppendChild(CreateNode("span"));
            var target = CreateNode("a");
            target.AppendChild(CreateNode("b"));
            root.AppendChild(target);
            root.AppendChild(CreateNode("p"));

            var range = Document.CreateRange();
            range.SelectNode(target);
            range.StartContainer.NodeName.Should().BeEquivalentTo("root");
            range.EndContainer.NodeName.Should().BeEquivalentTo("root");
            range.Collapsed.Should().BeFalse();
            range.StartOffset.Should().BeGreaterOrEqualTo(2);
            range.EndOffset.Should().BeGreaterOrEqualTo(3);
            
            var element = new Element();
            element.OnGotPointerCapture += (e) =>
            {
                Console.WriteLine("Hello");
            };
            element.DispatchEvent(new Event<IGotPointerCapture>());
            
            Console.WriteLine("123");
        }
        
        [Fact]
        public void RangeWithSelectNodeContents()
        {
            var root = CreateNode("root");
            root.NodeType = NodeType.TextNode;
            var span = CreateNode("span");
            span.NodeType = NodeType.TextNode;
            root.AppendChild(span);
            var target = CreateNode("a");
            target.NodeType = NodeType.TextNode;
            target.AppendChild(CreateNode("b"));
            root.AppendChild(target);
            root.AppendChild(CreateNode("p"));

            var range = Document.CreateRange();
            range.SelectNodeContents(target);
            range.StartContainer.NodeName.Should().BeEquivalentTo("a");
            range.EndContainer.NodeName.Should().BeEquivalentTo("a");
            range.Collapsed.Should().BeTrue();
            range.StartOffset.Should().BeGreaterOrEqualTo(0);
            range.EndOffset.Should().BeGreaterOrEqualTo(0);
            
            var element = new Element();
            element.OnGotPointerCapture += (e) =>
            {
                Console.WriteLine("Hello");
            };
            element.DispatchEvent(new Event<IGotPointerCapture>());
            
            Console.WriteLine("123");
        }
        
        private void CreateNodesForChild(Node node, string subname, int count)
        {
            var nodeFixture = CreateNode(subname);
            
            for (var i = 0; i < count; i++)
            {
                var childNode = CreateNode($"{subname}-{i}");
                childNode.NodeType = NodeType.TextNode;
                childNode.TextContent = $"{childNode.NodeName}-text";
                
                nodeFixture.AppendChild(childNode);
            }
            
            node.AppendChild(nodeFixture);
        }

        private Node CreateNode(string nodeName)
        {
            var node = new Node {NodeName = nodeName};

            return node;
        }
    }
}
using System;
using System.Linq;
using FluentAssertions;
using Quantum.DOM;
using Xunit;

namespace Quantum.Tests.DOM
{
    public class NodeTests : QuantumTest
    {
        public Node RootNode { get; set; }
        
        public NodeTests()
        {
            RootNode = CreateNode("root");
        }

        [Fact]
        public void CreateRemoveNodesTest()
        {
            CreateNodesForChild(RootNode, "first", 10);
            CreateNodesForChild(RootNode, "second", 10);

            RootNode.ChildNodes.Should().HaveCount(2);

            RootNode.HasChildNodes().Should().BeTrue();
            
            RootNode.ChildNodes.First().NodeName.Should().BeEquivalentTo("first");
            RootNode.ChildNodes.Last().NodeName.Should().BeEquivalentTo("second");

            RootNode.ChildNodes.First().ChildNodes.Should().HaveCount(10);
            RootNode.ChildNodes.Last().ChildNodes.Should().HaveCount(10);

            RootNode.FirstChild.NodeName.Should().BeEquivalentTo("first");
            RootNode.LastChild.NodeName.Should().BeEquivalentTo("second");
        }

        [Fact]
        public void SiblingNodesTest()
        {
            CreateNodesForChild(RootNode, "one", 10);
            CreateNodesForChild(RootNode, "two", 10);
            CreateNodesForChild(RootNode, "three", 10);
            CreateNodesForChild(RootNode, "four", 10);

            // one
            RootNode.ChildNodes[0].NextSibling.NodeName.Should().BeEquivalentTo("two");
            RootNode.ChildNodes[0].PreviousSibling.Should().BeNull();
            // four
            RootNode.ChildNodes[3].NextSibling.Should().BeNull();
            RootNode.ChildNodes[3].PreviousSibling.NodeName.Should().BeEquivalentTo("three");
        }

        [Fact]
        public void RemoveChildNodes()
        {
            CreateNodesForChild(RootNode, "one", 10);
            CreateNodesForChild(RootNode, "two", 10);
            
            RootNode.RemoveChild(RootNode.LastChild);

            RootNode.ChildNodes.Should().HaveCount(1);
        }

        private void CreateNodesForChild(Node node, string subname, int count)
        {
            var nodeFixture = CreateNode(subname);
            
            for (var i = 0; i < count; i++)
            {
                var childNode = CreateNode($"{subname}-{i}");
                
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
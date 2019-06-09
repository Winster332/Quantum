using FluentAssertions;
using Quantum.DOM;
using Xunit;

namespace Quantum.Tests.DOM
{
    public class NamedNodeMapTests : QuantumTest
    {
        public NamedNodeMap Attrs { get; set; }
        
        public NamedNodeMapTests()
        {
            Attrs = new NamedNodeMap();
        }

        [Fact]
        public void CRUDAttrTest()
        {
            var attrClass = new Attr
            {
                Name = "class",
                LocalName = "classLocal"
            };
            var attrStyle = new Attr
            {
                Name = "style",
                LocalName = "styleLocal"
            };
            
            Attrs.SetNamedItem(attrClass);
            Attrs.SetNamedItem(attrStyle);
            Attrs.SetNamedItemNS(attrClass);
            Attrs.SetNamedItemNS(attrStyle);

            Attrs.Length.Should().BeGreaterOrEqualTo(4);
            
            Attrs.Item(0).Should().BeEquivalentTo(attrClass);
            Attrs.Item(1).Should().BeEquivalentTo(attrStyle);
            Attrs.Item(2).Should().BeEquivalentTo(attrClass);
            Attrs.Item(3).Should().BeEquivalentTo(attrStyle);
            
            Attrs.GetNamedItem(attrClass.Name).Should().BeEquivalentTo(attrClass);
            Attrs.GetNamedItem(attrClass.Name).Should().BeEquivalentTo(attrClass);
            Attrs.GetNamedItem("undefined").Should().BeNull();
            Attrs.GetNamedItemNS(attrClass.LocalName).Should().BeEquivalentTo(attrClass);
            Attrs.GetNamedItemNS(attrClass.LocalName).Should().BeEquivalentTo(attrClass);
            Attrs.GetNamedItemNS("undefined").Should().BeNull();
            
            Attrs.RemoveNamedItem(attrClass.Name);
            Attrs.RemoveNamedItem(attrStyle.Name);
            Attrs.RemoveNamedItemNS(attrClass.LocalName);
            Attrs.RemoveNamedItemNS(attrStyle.LocalName);

            Attrs.Length.Should().BeGreaterOrEqualTo(0);
        }
    }
}
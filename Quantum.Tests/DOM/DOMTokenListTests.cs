using FluentAssertions;
using Quantum.DOM;
using Xunit;

namespace Quantum.Tests.DOM
{
    public class DOMTokenListTests : QuantumTest
    {
        public DOMTokenList TokenList { get; set; }
        
        public DOMTokenListTests()
        {
            TokenList = new DOMTokenList();
        }

        [Fact]
        public void CheckValueTokenListTest()
        {
            TokenList.Add("a");
            TokenList.Add("b");
            TokenList.Add("c");
            TokenList.Add("d");

            TokenList.Value.Should().BeEquivalentTo("a b c d");
        }

        [Fact]
        public void CheckCRUDTokenListTest()
        {
            TokenList.Add("a");
            TokenList.Add("b");
            TokenList.Add("c");
            TokenList.Add("d");

            TokenList.Length.Should().BeGreaterOrEqualTo(4);

            TokenList.Contains("b").Should().BeTrue();
            TokenList.Contains("x").Should().BeFalse();

            TokenList.Item(1).Should().NotBeNull();
            TokenList.Item(4).Should().BeNull();
            
            TokenList.Replace("d", "f");
            TokenList.Item(3).Should().BeEquivalentTo("f");
            
            TokenList.Remove("c");
            TokenList.Length.Should().BeGreaterOrEqualTo(3);

            TokenList.Toggle("x").Should().BeTrue();
            TokenList.Length.Should().BeGreaterOrEqualTo(4);
            TokenList.Toggle("x").Should().BeFalse();
            TokenList.Length.Should().BeGreaterOrEqualTo(3);

            TokenList.Entries().Should().HaveCount(3);

            var count = 0;
            TokenList.ForEach(x => { count++; });
            count.Should().BeGreaterOrEqualTo(3);
        }
    }
}
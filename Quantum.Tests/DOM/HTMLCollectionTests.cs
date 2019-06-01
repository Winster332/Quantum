using FluentAssertions;
using Quantum.DOM;
using Xunit;

namespace Quantum.Tests.DOM
{
    public class HTMLCollectionTests
    {
        public HTMLCollection<FakeData> Collection { get; set; }

        public HTMLCollectionTests()
        {
            Collection = new HTMLCollection<FakeData>();
        }

        [Fact]
        public void CRUDHTMLCollectionTest()
        {
            var item1 = new FakeData {Name = "one", Value = "1"};
            var item2 = new FakeData {Name = "two", Value = "2"};
            
            Collection.Add(item1.Name, item1);
            Collection.Add(item2.Name, item2);

            Collection[0].Should().BeEquivalentTo(item1);
            Collection[1].Should().BeEquivalentTo(item2);
            Collection[2].Should().BeNull();
            
            Collection["one"].Should().BeEquivalentTo(item1);
            Collection["two"].Should().BeEquivalentTo(item2);
            Collection["three"].Should().BeNull();
        }

        public class FakeData
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
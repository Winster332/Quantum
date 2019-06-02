using Quantum.Parser;
using Xunit;

namespace Quantum.Tests.Parsers
{
    public class HtmlParserTests
    {
        public HtmlLoader Loader { get; set; }
        
        public HtmlParserTests()
        {
            Loader = new HtmlLoader();
        }

        [Fact]
        public void ParseFromFileTest()
        {
            Loader.LoadFromFile($"Contents/index.html");
        }
    }
}
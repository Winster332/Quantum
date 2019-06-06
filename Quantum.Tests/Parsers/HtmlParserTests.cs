using System;
using System.Linq;
using Quantum.Extensions;
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
            var tree = Loader.LoadFromFile($"Contents/index.html");
            var allNodes = tree.GraphLookup();

            Console.WriteLine("TEST");
        }
    }
}
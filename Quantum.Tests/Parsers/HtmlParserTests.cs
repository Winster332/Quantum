using System;
using System.Linq;
using System.Reflection;
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
            var window = Loader.LoadFromFile($"Contents/index.html", typeof(HtmlParserTests).Assembly);
            var document = window.Document;
//            var allNodes = tree.GraphLookup();

            Console.WriteLine("TEST");
        }
    }
}
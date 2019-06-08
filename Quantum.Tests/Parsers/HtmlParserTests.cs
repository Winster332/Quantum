using System;
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
//            var window = Loader.LoadFromFile($"Contents/index.html", typeof(HtmlParserTests).Assembly);
            var window = Loader.LoadFromFile($"Contents/html_document.html");
            var document = window.Document;

            Console.WriteLine("TEST");
        }
    }
}
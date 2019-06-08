using System;
using FluentAssertions;
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

            document.Body.Should().NotBeNull();
            document.Body.ChildElementCount.Should().BeGreaterOrEqualTo(1);
            document.Head.Should().NotBeNull();
            document.Head.ChildElementCount.Should().BeGreaterOrEqualTo(3);
            
            
            Console.WriteLine("TEST");
        }
    }
}
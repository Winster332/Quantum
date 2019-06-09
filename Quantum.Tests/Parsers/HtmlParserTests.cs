using System;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Quantum.CSSOM;
using Quantum.Parser;
using Quantum.Tests.Parsers.Scripts;
using Xunit;
using Xunit.Abstractions;

namespace Quantum.Tests.Parsers
{
    public class HtmlParserTests : QuantumTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public HtmlLoader Loader { get; set; }
        
        public HtmlParserTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Loader = new HtmlLoader();
        }

        [Fact]
        public void ParseFromFileTest()
        {
            var timer = new Stopwatch();
//            var window = Loader.LoadFromFile($"Contents/index.html", typeof(HtmlParserTests).Assembly);
            timer.Start();

            var window = Loader.LoadFromFile($"Contents/html_document.html");
            timer.Stop();
            _testOutputHelper.WriteLine(timer.Elapsed.ToString());
            var document = window.Document;

            document.Body.Should().NotBeNull();
            document.Body.ChildElementCount.Should().BeGreaterOrEqualTo(1);
            document.Head.Should().NotBeNull();
            document.Head.ChildElementCount.Should().BeGreaterOrEqualTo(3);

            document.Body.FirstChild.Should().NotBeNull();
            document.Body.FirstChild.FirstChild.Should().NotBeNull();
        }
        
        [Fact]
        public void ParseFromFileWithCss()
        {
            var timer = new Stopwatch();
            timer.Start();

            var window = Loader.LoadFromFile($"Contents/test_html_with_css.html");
            timer.Stop();
            _testOutputHelper.WriteLine(timer.Elapsed.ToString());
            var document = window.Document;

            document.StyleSheets.Should().HaveCount(1);

            var styleSheet = document.StyleSheets.FirstOrDefault() as CSSStyleSheet;
            styleSheet.Should().NotBeNull();

            styleSheet.CssRules.Should().HaveCount(2);
        }
        
        [Fact]
        public void ParseFromFileWithStyleCss()
        {
            var timer = new Stopwatch();
            timer.Start();

            var window = Loader.LoadFromFile($"Contents/test_style.html");
            timer.Stop();
            _testOutputHelper.WriteLine(timer.Elapsed.ToString());
            var document = window.Document;

            document.StyleSheets.Should().HaveCount(1);

            var styleSheet = document.StyleSheets.FirstOrDefault() as CSSStyleSheet;
            styleSheet.Should().NotBeNull();

            styleSheet.CssRules.Should().HaveCount(1);
        }
        
        [Fact]
        public void ParseFromFileWithApplyScript()
        {
            var timer = new Stopwatch();
            timer.Start();

            var window = Loader.LoadFromFile($"Contents/test_apply_script.html");
            timer.Stop();
            _testOutputHelper.WriteLine(timer.Elapsed.ToString());
            var document = window.Document;

            document.Scripts.Should().HaveCount(1);
        }
        
        [Fact]
        public void ParseFromFileWithApplyScriptInFile()
        {
            var timer = new Stopwatch();
            timer.Start();

            var window = Loader.LoadFromFile($"Contents/test_apply_script_in_tag.html");
            timer.Stop();
            _testOutputHelper.WriteLine(timer.Elapsed.ToString());
            var document = window.Document;

            document.Scripts.Should().HaveCount(1);
        }
    }
}
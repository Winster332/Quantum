using System;
using Quantum.Parser;
using Quantum.Platform.Graphics;
using Xunit;

namespace Quantum.Tests.Renderer
{
    public class RenderTreeTests
    {
        private RenderTree _renderTree;

        public RenderTreeTests()
        {
            _renderTree = new RenderTree();
        }

        [Fact]
        public void BuildRenderTreeFromDocumentTest()
        {
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_html_layout.html");
            
            _renderTree.Build(window);

            var layouts = _renderTree.LayoutRoot;
            Console.WriteLine();
        }
    }
}
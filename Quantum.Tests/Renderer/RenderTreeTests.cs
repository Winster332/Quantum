using System;
using System.Linq;
using FluentAssertions;
using Quantum.CSSOM.Common;
using Quantum.Parser;
using Quantum.Platform.Graphics;
using Xunit;

namespace Quantum.Tests.Renderer
{
    public class RenderTreeTests
    {
        public RenderTreeTests()
        {
        }

        [Fact]
        public void BuildRenderTreeFromDocumentTest()
        {
            var _renderTree = new RenderTree();
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_html_layout.html");
            
            _renderTree.Build(window);
            var root = _renderTree.LayoutRoot;
            
            root.Element.Should().BeNull();
            root.CssRule.Should().BeNull();
            root.Parent.Should().BeNull();
            root.Layouts.Should().HaveCount(1);

            var html = root.Layouts.FirstOrDefault();
            html.Should().NotBeNull();
            html.Parent.Should().BeNull();
            html.Element.TagName.Should().BeEquivalentTo("HTML");
            html.Layouts.Should().HaveCount(2);

            #region Head
            
            var head = html.Layouts.FirstOrDefault();
            head.Should().NotBeNull();
            head.Parent.Should().BeEquivalentTo(html);
            head.Element.NodeName.Should().BeEquivalentTo("head");
            head.Layouts.Should().HaveCount(2);

            var meta = head.Layouts.FirstOrDefault();
            meta.Should().NotBeNull();
            meta.Parent.Should().BeEquivalentTo(head);
            meta.Element.NodeName.Should().BeEquivalentTo("meta");
            meta.Layouts.Should().HaveCount(0);
            
            var title = head.Layouts.LastOrDefault();
            title.Should().NotBeNull();
            title.Parent.Should().BeEquivalentTo(head);
            title.Element.NodeName.Should().BeEquivalentTo("title");
            title.Layouts.Should().HaveCount(1);
            
            #endregion
            
            #region Body
            
            var body = html.Layouts.LastOrDefault();
            body.Should().NotBeNull();
            body.Parent.Should().BeEquivalentTo(html);
            body.Element.NodeName.Should().BeEquivalentTo("body");
            body.Layouts.Should().HaveCount(3);

            // First div
            var firstDiv = body.Layouts[0];
            firstDiv.Parent.Should().BeEquivalentTo(body);
            firstDiv.Element.NodeName.Should().BeEquivalentTo("div");
            firstDiv.Layouts.Should().HaveCount(3);

            var firstDivButton = firstDiv.Layouts[0];
            firstDivButton.Parent.Should().BeEquivalentTo(firstDiv);
            firstDivButton.Element.NodeName.Should().BeEquivalentTo("button");
            firstDivButton.Layouts.Should().HaveCount(0);
            
            var firstDivAnchor = firstDiv.Layouts[1];
            firstDivAnchor.Parent.Should().BeEquivalentTo(firstDiv);
            firstDivAnchor.Element.NodeName.Should().BeEquivalentTo("a");
            firstDivAnchor.Layouts.Should().HaveCount(1);
            firstDivAnchor.Layouts.FirstOrDefault().Element.NodeName.Should().BeEquivalentTo("span");
            
            // Second div
            var secondDiv = body.Layouts[1];
            secondDiv.Parent.Should().BeEquivalentTo(body);
            secondDiv.Element.NodeName.Should().BeEquivalentTo("div");
            secondDiv.Layouts.Should().HaveCount(0);
            
            // Three div
            var threeDiv = body.Layouts[2];
            threeDiv.Parent.Should().BeEquivalentTo(body);
            threeDiv.Element.NodeName.Should().BeEquivalentTo("div");
            threeDiv.Layouts.Should().HaveCount(0);
            
            #endregion
        }

        [Fact]
        public void BuildRenderBindStyleTest()
        {
            var _renderTree = new RenderTree();
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_html_bind_style.html");
            
            _renderTree.Build(window);
            var root = _renderTree.LayoutRoot;
            var html = root.Layouts.FirstOrDefault();
            var body = html.Layouts.LastOrDefault();

            var button = body.Layouts.FirstOrDefault();
            button.CssRule.Should().NotBeNull();
        }

        [Fact]
        public void BuildRender_InheritStyles_RenderLayout()
        {
            var _renderTree = new RenderTree();
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_html_layout_ingerit_styles.html");
            
            _renderTree.Build(window);
            var root = _renderTree.LayoutRoot;
            var html = root.Layouts.FirstOrDefault();
            var body = html.Layouts.LastOrDefault();
            var baseDiv = body.Layouts.FirstOrDefault();
            baseDiv.CssRule.Should().NotBeNull();
            
            var childrenDiv = baseDiv.Layouts;
            foreach (var renderLayout in childrenDiv)
            {
              renderLayout.CssRule.Should().BeEquivalentTo(baseDiv.CssRule);
            }
        }
        
        [Fact]
        public void BuildRender_InheritStylesWithParent_RenderLayout()
        {
            var _renderTree = new RenderTree();
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_html_inherit_styles_with_parent.html");
            
            _renderTree.Build(window);
            var root = _renderTree.LayoutRoot;
            var html = root.Layouts.FirstOrDefault();
            var body = html.Layouts.LastOrDefault();
            var mainDiv = body.Layouts.FirstOrDefault();
            mainDiv.CssRule.Should().NotBeNull();

            mainDiv.Layouts.FirstOrDefault().CssRule.SelectorText.Should().BeEquivalentTo(".oneLevel");
            var twoLevelDiv = mainDiv.Layouts.LastOrDefault();
            twoLevelDiv.CssRule.SelectorText.Should().BeEquivalentTo(".twoLevel");
            var twoLevelA = twoLevelDiv.Layouts.FirstOrDefault();
            twoLevelA.CssRule.SelectorText.Should().BeEquivalentTo(".twoLevel");

            var twoStyle = twoLevelA.CssRule.Style;
            var oneStyle = mainDiv.CssRule.Style;
            twoStyle.Color.Should().BeEquivalentTo(oneStyle.Color);
            twoStyle.Background.Color.Should().BeEquivalentTo(new CSSColor(255, 204, 85, 255));
        }
    }
}
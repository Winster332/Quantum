using System.Linq;
using Quantum.Parser;
using Quantum.Platform.Graphics;
using Xunit;

namespace Quantum.Tests.Renderer
{
    public class RenderLayoutCompositorTests
    {
        [Fact]
        public void RenderLayoutCompositor_AbsolutePosition_ReturnOffsetPosition()
        {
            var _renderTree = new RenderTree();
            var loader = new HtmlLoader();
            var window = loader.LoadFromFile("Contents/test_compositor_absolute_position.html");
            
            _renderTree.Build(window);
            var root = _renderTree.LayoutRoot;
            var html = root.Layouts.FirstOrDefault();
            var body = html.Layouts.LastOrDefault();
        }
    }
}
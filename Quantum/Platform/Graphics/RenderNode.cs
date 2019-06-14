using Quantum.HTML;

namespace Quantum.Platform.Graphics
{
    public class RenderNode
    {
        public HTMLElement Element { get; set; }

        public override string ToString()
        {
            return Element.ToString();
        }
    }
}
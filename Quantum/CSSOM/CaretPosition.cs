using Quantum.DOM;

namespace Quantum.CSSOM
{
    public class CaretPosition
    {
        public Node OffsetNode { get; set; }
        public long Offset { get; set; }

        public DOMRect GetClientRect()
        {
            /// TODO: IMPL
            return null;
        }
    }
}
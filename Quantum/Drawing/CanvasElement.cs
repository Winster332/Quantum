using Quantum.CSSOM.Common;
using Quantum.Drawing.Canvas;

namespace Quantum.Drawing
{
  internal class CanvasElement
  {
    public Path2D Path { get; set; }
    public CSSColor Color { get; set; }
    public bool IsFill { get; set; }
    
    public CanvasElement()
    {
    }
  }
}
using System.Drawing;
using Quantum.CSSOM.Common;
using Quantum.CSSOM.Common.BoxModel;

namespace Quantum.CSSOM.Properties
{
  public class CSSStyle
  {
    public CSSBackground Background { get; set; }
    public CSSBorder Border { get; set; }
    public CSSMargin Margin { get; set; }
    public CSSPadding Padding { get; set; }
    public CSSOpasity Opacity { get; set; }
    public CSSPositionType Position { get; set; }
    public CSSDisplayType Display { get; set; }
    public Color Color { get; set; }
    public CSSNumber Width { get; set; }
    public CSSNumber Height { get; set; }

    public CSSStyle()
    {
    }

    public CSSStyle Parse(string text)
    {
      return null;
    }
  }
}
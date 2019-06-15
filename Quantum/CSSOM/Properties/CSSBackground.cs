using System;
using Quantum.CSSOM.Common;

namespace Quantum.CSSOM.Properties
{
  public class CSSBackground : ICloneable
  {
    [CssField("color")]
    public CSSColor Color { get; set; }

    public static CSSBackground Parse(string value)
    {
      var background = new CSSBackground
      {
        Color = CSSColor.Parse(value)
      };

      return background;
    }

    public object Clone()
    {
      return new CSSBackground
      {
        Color = Color.Clone() as CSSColor
      };
    }
  }
}
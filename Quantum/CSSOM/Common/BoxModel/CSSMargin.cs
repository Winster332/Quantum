using System;
using System.Linq;

namespace Quantum.CSSOM.Common.BoxModel
{
  public class CSSMargin : ICloneable
  {
    [CssField("left")]
    public CSSNumber Left { get; set; }
    
    [CssField("right")]
    public CSSNumber Right { get; set; }
    
    [CssField("top")]
    public CSSNumber Top { get; set; }
    
    [CssField("bottom")]
    public CSSNumber Bottom { get; set; }
    
    public CSSMargin()
    {
      Left = new CSSNumber();
      Right = new CSSNumber();
      Top = new CSSNumber();
      Bottom = new CSSNumber();
    }
    
    public static CSSMargin Parse(string source)
    {
      var margin = new CSSMargin();

      var numbers = source.Split(' ').Select(CSSNumber.Parse).ToList();

      if (numbers.Count == 1)
      {
        margin.Left = numbers[0];
        margin.Top = numbers[0];
        margin.Right = numbers[0];
        margin.Bottom = numbers[0];
      }
      else if (numbers.Count == 2)
      {
        margin.Top = numbers[0];
        margin.Bottom = numbers[0];
        margin.Left = numbers[1];
        margin.Right = numbers[1];
      }
      else if (numbers.Count == 3)
      {
        margin.Top = numbers[0];
        margin.Left = numbers[1];
        margin.Right = numbers[1];
        margin.Bottom = numbers[2];
      }
      else if (numbers.Count == 4)
      {
        margin.Top = numbers[0];
        margin.Right = numbers[1];
        margin.Bottom = numbers[2];
        margin.Left = numbers[3];
      }

      return margin;
    }

    public object Clone()
    {
      return new CSSMargin
      {
        Left = Left.Clone() as CSSNumber,
        Right = Right.Clone() as CSSNumber,
        Top = Top.Clone() as CSSNumber,
        Bottom = Bottom.Clone() as CSSNumber
      };
    }
  }
}
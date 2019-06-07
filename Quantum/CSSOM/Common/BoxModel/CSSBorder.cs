using System.Linq;

namespace Quantum.CSSOM.Common.BoxModel
{
  public enum CSSBorderType
  {
    Solid,
    Dashed,
    Double
  }
  
  public class CSSBorder
  {
    [CssField("left")]
    public CSSNumber Left { get; set; }
    
    [CssField("right")]
    public CSSNumber Right { get; set; }
    
    [CssField("top")]
    public CSSNumber Top { get; set; }
    
    [CssField("bottom")]
    public CSSNumber Bottom { get; set; }
    
    [CssField("radius")]
    public CSSNumber Radius { get; set; }
    
    [CssField("type")]
    public CSSBorderType Type { get; set; }
    
    [CssField("color")]
    public CSSColor Color { get; set; }

    public CSSBorder()
    {
      Left = new CSSNumber();
      Right = new CSSNumber();
      Top = new CSSNumber();
      Bottom = new CSSNumber();

      Type = CSSBorderType.Solid;
      Radius = new CSSNumber();
      Color = CSSColor.Black;
    }
    
    public static CSSBorder Parse(string source)
    {
      var border = new CSSBorder();

      var numbers = source.Split(' ').Select(CSSNumber.Parse).ToList();

      if (numbers.Count == 1)
      {
        border.Left = numbers[0];
        border.Top = numbers[0];
        border.Right = numbers[0];
        border.Bottom = numbers[0];
      }
      else if (numbers.Count == 2)
      {
        border.Top = numbers[0];
        border.Bottom = numbers[0];
        border.Left = numbers[1];
        border.Right = numbers[1];
      }
      else if (numbers.Count == 3)
      {
        border.Top = numbers[0];
        border.Left = numbers[1];
        border.Right = numbers[1];
        border.Bottom = numbers[2];
      }
      else if (numbers.Count == 4)
      {
        border.Top = numbers[0];
        border.Right = numbers[1];
        border.Bottom = numbers[2];
        border.Left = numbers[3];
      }

      return border;
    }
  }
}
using System.Linq;

namespace Quantum.CSSOM.Common.BoxModel
{
  public class CSSPadding
  {
    [CssField("left")]
    public CSSNumber Left { get; set; }
    
    [CssField("right")]
    public CSSNumber Right { get; set; }
    
    [CssField("top")]
    public CSSNumber Top { get; set; }
    
    [CssField("bottom")]
    public CSSNumber Bottom { get; set; }

    public CSSPadding()
    {
      Left = new CSSNumber();
      Right = new CSSNumber();
      Top = new CSSNumber();
      Bottom = new CSSNumber();
    }
    
    public static CSSPadding Parse(string source)
    {
      var padding = new CSSPadding();

      var numbers = source.Split(' ').Select(CSSNumber.Parse).ToList();

      if (numbers.Count == 1)
      {
        padding.Left = numbers[0];
        padding.Top = numbers[0];
        padding.Right = numbers[0];
        padding.Bottom = numbers[0];
      }
      else if (numbers.Count == 2)
      {
        padding.Top = numbers[0];
        padding.Bottom = numbers[0];
        padding.Left = numbers[1];
        padding.Right = numbers[1];
      }
      else if (numbers.Count == 3)
      {
        padding.Top = numbers[0];
        padding.Left = numbers[1];
        padding.Right = numbers[1];
        padding.Bottom = numbers[2];
      }
      else if (numbers.Count == 4)
      {
        padding.Top = numbers[0];
        padding.Right = numbers[1];
        padding.Bottom = numbers[2];
        padding.Left = numbers[3];
      }

      return padding;
    }
  }
}
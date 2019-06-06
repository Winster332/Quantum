namespace Quantum.CSSOM.Common.BoxModel
{
  public enum CSSBorderType
  {
    Solid,
    Dashed,
    Double
  }
  public class CSSBorder : CSSBox
  {
    public CSSNumber Radius { get; set; }
    public CSSBorderType Type { get; set; }
    public CSSColor Color { get; set; }
  }
}
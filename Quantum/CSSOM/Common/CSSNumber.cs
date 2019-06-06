namespace Quantum.CSSOM.Common
{
  public enum CSSNumberType
  {
    Px,
    Pc
  }

  public class CSSNumber
  {
    public CSSNumberType Type { get; set; }
    public float Value { get; set; }

    public static CSSNumber Parse(string text)
    {
      if (text.Length <= 0)
      {
        return null;
      }

      text = text.ToLower();
      var type = CSSNumberType.Px;
      var value = 0.0f;

      if (text.Contains("px"))
      {
        type = CSSNumberType.Px;

        if (float.TryParse(text.Replace("px", ""), out var n))
        {
          value = n;
        }
      } 
      else if (text.Contains("%"))
      {
        type = CSSNumberType.Pc;
        
        if (float.TryParse(text.Replace("$", ""), out var n))
        {
          value = n;
        }
      }

      return new CSSNumber
      {
        Type = type,
        Value = value
      };
    }
  }
}
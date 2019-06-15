using System;

namespace Quantum.CSSOM.Common
{
  public enum CSSNumberType
  {
    Px,
    Pc,
    Rem,
    Em,
    Auto
  }

  public class CSSNumber : ICloneable
  {
    public CSSNumberType Type { get; set; }
    public float Value { get; set; }

    public CSSNumber()
    {
      Value = 0;
      Type = CSSNumberType.Auto;
    }

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
        
        if (float.TryParse(text.Replace("%", ""), out var n))
        {
          value = n;
        }
      }
      else if (text.Contains("rem"))
      {
        type = CSSNumberType.Rem;
        
        if (float.TryParse(text.Replace("rem", ""), out var n))
        {
          value = n;
        }
      }
      else if (text.Contains("em"))
      {
        type = CSSNumberType.Em;
        
        if (float.TryParse(text.Replace("em", ""), out var n))
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

    public object Clone()
    {
      return new CSSNumber
      {
        Value = Value,
        Type = Type
      };
    }
  }
}
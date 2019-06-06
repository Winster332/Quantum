using System;
using System.Linq;

namespace Quantum.CSSOM.Common
{
  public class CSSColor
  {
    private byte[] _bytes;

    public byte A
    {
      get => _bytes[3];
      set => _bytes[3] = value;
    }
    public byte R
    {
      get => _bytes[0];
      set => _bytes[0] = value;
    }
    public byte G
    {
      get => _bytes[1];
      set => _bytes[1] = value;
    }
    public byte B
    {
      get => _bytes[2];
      set => _bytes[2] = value;
    }

    public CSSColor()
    {
      _bytes = new byte[4];
      
      A = 255;
      R = 255;
      G = 255;
      B = 255;
    }
    
    public CSSColor(byte r, byte g, byte b, byte a = 255)
    {
      _bytes = new byte[4];
      
      A = a;
      R = r;
      G = g;
      B = b;
    }

    public static readonly CSSColor White = new CSSColor(255, 255, 255);

    public static CSSColor Parse(string hex)
    {
        var bytes = Enumerable.Range(0, hex.Length)
          .Where(x => x % 2 == 0)
          .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
          .ToArray();
        
        var color = new CSSColor();
        color._bytes = bytes;
        
        return color;
    }

    public override string ToString()
    {
      return $"[{R}, {G}, {B}, {A}]";
    }
  }
}
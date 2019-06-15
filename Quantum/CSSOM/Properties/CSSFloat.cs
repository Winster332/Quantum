using System;
using System.Linq;

namespace Quantum.CSSOM.Properties
{
    public enum CSSFloatType
    {
        None,
        Left,
        Right,
        Initial,
        Inherit
    }

    public class CSSFloat : ICloneable
    {
        public CSSFloatType Value { get; set; }

        public CSSFloat()
        {
            Value = CSSFloatType.None;
        }

        public static CSSFloat Parse(string source)
        {
            var cssFloat = new CSSFloat();
            
            source = $"{source.FirstOrDefault()}{source.Substring(1, source.Length - 1)}";

            if (CSSFloatType.TryParse<CSSFloatType>(source, true, out var value))
            {
                cssFloat.Value = value;
            }

            return cssFloat;
        }

        public object Clone()
        {
          return new CSSFloat
          {
            Value = Value
          };
        }
    }
}
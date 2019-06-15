using System;
using Quantum.CSSOM.Common;

namespace Quantum.CSSOM.Properties
{
    public class CSSFontStyle : ICloneable
    {
        public enum Type
        {
            Normal,
            Italic,
            Oblique
        }

        public Type Value { get; set; }

        public CSSFontStyle()
        {
            Value = Type.Normal;
        }

        public static CSSFontStyle Parse(string source)
        {
            // TODO: Impl
            return null;
        }

        public object Clone()
        {
          return new CSSFontStyle
          {
            Value = Value
          };
        }
    }

    public class CSSFontVariant : ICloneable
    {
        public enum Type
        {
            Normal,
            SmallCaps
        }

        public Type Value { get; set; }

        public CSSFontVariant()
        {
            Value = Type.Normal;
        }

        public static CSSFontVariant Parse(string source)
        {
            // TODO: Impl
            return null;
        }

        public object Clone()
        {
          return new CSSFontVariant
          {
            Value = Value
          };
        }
    }

    public class CSSFontWeight : ICloneable
    {
        public enum Type
        {
            Normal,
            Bold,
            Bolder,
            Lighter
        }

        public Type Value { get; set; }
        public CSSNumber Size { get; set; }

        public CSSFontWeight()
        {
            Value = Type.Normal;
            Size = new CSSNumber();
        }

        public static CSSFontWeight Parse(string source)
        {
            // TODO: Impl
            return null;
        }

        public object Clone()
        {
          return new CSSFontWeight
          {
            Value = Value,
            Size = Size.Clone() as CSSNumber
          };
        }
    }

    public class CSSFontSize
    {
        public CSSNumber Value { get; set; }

        public CSSFontSize()
        {
            Value = new CSSNumber();
        }

        public static CSSFontSize Parse(string source)
        {
            // TODO: Impl
            return null;
        }
    }

    public class CSSFontFamily
    {
        public string Value { get; set; }

        public CSSFontFamily()
        {
            Value = "Arial";
        }

        public static CSSFontFamily Parse(string source)
        {
            // TODO: Impl
            return null;
        }
    }


    public class CSSFont : ICloneable
    {
        [CssField("style")]
        public CSSFontStyle Style { get; set; }
        
        [CssField("variant")]
        public CSSFontVariant Variant { get; set; }
        
        [CssField("weight")]
        public CSSFontWeight Weight { get; set; }
        
        [CssField("size")]
        public CSSFontSize Size { get; set; }
        
        [CssField("family")]
        public CSSFontFamily Family { get; set; }
       
        // TODO: Imp;
        // caption
        // icon
        // menu
        // message-box
        // status-bar
        
        public CSSFont()
        {
            Style = new CSSFontStyle();
            Variant = new CSSFontVariant();
            Weight = new CSSFontWeight();
            Size = new CSSFontSize();
            Family = new CSSFontFamily();
        }
        
        public static CSSFont Parse(string source)
        {
            // TODO: Impl
            return null;
        }

        public object Clone()
        {
          return new CSSFont
          {
            Style = Style.Clone() as CSSFontStyle,
            Variant = Variant.Clone() as CSSFontVariant,
            Weight = Weight.Clone() as CSSFontWeight,
          };
        }
    }
}
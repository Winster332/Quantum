using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Quantum.CSSOM.Common;
using Quantum.CSSOM.Common.BoxModel;
using Quantum.CSSOM.Properties;
using Quantum.Extensions;

namespace Quantum.CSSOM
{
    public class CSSStyleDeclaration : ICloneable
    {
        [CssField("position")]
        public CSSPosition Position { get; set; }
        
        [CssField("display")]
        public CSSDisplay Display { get; set; }
        
        [CssField("color")]
        public CSSColor Color { get; set; }
        
        [CssField("background")]
        public CSSBackground Background { get; set; }
        
        [CssField("padding")]
        public CSSPadding Padding { get; set; }
        
        [CssField("margin")]
        public CSSMargin Margin { get; set; }
        
        [CssField("border")]
        public CSSBorder Border { get; set; }
        
        [CssField("cursor")]
        public CSSCursor Cursor { get; set; }
        
        [CssField("float")]
        public CSSFloat Float { get; set; }
        
        [CssField("font")]
        public CSSFont Font { get; set; }
        
        [CssField("left")]
        public CSSNumber Left { get; set; }
        
        [CssField("right")]
        public CSSNumber Right { get; set; }
        
        [CssField("width")]
        public CSSNumber Width { get; set; }
        
        [CssField("height")]
        public CSSNumber Height { get; set; }

        public CSSStyleDeclaration()
        {
            Color = new CSSColor();
            Background = new CSSBackground();
            Padding = new CSSPadding();
            Margin = new CSSMargin();
            Border = new CSSBorder();
            Cursor = new CSSCursor();
            Float = new CSSFloat();
            Font = new CSSFont();
            Left = new CSSNumber();
            Right = new CSSNumber();
            Width = new CSSNumber();
            Height = new CSSNumber();
            Display = new CSSDisplay();
            Position = new CSSPosition();
        }
        
        public string GetCssText()
        {
            // TODO: Impl
            return "";
        }
        
        public static CSSStyleDeclaration Parse(Dictionary<string, string> fields)
        {
            var style = new CSSStyleDeclaration();
            var styleType = style.GetType();
            var styleFields = style.ExtractAllFields();
            
            foreach (var keyValuePair in fields)
            {
                var fieldName = keyValuePair.Key.Replace("\r", "");
                var value = keyValuePair.Value;

                if (styleFields.ContainsKey(fieldName))
                {
                    var refType = styleFields[fieldName];
                    var fieldType = refType.PropertyType;
                    var parseMethod = fieldType.GetMethod("Parse");

                    var property = styleType.GetProperty(refType.PropertyPath.FirstOrDefault());
                    var propertyParentInstance = (object)style;
                    
                    for (var i = 1; i < refType.PropertyPath.Count; i++)
                    {
                        var pathToField = refType.PropertyPath[i];

                        propertyParentInstance = property.GetValue(propertyParentInstance, null);
                        property = property.PropertyType.GetProperty(pathToField);
                    }

                    if (value.FirstOrDefault() == ' ')
                    {
                        value = value.Substring(1, value.Length - 1);
                    }

                    var result = parseMethod.Invoke(null, new []{ value });
                    
                    property.SetValue(propertyParentInstance, result);
                }
            }

            return style;
        }


        public object Clone()
        {
          var style = new CSSStyleDeclaration
          {
            Color = this.Color.Clone() as CSSColor,
            Background = Background.Clone() as CSSBackground,
            Padding = Padding.Clone() as CSSPadding,
            Margin = Margin.Clone() as CSSMargin,
            Border = Border.Clone() as CSSBorder,
            Cursor = Cursor.Clone() as CSSCursor,
            Float = Float.Clone() as CSSFloat,
            Font = Font.Clone() as CSSFont,
            Left = Left.Clone() as CSSNumber,
            Right = Right.Clone() as CSSNumber,
            Width = Width.Clone() as CSSNumber,
            Height = Height.Clone() as CSSNumber,
            Display = Display.Clone() as CSSDisplay,
            Position = Position.Clone() as CSSPosition
          };
          
          return style;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Quantum.CSSOM.Common;
using Quantum.CSSOM.Properties;
using Quantum.Extensions;

namespace Quantum.CSSOM
{
    public class CSSStyleDeclaration
    {
        [CssField("color")]
        public CSSColor Color { get; set; }
        
        [CssField("background")]
        public CSSBackground Background { get; set; }

        public CSSStyleDeclaration()
        {
            Color = new CSSColor();
            Background = new CSSBackground();
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
                var fieldName = keyValuePair.Key;
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
                    
                    var result = parseMethod.Invoke(null, new []{ value.Replace(" ", "") });
                    
                    property.SetValue(propertyParentInstance, result);
                }
            }

            return style;
        }
        

    }
}
using System.Collections.Generic;
using Quantum.CSSOM.Common;

namespace Quantum.CSSOM
{
    public class CSSStyleDeclaration
    {
        public CSSColor Color { get; set; }
        
        public string GetCssText()
        {
            // TODO: Impl
            return "";
        }

        public static CSSStyleDeclaration Parse(Dictionary<string, string> fields)
        {
            var style = new CSSStyleDeclaration();
            
            foreach (var keyValuePair in fields)
            {
                var fieldName = keyValuePair.Key;
                var value = keyValuePair.Value;

                if (fieldName == "color")
                {
                    style.Color = CSSColor.Parse(value.Replace(" ", ""));
                }
            }

            return style;
        }
    }
}
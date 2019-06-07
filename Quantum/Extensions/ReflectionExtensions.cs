using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Quantum.CSSOM;
using Quantum.CSSOM.Common;

namespace Quantum.Extensions
{
    internal class CssFieldRef
    {
        public string Path { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public Type PropertyType => PropertyInfo.PropertyType;
        public List<string> PropertyPath { get; set; }
    }

    internal static class ReflectionExtensions
    {
        public static Dictionary<string, CssFieldRef> ExtractAllFields(this CSSStyleDeclaration cssStyleDeclaration)
        {
            var fields = new Dictionary<string, CssFieldRef>();
            var type = cssStyleDeclaration.GetType();

            ExtractAllFields(type, fields);
            
            return fields;
        }

        private static void ExtractAllFields(Type type, Dictionary<string, CssFieldRef> fields, string parentPath = "")
        {
            var props = type.GetProperties()
                .Select(x => new
                {
                    Attr = x.GetCustomAttributes(typeof(CssFieldAttribute), false),
                    Field = x
                })
                .Where(x => x.Attr.Length != 0)
                .ToDictionary(x => ((CssFieldAttribute) x.Attr.FirstOrDefault()).Path, x => x.Field);

            foreach (var keyValuePair in props)
            {
                var pathField = parentPath == string.Empty ? keyValuePair.Key : $"{parentPath}{keyValuePair.Key}";
                var typeField = keyValuePair.Value;
                var funcToUpperCase = new Func<string, string>(x =>
                {
                    if (x.Length <= 0)
                    {
                        return "";
                    }

                    var firstSymbol = x.FirstOrDefault().ToString().ToUpper();
                    var lastSymbols = x.Substring(1, x.Length - 1);
                    var result = $"{firstSymbol}{lastSymbols}";

                    return result;
                });

                var propertyPath = pathField.Split('-').Select(x => funcToUpperCase(x)).ToList();

                fields.Add(pathField, new CssFieldRef
                {
                    Path = pathField,
                    PropertyInfo = typeField,
                    PropertyPath = propertyPath
                });

                ExtractAllFields(typeField.PropertyType, fields, $"{pathField}-");

            }

            Console.WriteLine("123");
        }
    }
}
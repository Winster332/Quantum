using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.CSSOM;
using Quantum.CSSOM.Common;
using Quantum.CSSOM.Properties;
using Xunit;

namespace Quantum.Tests.Parsers
{
    public class CssStyleReflectionTests : QuantumTest
    {
        [Fact]
        public void ReflectionFieldBackgroundTest()
        {
            var type = typeof(CSSBackground);

            var fields = type.GetFields();
            var props = type.GetProperties()
                .Select(x => new
                {
                    Attr = x.GetCustomAttributes(typeof(CssFieldAttribute), false),
                    Field = x
                })
                .Where(x => x.Attr.Length != 0)
                .ToList();
            
            Console.WriteLine("");
        }
        
        public string XXX { get; set; }
        
        [Fact]
        public void ReflectionFieldStyleDeclarationTest()
        {
//            var type = typeof(CSSStyleDeclaration);
//            var fields = new Dictionary<string, object>();
//
//            var props = type.GetProperties()
//                .Select(x => new
//                {
//                    Attr = x.GetCustomAttributes(typeof(CssFieldAttribute), false),
//                    Field = x
//                })
//                .Where(x => x.Attr.Length != 0)
//                .ToDictionary(x => ((CssFieldAttribute) x.Attr.FirstOrDefault()).Path, x => x.Field);
//
//            var property = this.GetType().GetProperty("XXX");
//            property.SetValue(this, "Hello");
            
            Console.WriteLine(XXX);
            
            var hello = new HelloClass();

            var test = hello.GetType().GetProperty("Test");
            var testValue = test.GetValue(hello, null);
            var pxxx = test.PropertyType.GetProperty("XXX");
            
            pxxx.SetValue(testValue, "ONE");
            
            Console.WriteLine("");
        }

        public class TestClass
        {
            public string XXX { get; set; }
        }

        public class HelloClass
        {
            public TestClass Test { get; set; }

            public HelloClass()
            {
                Test = new TestClass();
                Test.XXX = "is null";
            }
        }
    }
}
using System;

namespace Quantum.HTML
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HtmlNameAttribute : Attribute
    {
        public string Name { get; set; }
        
        public HtmlNameAttribute(string name)
        {
            Name = name;
        }
    }
}
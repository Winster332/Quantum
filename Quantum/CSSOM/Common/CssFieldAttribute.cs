using System;

namespace Quantum.CSSOM.Common
{
    public class CssFieldAttribute : Attribute
    {
        public string Path { get; set; }
        
        public CssFieldAttribute(string path)
        {
            Path = path;
        }
    }
}
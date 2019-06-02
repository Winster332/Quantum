using System;

namespace Quantum.DOM.Exceptions
{
    public class IndexSizeError : DOMException
    {
        public IndexSizeError() : base("Index out of size array")
        {
        }
    }
}
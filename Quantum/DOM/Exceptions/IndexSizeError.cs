using System;

namespace Quantum.DOM.Exceptions
{
    public class IndexSizeError : Exception
    {
        public IndexSizeError() : base("index out of size array")
        {
        }
    }
}
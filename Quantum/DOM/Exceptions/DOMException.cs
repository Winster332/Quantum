using System;

namespace Quantum.DOM.Exceptions
{
    public class DOMException : Exception
    {
        public DOMException(string message) : base(message)
        {
        }
    }
}
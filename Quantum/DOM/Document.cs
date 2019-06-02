using System;
using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public class Document : Node
    {
        public string ContentType { get; set; }
        public Document()
        {
            ContentType = "text/html";
        }

        public Range CreateRange()
        {
            var range = new Range(this);

            return range;
        }

//        public void CreateEvent<T>()
//        {
//            var eventType = typeof(T);
//            
//            AddEventListener<T>();
//        }
    }
}
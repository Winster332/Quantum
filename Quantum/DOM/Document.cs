using System;
using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public class Document : EventTarget
    {
        public string ContentType { get; set; }
        public Document()
        {
            ContentType = "text/html";
        }

//        public void CreateEvent<T>()
//        {
//            var eventType = typeof(T);
//            
//            AddEventListener<T>();
//        }
    }
}
using System.Collections.Generic;
using Quantum.DOM;
using Quantum.DOM.Events;
using Quantum.HTML.Events;

namespace Quantum.HTML
{
    public class HTMLFormElement : HTMLElement
    {
        public long Length => Elements.Count + ChildNodes.Count;
        public HTMLFormControlsCollection Elements { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string Target { get; set; }
        public string Action { get; set; }
        public DOMEventHandler<HTMLFormEventReset> OnReset;
        public DOMEventHandler<HTMLFormEventSubmit> OnSubmit;

        public HTMLFormElement()
        {
            Init("FORM");
            
            Elements = new HTMLFormControlsCollection();
            OnReset = new DOMEventHandler<HTMLFormEventReset>(this);
            OnSubmit = new DOMEventHandler<HTMLFormEventSubmit>(this);
        }

        public void Submit()
        {
            // TODO: Impl
        }
        
        public void Reset()
        {
            // TODO: Impl
        }
    }
}
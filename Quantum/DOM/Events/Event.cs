using System;

namespace Quantum.DOM.Events
{
    public class Event<TEventHandler> where TEventHandler : class
    {
        public bool Bubbles { get; set; }
        public bool CancelBubble { get; set; }
        public bool Cancelable { get; set; }
        public bool Composed { get; set; }
        public long TimeStamp { get; set; }
        public object Instance { get; set; }
        public Type Type => typeof(TEventHandler);
        public bool IsTrusted { get; set; }

        public void CreateEvent()
        {
        }

        public void PreventDefault()
        {
        }

        public void StopImmediatePropagation()
        {
        }

        public void StopPropagation()
        {
        }
    }
}
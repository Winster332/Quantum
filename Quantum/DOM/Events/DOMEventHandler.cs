using System;
using System.Collections.Generic;

namespace Quantum.DOM.Events
{
    public class DOMEventHandler<T> where T : class
    {
        private EventTarget _eventTarget;
        public DOMEventHandler(EventTarget eventTarget)
        {
            _eventTarget = eventTarget;
        }

        public static DOMEventHandler<T> operator +(DOMEventHandler<T> handler, Action<Event<T>> action)
        {
            handler._eventTarget.AddEventListener(action);

            return handler;
        }
        
        public static DOMEventHandler<T> operator -(DOMEventHandler<T> handler)
        {
            handler._eventTarget.RemoveEventListener<T>();

            return handler;
        }

        public void Invoke(Event<T> @event)
        {
            _eventTarget.DispatchEvent(@event);
        }
    }
}
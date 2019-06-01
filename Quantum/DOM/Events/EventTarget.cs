using System;
using System.Collections.Generic;

namespace Quantum.DOM.Events
{
    public class EventTarget
    {
        private Dictionary<Type, List<object>> _eventList { get; set; }

        public EventTarget()
        {
            _eventList = new Dictionary<Type, List<object>>();
        }
        
        public void AddEventListener<T>(Action<Event<T>> eventCallback) where T : class
        {
            var eventType = typeof(T);

            if (_eventList.ContainsKey(eventType))
            {
                _eventList[eventType].Add(eventCallback);
            }
            else
            {
//                if (_eventList[eventType] == null)
//                {
//                    _eventList.Add(eventType, eventCallback);
//                    _eventList[eventType] = new List<object>();
//                }

                _eventList.Add(eventType, new List<object> { eventCallback });
            }
        }
        
        public void RemoveEventListener<T>() where T : class
        {
            var eventType = typeof(T);

            _eventList.Remove(eventType);
        }

        public void DispatchEvent<T>(Event<T> @event) where T : class
        {
            var eventType = typeof(T);
            
            if (_eventList.ContainsKey(eventType))
            {
                var eventListeners = _eventList[eventType];
                
                for (var i = 0; i < eventListeners.Count; i++)
                {
                    var callBack = (Action<Event<T>>) eventListeners[i];
                    callBack(@event);
                }
            }
            else
            {
                throw new ArgumentException($"{eventType} is not defined");
            }
        }
    }
}
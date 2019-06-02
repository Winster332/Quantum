using Quantum.DOM.Events;

namespace Quantum.CSSOM.Events
{
    public class AnimationEvent<TEventHandler> : Event<TEventHandler> where TEventHandler : class
    {
        public string AnimationName { get; set; }
        public float ElapsedTime { get; set; }
        public string PseudoElement { get; set; }
    }
}
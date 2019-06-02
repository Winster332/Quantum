using System;

namespace Quantum.Parser.Common
{
    public abstract class StateMachine<T> where T : StateMachineInstance
    {
        protected string _htmlSource;
        protected int _currentIndex;
        protected int _maxIndex;
        protected int _step;
        public T Instance { get; set; }

        public StateMachine(string source)
        {
            _htmlSource = source;
            _currentIndex = 0;
            _step = 1;
            _maxIndex = source.Length-1;
            Instance = (T) Activator.CreateInstance(typeof(T));
        }
        
        public void Run()
        {
            for (_currentIndex = 0; _currentIndex <= _maxIndex; _currentIndex += _step)
            {
                var symbol = _htmlSource[_currentIndex];
                
                Instance.Update(symbol, _currentIndex);
                ResolveSymbol();
            }
        }

        public abstract void ResolveSymbol();
        
    }
}
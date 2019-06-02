using System;

namespace Quantum.Parser.Common
{
    public abstract class StateMachineInstance
    {
        public int Version { get; set; }
        public char? FirstSymbol { get; set; }
        public int FirstIndex { get; set; }
        public int LastIndex { get; set; }
        public char LastSymbol { get; set; }
        protected bool _isCommit;
        public event EventHandler<int> OnUpdate;

        public StateMachineInstance()
        {
            Version = 1;
            _isCommit = false;
        }
        
        public void Commit()
        {
            Version++;
            _isCommit = true;
        }

        public void Update(char symbol, int index)
        {
            if (_isCommit)
            {
                _isCommit = false;

                FirstIndex = index;
                FirstSymbol = symbol;
            }

            LastIndex = index;
            LastSymbol = symbol;
            
            OnUpdate?.Invoke(this, Version);
        }
    }
}
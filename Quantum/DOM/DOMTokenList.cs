using System;
using System.Collections.Generic;
using System.Linq;

namespace Quantum.DOM
{
    public class DOMTokenList
    {
        private List<string> _list;
//        private List<string> _list => Value.Split(' ').ToList();
        public int Length => _list.Count;
        public string Value { get; set; }
        
        public DOMTokenList()
        {
            _list = new List<string>();
            Value = string.Empty;
        }

        public string Item(int index)
        {
            if (index >= 0 && index < Length)
            {
                return _list[index];
            }

            return null;
        }

        public bool Contains(string token)
        {
            return _list.Contains(token);
        }

        public void Add(string token)
        {
            _list.Add(token);
            
            RefreshValue();
        }

        public void Remove(string token)
        {
            _list.Remove(token);
            
            RefreshValue();
        }

        public void Replace(string oldToken, string newToken)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i] == oldToken)
                {
                    _list[i] = newToken;
                }
            }
        }

        public bool Toggle(string token)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i] == token)
                {
                    _list.RemoveAt(i);
                    
                    return false;
                }
            }
            
            _list.Add(token);

            return true;
        }

        public List<string> Entries()
        {
            return _list;
        }

        public void ForEach(Action<string> callback)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                callback(_list[i]);
            }
        }

        private void RefreshValue()
        {
            Value = string.Join(" ", _list);
        }
    }
}
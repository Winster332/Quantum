using System.Collections.Generic;
using System.Linq;

namespace Quantum.DOM
{
    public class Storage
    {
        private Dictionary<string, object> _data;
        public int Length => _data.Count;

        public Storage()
        {
            _data = new Dictionary<string, object>();
        }

        public string Key(int n)
        {
            var keys = _data.Keys.ToArray();

            if (n < Length)
            {
                return keys[n];
            }

            return null;
        }

        public T GetItem<T>(string name) where T : class
        {
            if (_data.ContainsKey(name))
            {
                return _data[name] as T;
            }

            return null;
        }

        public void SetItem(string name, object value)
        {
            if (!_data.ContainsKey(name))
            {
                _data.Add(name, value);
            }
            else
            {
                _data[name] = value;
            }
        }

        public void RemoveItem(string name)
        {
            _data.Remove(name);
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}
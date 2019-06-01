using System.Collections.Generic;
using System.Linq;

namespace Quantum.DOM
{
    public class HTMLCollection<T> : Dictionary<string, T> where T : class
    {
        
        public HTMLCollection()
        {
        }

        public T NamedItem(string name)
        {
            if (this.ContainsKey(name))
            {
                return base[name];
            }

            return null;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return this.ToList()[index].Value;
                }

                return null;
            }
        }
        
        public new T this[string name]
        {
            get
            {
                return NamedItem(name);
            }
            set { this[name] = value; }
        }
    }
}
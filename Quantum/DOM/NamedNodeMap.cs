using System.Collections.Generic;
using System.Linq;

namespace Quantum.DOM
{
    public class NamedNodeMap
    {
        private Dictionary<string, Attr> _attrs;
        public int Length => _attrs.Count;

        public NamedNodeMap()
        {
            _attrs = new Dictionary<string, Attr>();
        }

        public Attr GetNamedItem(string name)
        {
            if (_attrs.ContainsKey(name))
            {
                return _attrs[name];
            }

            return null;
        }

        public Attr GetNamedItemNS(string localName)
        {
            if (_attrs.ContainsKey(localName))
            {
                return _attrs[localName];
            }

            return null;
        }
        
        public void SetNamedItem(Attr attr)
        {
            if (_attrs.ContainsKey(attr.Name))
            {
                _attrs[attr.Name] = attr;
            }

            _attrs.Add(attr.Name, attr);
        }

        public void SetNamedItemNS(Attr attr)
        {
            if (_attrs.ContainsKey(attr.LocalName))
            {
                _attrs[attr.LocalName] = attr;
            }

            _attrs.Add(attr.LocalName, attr);
        }

        public void RemoveNamedItem(string name)
        {
            if (_attrs.ContainsKey(name))
            {
                _attrs.Remove(name);
            }
        }

        public void RemoveNamedItemNS(string name)
        {
            if (_attrs.ContainsKey(name))
            {
                _attrs.Remove(name);
            }
        }

        public Attr Item(int index)
        {
            if (index >= 0 && index < Length)
            {
                return _attrs.ToList()[index].Value;
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;

namespace Quantum.Parser.HTML
{
    public class HtmlStack
    {
        private List<ProcessorRule> _nodes;
        
        public HtmlStack()
        {
            _nodes = new List<ProcessorRule>();
        }

        public void Push(ProcessorRule node)
        {
            _nodes.Add(node);
        }
        
        public ProcessorRule Pop(string name)
        {
            ProcessorRule node = null;
            for (var i = _nodes.Count-1; i >= 0; i--)
            {
                var item = _nodes[i];

                if (item.NodeName.ToLower() == name.ToLower())
                {
                    node = item;
                    _nodes.RemoveAt(i);
                    break;
                }
            }

            return node;
        }

        public ProcessorRule GetLast()
        {
            var node = _nodes.LastOrDefault();
            return node;
        }

        public ProcessorRule Pop()
        {
            var node = _nodes.LastOrDefault();
            _nodes.RemoveAt(_nodes.Count - 1);

            return node;
        }
    }
}
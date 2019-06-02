using System;
using System.Collections.Generic;
using Quantum.DOM;

namespace Quantum.Parser.HTML
{
    public class HtmlElementResolver
    {
        public Dictionary<string, Type> DictionaryNodes { get; set; }
        public List<Node> Nodes { get; set; }

        public HtmlElementResolver()
        {
            Nodes = new List<Node>();
            DictionaryNodes = new Dictionary<string, Type>();
            
        }
        
        public Node Factory(string tag)
        {
            var node = new Node();
            return node;
        }
    }
}
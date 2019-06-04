using System;
using System.Linq;
using Quantum.DOM;

namespace Quantum.Parser.HTML
{
    public class ProcessorRule : Node, ICloneable
    {
        public bool IsOpen { get; set; }
        public bool IsWithoutClosePair { get; set; }
        public int Index { get; set; }
        public ProcessorRule CloseElement { get; set; }
        
        public object Clone()
        {
            var elms = new Node[ChildNodes.Count];
            ChildNodes.CopyTo(elms, 0);
            
            return new ProcessorRule
            {
                NodeType = NodeType,
                IsOpen = IsOpen,
                IsWithoutClosePair = IsWithoutClosePair,
                Index = Index,
                CloseElement = CloseElement?.Clone() as ProcessorRule,
                ParentNode = ParentNode as ProcessorRule,
                ChildNodes = elms.ToList()
            };
        }
    }
}
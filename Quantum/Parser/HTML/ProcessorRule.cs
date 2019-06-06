using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Parser.HTML
{
    public class ProcessorRule : ICloneable
    {
        public string NodeName { get; set; }
        public bool IsOpen { get; set; }
        public bool IsWithoutClosePair { get; set; }
        public int Index { get; set; }
        public ProcessorRule CloseElement { get; set; }
        public List<ProcessorRule> Children { get; set; }
        public Type ElementType { get; set; }
        public HTMLElement ElementInstance { get; set; }
        public ProcessorRule Parent { get; set; }

        public ProcessorRule()
        {
            Children = new List<ProcessorRule>();
        }
        
        public object Clone()
        {
//            var elms = new Node[ChildNodes.Count];
//            ChildNodes.CopyTo(elms, 0);
//            
//            return new ProcessorRule
//            {
//                NodeType = NodeType,
//                IsOpen = IsOpen,
//                IsWithoutClosePair = IsWithoutClosePair,
//                Index = Index,
//                CloseElement = CloseElement?.Clone() as ProcessorRule,
//                ParentNode = ParentNode as ProcessorRule,
//                ChildNodes = elms.ToList()
//            };
            return null;
        }
    }
}
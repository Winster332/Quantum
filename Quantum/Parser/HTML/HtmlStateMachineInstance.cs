using System;
using System.Collections.Generic;
using Quantum.DOM;
using Quantum.Parser.Common;

namespace Quantum.Parser.HTML
{
    [Flags]
    public enum HtmlProcessorStates
    {
        Unknow = 0x0,
        NodeOpen = 0x1, 
        NodeClose = 0x2, 
        ExctractAttributes = 0x4, 
        Initializing = 0x8, 
        ReadText = 0x10,
        Finished = 0x20,
        CommentOpen = 0x21
    }
    
    public class HtmlStateMachineInstance : StateMachineInstance
    {
        public List<Node> Elements { get; set; }
        public HtmlProcessorStates State { get; set; }
        public int DepthLevel { get; set; }

        public HtmlStateMachineInstance()
        {
            DepthLevel = 0;
            State = HtmlProcessorStates.Initializing;
            Elements = new List<Node>();
        }


        public void AddNode(Node element)
        {
//            var element = new HtmlElement { NodeName = nodeName };
            Elements.Add(element);
        }
    }
}
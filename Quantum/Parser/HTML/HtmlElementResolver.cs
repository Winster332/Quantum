using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Parser.HTML
{
    public class ProcessorRule : ICloneable
    {
        public NodeType RuleType { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool IsOpen { get; set; }
        public bool IsWithoutClosePair { get; set; }
        public Node OriginNode { get; set; }
        public int Index { get; set; }
        public ProcessorRule CloseElement { get; set; }
        public ProcessorRule Parent { get; set; }
        public string Value { get; set; }
        public List<ProcessorRule> Elements { get; set; }

        public ProcessorRule()
        {
            RuleType = NodeType.ElementNode;
            Elements = new List<ProcessorRule>();
        }
        
        public object Clone()
        {
            var elms = new ProcessorRule[Elements.Count];
            Elements.CopyTo(elms, 0);
            
            return new ProcessorRule
            {
                Name = Name.Clone().ToString(),
                Type = Type,
                IsOpen = IsOpen,
                IsWithoutClosePair = IsWithoutClosePair,
                Index = Index,
                CloseElement = CloseElement?.Clone() as ProcessorRule,
                Parent = Parent?.Clone() as ProcessorRule,
                Elements = elms.ToList()
            };
        }
    }

    public class HtmlElementResolver
    {
        public HtmlStack HtmlStack { get; set; }
        public Dictionary<string, ProcessorRule> DictionaryNodes { get; set; }
        public List<ProcessorRule> Instructions { get; set; }
        private int _totalIndex = -1;

        public HtmlElementResolver()
        {
            Instructions = new List<ProcessorRule>();
            DictionaryNodes = new Dictionary<string, ProcessorRule>();
            HtmlStack = new HtmlStack();
            
            InitDictionary();
        }

        private void InitDictionary()
        {
            AddRule<HTMLDivElement>("<div>");
            AddRule<HTMLLinkElement>("<a>");
            AddRule<HTMLDivElement>("</div>", false);
            AddRule<HTMLLinkElement>("</a>", false);
            AddRule<HTMLInputElement>("<input>", false, true);
            AddRule<HTMLInputElement>("#text", false, true);
//            AddRule<Comment>("<!-->", false);
        }

        private void AddRule<T>(string tag, bool isOpen = true, bool isWithoutCloseTag = false)
        {
            DictionaryNodes.Add(tag, new ProcessorRule
            {
                Name = tag,
                Type = typeof(T),
                IsWithoutClosePair = isWithoutCloseTag,
                IsOpen = isOpen
            });
        }
        
        public Node FactoryElements(string text)
        {
            var nodeRule = DetectNode(text);

            if (nodeRule != null)
            {
                if (nodeRule.IsWithoutClosePair)
                {
                    Console.WriteLine("123");
                }
            }

            return null;
        }

        public void FactoryText(string text)
        {
            var nodeRule = DetectNode("#text");
            nodeRule.Value = text;
//            Instructions.Add(new ProcessorRule
//            {
//                Name = "#text",
//                Type = typeof(Text),
//                RuleType = NodeType.TextNode,
//                IsWithoutClosePair = false,
//                IsOpen = false
//            });
        }

        private ProcessorRule DetectNode(string text)
        {
            var node = default(ProcessorRule);
            if (DictionaryNodes.ContainsKey(text))
            {
                node = GetNode(text);
                node.OriginNode = new Node
                {
                    NodeType = NodeType.ElementNode,
                    NodeName = text
                };
                node.Index = _totalIndex+1;
                Instructions.Add(node);
                _totalIndex++;

//                HtmlStack.Push(node);
            }
            else
            {
                Instructions.Add(null);
            }

            return node;
        }

        private ProcessorRule GetNode(string text)
        {
            var tag = DictionaryNodes[text].Clone() as ProcessorRule;
            
            return tag;
        }
        
        public List<ProcessorRule> CreateTree(List<ProcessorRule> elements)
        {
            var stackOpenElements = new HtmlStack();
            var currentLevel = 0;

            for (var i = 0; i < elements.Count; i++)
            {
                var element = elements[i];

                if (element.IsOpen || element.IsWithoutClosePair)
                {
                    stackOpenElements.Push(element);
                }

                if (!element.IsOpen || element.IsWithoutClosePair)
                {
                    var openedElement = default(ProcessorRule);

                    if (element.IsWithoutClosePair)
                    {
                        openedElement = stackOpenElements.Pop(element.OriginNode.NodeName);
                    }
                    else
                    {
                        openedElement =
                            stackOpenElements.Pop(
                                $"<{element.OriginNode.NodeName.Substring(2, element.OriginNode.NodeName.Length - 2)}");
                    }

                    if (openedElement != null)
                    {
                        openedElement.CloseElement = element;

                        GetChildren(openedElement, openedElement.CloseElement, elements);
                    }
                }
            }
            
            var roots = elements.Where(x => x.Parent == null && x.IsOpen).ToList();

            return roots;
        }

        private bool GetChildren(ProcessorRule openElement, ProcessorRule closeElement, List<ProcessorRule> elements)
        {
            if (openElement == null || closeElement == null || elements.Count == 0)
            {
                return false;
            }
            
            var result = new List<ProcessorRule>();
            var startIndex = openElement.Index+1;
            var endIndex = closeElement.Index;

            for (var i = startIndex; i < endIndex; i++)
            {
                var element = elements[i];
                
                if (element.Parent == null)
                {
                    element.Parent = openElement;

                    if (element.IsOpen || element.IsWithoutClosePair)
                    {
                        openElement.Elements.Add(element);
                    }
                }
            }

            return true;
        }
    }
}
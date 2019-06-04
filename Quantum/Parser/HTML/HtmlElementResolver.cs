using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Parser.HTML
{
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
                NodeName = tag,
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
            nodeRule.NodeType = NodeType.TextNode;
            nodeRule.NodeValue = text;
            nodeRule.TextContent = text;
        }

        public void AttachAttributes(List<Attr> attrs)
        {
            foreach (var attr in attrs)
            {
                Instructions[Instructions.Count - 1].Attributes.SetNamedItem(attr);
            }
        }

        private ProcessorRule DetectNode(string text)
        {
            var node = default(ProcessorRule);
            if (DictionaryNodes.ContainsKey(text))
            {
                node = GetNode(text);
                node.NodeName = text;
                node.NodeType = NodeType.ElementNode;
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
                        openedElement = stackOpenElements.Pop(element.NodeName);
                    }
                    else
                    {
                        openedElement =
                            stackOpenElements.Pop(
                                $"<{element.NodeName.Substring(2, element.NodeName.Length - 2)}");
                    }

                    if (openedElement != null)
                    {
                        openedElement.CloseElement = element;

                        GetChildren(openedElement, openedElement.CloseElement, elements);
                    }
                }
            }
            
            var roots = elements.Where(x => x.ParentNode == null && x.IsOpen).ToList();

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
                
                if (element.ParentNode == null)
                {
                    element.ParentNode = openElement;

                    if (element.IsOpen || element.IsWithoutClosePair)
                    {
                        openElement.ChildNodes.Add(element);
                    }
                }
            }

            return true;
        }
    }
}
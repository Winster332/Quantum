using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Parser.HTML
{
    public class HtmlElementResolver
    {
        private CssLoader _cssLoader;
        public HtmlStack HtmlStack { get; set; }
        public event EventHandler<HTMLElement> ElementComplated;
        public Dictionary<string, ProcessorRule> DictionaryNodes { get; set; }
        public Dictionary<string, Action<string>> ActionsRules { get; set; }
        public List<ProcessorRule> Instructions { get; set; }
        private int _totalIndex = -1;

        public HtmlElementResolver()
        {
            Instructions = new List<ProcessorRule>();
            DictionaryNodes = new Dictionary<string, ProcessorRule>();
            ActionsRules = new Dictionary<string, Action<string>>();
            HtmlStack = new HtmlStack();
            _cssLoader = new CssLoader();
            
            InitDictionary();
        }

        private void InitDictionary()
        {
            AddActionOnTag("<!doctype>", s => Console.WriteLine($"Detected: {s}"));
            
            AddRule<HTMLDivElement>("<div>");
            AddRule<HTMLDivElement>("</div>", false);
            
            AddRule<HTMLLinkElement>("<link>", false, true);
//            AddRule<HTMLLinkElement>("</link>", false);
            
            AddRule<HTMLScriptElement>("<script>");
            AddRule<HTMLScriptElement>("</script>", false);
            
            AddRule<HTMLHtmlElement>("<html>");
            AddRule<HTMLHtmlElement>("</html>", false);
            
            AddRule<HTMLBodyElement>("<body>");
            AddRule<HTMLBodyElement>("</body>", false);
            
            AddRule<HTMLHeadElement>("<head>");
            AddRule<HTMLHeadElement>("</head>", false);
            
            AddRule<HTMLMetaElement>("<meta>",  false, true);
            
            AddRule<HTMLTitleElement>("<title>");
            AddRule<HTMLTitleElement>("</title>", false);
            
            AddRule<HTMLButtonElement>("<button>");
            AddRule<HTMLButtonElement>("</button>", false);
            
            AddRule<HTMLInputElement>("<input>", false, true);
            AddRule<HTMLTextElement>("#text", false, true);
//            AddRule<Comment>("<!-->", false);
        }

        private void AddRule<T>(string tag, bool isOpen = true, bool isWithoutCloseTag = false)
        {
            DictionaryNodes.Add(tag, new ProcessorRule
            {
                NodeName = tag,
                IsWithoutClosePair = isWithoutCloseTag,
                IsOpen = isOpen,
                ElementInstance = null,
                ElementType = typeof(T)
            });
        }

        private void AddActionOnTag(string tag, Action<string> callback)
        {
            ActionsRules.Add(tag, callback);
        }

        public Node FactoryElements(string text)
        {
            if (ActionsRules.ContainsKey(text.ToLower()))
            {
                ActionsRules[text.ToLower()].Invoke(text);
                return null;
            }

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
            nodeRule.ElementInstance.NodeType = NodeType.TextNode;
            nodeRule.ElementInstance.NodeValue = text;
            nodeRule.ElementInstance.TextContent = text;
        }

        public void AttachAttributes(List<Attr> attrs)
        {
            foreach (var attr in attrs)
            {
                if (Instructions.Count == 0)
                {
                    continue;
                }

                if (Instructions[Instructions.Count - 1] == null)
                {
                    Console.Error.WriteLine("Attr");
                    continue;
                }

                Instructions[Instructions.Count - 1].ElementInstance.Attributes.SetNamedItem(attr);
            }
        }

        private ProcessorRule DetectNode(string text)
        {
            var node = default(ProcessorRule);
            if (DictionaryNodes.ContainsKey(text))
            {
                node = GetNode(text);
                node.NodeName = text;
                node.ElementInstance.NodeName = text;
                node.ElementInstance.NodeType = NodeType.ElementNode;
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
//            var tag = DictionaryNodes[text].Clone() as ProcessorRule;
            var element = DictionaryNodes[text];
            var tag = new ProcessorRule();
            tag.ElementType = element.ElementType;
            tag.Index = element.Index;
            tag.CloseElement = element.CloseElement;
            tag.NodeName = element.NodeName;
            tag.Children = new List<ProcessorRule>();
            tag.IsWithoutClosePair = element.IsWithoutClosePair;
            tag.IsOpen = element.IsOpen;
            tag.ElementInstance = Activator.CreateInstance(tag.ElementType) as HTMLElement;

            if (tag.ElementInstance == null)
            {
                tag.ElementInstance = new HTMLUnknownElement();
            }

            return tag;
        }
        
        public List<ProcessorRule> CreateTree(List<ProcessorRule> elements)
        {
            var stackOpenElements = new HtmlStack();
            var currentLevel = 0;

            for (var i = 0; i < elements.Count; i++)
            {
                var element = elements[i];

                if (element == null)
                {
                    Console.Error.WriteLine($"Not found element [{element}]");
                    continue;
                }

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
                    
                        ElementComplated?.Invoke(this, openedElement.ElementInstance);
                    }
                }
            }
            
            var roots = elements.Where(x => x != null && x.Parent == null && x.IsOpen).ToList();

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

                if (element == null)
                {
                    continue;
                }

                if (element.Parent == null)
                {
                    element.Parent = openElement;
                    
                    if (element.IsOpen || element.IsWithoutClosePair)
                    {
                        openElement.Children.Add(element);
                        openElement.ElementInstance.AppendChild(element.ElementInstance);
                    }
                }
            }

            return true;
        }
    }
}
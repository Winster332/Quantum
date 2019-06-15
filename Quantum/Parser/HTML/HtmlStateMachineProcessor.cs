using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Quantum.DOM;
using Quantum.HTML;
using Quantum.HTML.Elements;
using Quantum.HTML.Elements.EmbeddedTextSemantics;
using Quantum.HTML.Elements.Forms;
using Quantum.HTML.Elements.Interactive;
using Quantum.HTML.Elements.Media;
using Quantum.HTML.Elements.Metadata;
using Quantum.HTML.Elements.Scripting;
using Quantum.HTML.Elements.Text;
using Quantum.Parser.Common;

namespace Quantum.Parser.HTML
{
    public class HtmlStateMachineProcessor : StateMachine<HtmlStateMachineInstance>
    {
        public event EventHandler<string> DetectedNode; 
        public event EventHandler<string> DetectedText;
        public event EventHandler<List<Attr>> DetectedAttr;
        public event EventHandler StartedProcessing;
        public event EventHandler StoppedProcessing;

        public const char CharacterOpenNode = '<';
        public const char CharacterCloseNode = '>';
        public Document Document { get; set; }
        
        public Dictionary<string, Type> DomElements { get; set; }
        public Dictionary<string, Action<string, List<Attr>>> RuleActions { get; set; }
        public Stack<HTMLElement> OpennedElements { get; set; }
            
        public HtmlStateMachineProcessor(string source) : base(source)
        {
            OpennedElements = new Stack<HTMLElement>();
            DomElements = new Dictionary<string, Type>();
            RuleActions = new Dictionary<string, Action<string, List<Attr>>>();
            Document = new Document();
            
            AddRule("!doctype", (tag, attrs) =>
            {
                Document.DocType = new DocumentType(Document);
                Document.DocType.Name = attrs.FirstOrDefault()?.Value;
            });
            
            #region Embedded text semantic
            
            AddRule<HTMLAnchorElement>();
            AddRule<HTMLQuoteElement>();
            AddRule<HTMLSpanElement>();
            
            #endregion
            
            #region Forms
            
            AddRule<HTMLButtonElement>();
            AddRule<HTMLFormElement>();
            AddRule<HTMLInputElement>();
            AddRule<HTMLLabelElement>();
            
            #endregion
            
            #region Ineractive
            
            AddRule<HTMLMenuElement>();
            
            #endregion
            
            #region Media
            
            AddRule<HTMLImageElement>();
            
            #endregion
            
            #region Metadata
            
            AddRule<HTMLHeadElement>();
            AddRule<HTMLLinkElement>();
            AddRule<HTMLMetaElement>();
            AddRule<HTMLStyleElement>();
            AddRule<HTMLTitleElement>();
            
            #endregion
            
            #region Scripting
            
            AddRule<HTMLCanvasElement>();
            AddRule<HTMLScriptElement>();
            
            #endregion
            
            #region Text
            
            AddRule<HTMLDivElement>();
            AddRule<HTMLParagraphElement>();
            AddRule<HTMLPreElement>();
            
            #endregion
            
            #region Base
            
            AddRule<HTMLBodyElement>();
            AddRule<HTMLHtmlElement>();
            AddRule<HTMLOutputElement>();
            
            #endregion
        }

        private void AddRule<T>() where T : class
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttributes(typeof(HtmlNameAttribute), false).FirstOrDefault() as HtmlNameAttribute;

            if (attribute != null)
            {
                var name = attribute.Name;

                DomElements.Add(name, type);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void AddRule(string tag, Action<string, List<Attr>> callback)
        {
            RuleActions.Add(tag, callback);
        }

        public override void ResolveSymbol()
        {
            if (_currentIndex == 0)
            {
                BeginProcessing();
            }

            if (_currentIndex == _maxIndex)
            {
                EndProcessing();
            }

            if (Instance.LastSymbol == CharacterOpenNode)
            {
                var text = _htmlSource
                    .Substring(Instance.IndexOpenNode, Instance.LastIndex - Instance.IndexOpenNode + 1)
                    .Replace(">", "")
                    .Replace("<", "");
                
                if (CheckOnText(text))
                {
                    ResolveTextElement(text);
                }

                Instance.IndexOpenNode = Instance.LastIndex;
                Instance.Commit();
            }

            if (Instance.LastSymbol == CharacterCloseNode)
            {
                var sourceElement = _htmlSource.Substring(Instance.IndexOpenNode, Instance.LastIndex - Instance.IndexOpenNode+1);
                
                DetectElement(sourceElement);
                
                Instance.IndexOpenNode += sourceElement.Length-1;
                Instance.Commit();
            }
        }

        private bool CheckOnText(string text)
        {
            if (text.Length == 1)
            {
                var symbol = text.FirstOrDefault();
                
                if (symbol == CharacterOpenNode || symbol == CharacterCloseNode)
                {
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(text.Replace("\n", "")))
            {
                return true;
            }

            return false;
        }

        private void ResolveTextElement(string source)
        {
            var textElement = new HTMLTextElement();
            textElement.TextContent = source;
            textElement.NodeType = NodeType.TextNode;
            textElement.OwnerDocument = Document;

            var openElement = default(HTMLElement);

            if (OpennedElements.Count != 0)
            {
                openElement = OpennedElements.Pop();
            }

            if (openElement != null)
            {
                openElement.AppendChild(textElement);
                OpennedElements.Push(openElement);
            }
            else
            {
                Document.AppendChild(textElement);
            }
        }

        private void DetectElement(string source)
        {
            source = source.Substring(1, source.Length - 2);
            var tag = source.Split(' ').First().ToLower();
            var attrs = ResolveAttributes(source, tag);
            
            if (RuleActions.ContainsKey(tag))
            {
                var action = RuleActions[tag];
                action.Invoke(tag, attrs);
            }
            else if (tag.FirstOrDefault() == '/')
            {
                var element = OpennedElements.Pop();
            }
            else if (source.LastOrDefault() == '/')
            {
                var elementType = DomElements[tag];
                var elementInstance = Activator.CreateInstance(elementType) as HTMLElement;

                if (elementInstance != null)
                {
                    elementInstance.IsNeedClose = false;
                }

                ResolveElement(elementInstance, elementType, tag, attrs);
            }
            else if (DomElements.ContainsKey(tag))
            {
                var elementType = DomElements[tag];
                var elementInstance = Activator.CreateInstance(elementType) as HTMLElement;

                ResolveElement(elementInstance, elementType, tag, attrs);
            }
        }

        private void ResolveElement(HTMLElement elementInstance, Type elementType, string tag, List<Attr> attrs)
        {
            if (elementInstance == null)
            {
                Console.WriteLine($"Error created instance {elementType} for {tag}");
            }
            else
            {
                var openElement = default(HTMLElement);

                if (OpennedElements.Count != 0)
                {
                    openElement = OpennedElements.Pop();
                }

                elementInstance.NodeName = tag;
                elementInstance.OwnerDocument = Document;
                attrs?.ForEach(x => elementInstance.Attributes.SetNamedItem(x));
                Instance.Elements.Add(elementInstance);

                if (openElement != null)
                {
                    openElement.AppendChild(elementInstance);
                    OpennedElements.Push(openElement);
                }
                else
                {
                    Document.AppendChild(elementInstance);
                }

                if (elementInstance.IsNeedClose)
                {
                    OpennedElements.Push(elementInstance);
                }
            }
        }

        private List<Attr> ResolveAttributes(string source, string tag)
        {
            var attrs = new List<Attr>();
            
            if (source.Length != tag.Length)
            {
                var sourceAttrs = source.Substring(tag.Length + 1, source.Length - tag.Length - 1);

                attrs = ParseAttributes(sourceAttrs);
            }

            return attrs;
        }

        private void BeginProcessing()
        {
            Instance.State = HtmlProcessorStates.FindNode;
            StartedProcessing?.Invoke(this, null);
        }

        private void EndProcessing()
        {
//            var nodeName = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
//            AddElementToInstance(nodeName);
//            Instance.State = HtmlProcessorStates.Finished;
//            Instance.Commit();
            
            StoppedProcessing?.Invoke(this, null);
        }

        private List<Attr> ParseAttributes(string source)
        {
            var current = "";
            var isOpenCell = false;
            var attributes = new List<string>();
            
            for (var i = 0; i < source.Length; i++)
            {
                var symbol = source[i];
                current += symbol;

                if (symbol == '"')
                {
                    isOpenCell = !isOpenCell;
                }

                if (symbol == ' ' && !isOpenCell || i == source.Length - 1)
                {
                    if (current.Last() == ' ')
                        current = current.Substring(0, current.Length - 1);
                    attributes.Add(current);
                    current = "";
                }
            }

            var result = new List<Attr>();
            attributes.Select(x => new
            {
                Pair = x.Split('=')
            }).ToList().ForEach(x =>
            {
                var key = x.Pair.FirstOrDefault();
                var value = x.Pair.LastOrDefault();

                if (value == null)
                {
                    result.Add(new Attr
                    {
                        Prefix = key,
                    });
                }
                else
                {
                    result.Add(new Attr
                    {
                        Name = key,
                        Value = value
                    });
                }
            });

            return result;
        }
    }
}
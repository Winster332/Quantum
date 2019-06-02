using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.Parser.Common;

namespace Quantum.Parser.HTML
{
    public class HtmlStateMachineProcessor : StateMachine<HtmlStateMachineInstance>
    {
        public event EventHandler<string> DetectedNode; 
        public event EventHandler<string> DetectedText;
        public event EventHandler StartedProcessing;
        public event EventHandler StoppedProcessing;
        public HtmlStateMachineProcessor(string source) : base(source)
        {
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

            if (Instance.LastSymbol == '<')
            {
                OpenNode();
            }
            
            if (Instance.LastSymbol == '>')
            {
                CloseNode();
            }

            if (Instance.LastSymbol == ' ')
            {
                DetectSpace();
            }
        }
        
        public void BeginProcessing()
        {
            Console.WriteLine("BEGIN HTML Processing");
            StartedProcessing?.Invoke(this, null);
        }

        public void EndProcessing()
        {
            var nodeName = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
            AddElementToInstance(nodeName);
            Instance.State = HtmlProcessorStates.Finished;
            Instance.Commit();
            
            StoppedProcessing?.Invoke(this, null);
            Console.WriteLine("END HTML Processing");
        }

        public void OpenNode()
        {
            Instance.State = HtmlProcessorStates.NodeOpen;
            var content = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);

            if (!string.IsNullOrWhiteSpace(content))
            {
                AddTextToInstance(content);
                DetectedText?.Invoke(this, content);
            }

            Instance.Commit();
        }
        
        public void CloseNode()
        {
            if (Instance.State == HtmlProcessorStates.NodeOpen)
            {
                var nodeName = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
                AddElementToInstance(nodeName);
                Instance.State = HtmlProcessorStates.ReadText;
                Instance.Commit();
                
                DetectedNode?.Invoke(this, nodeName);
            }
            else if (Instance.State == (HtmlProcessorStates.NodeOpen | HtmlProcessorStates.ExctractAttributes))
            {
                var attributesSource = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
//                var attributes = ParseAttributes(attributesSource);
//                ((Element)Instance.Elements.Last()).AddAtribute(attributes);

                //TODO: ATTRIB
                Instance.State = HtmlProcessorStates.NodeClose;
                Instance.Commit();
            }
        }

        public List<Attr> ParseAttributes(string source)
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
//                    result.Add(new Attr
//                    {
//                        Type = HtmlElementAttributeType.Flag,
//                        Flag = key
//                    });
                }
                else
                {
//                    result.Add(new HtmlElementAttribute
//                    {
//                        Type = HtmlElementAttributeType.Parameter,
//                        Key = key,
//                        Value = value
//                    });
                }
            });

            return result;
        }

        public void AddTextToInstance(string text)
        {
            Instance.AddNode(new Node 
            {
                NodeType = NodeType.TextNode,
//                Index = Instance.Elements.Count,
//                Depth = Instance.DepthLevel,
//                Text = text
            });
        }
        public void AddElementToInstance(string name)
        {
//            if (name.First() != '/')
//            {
//                Instance.DepthLevel++;
//            }

            Instance.AddNode(new Node 
            {
                NodeType = NodeType.ElementNode,
//                Id = Guid.NewGuid(),
//                Index = Instance.Elements.Count,
//                Depth = Instance.DepthLevel,
                NodeName = name
            });
            
//            if (name.First() == '/')
//            {
//                Instance.DepthLevel--;
//            }
        }

        public void DetectSpace()
        {
            if (Instance.State == HtmlProcessorStates.NodeOpen)
            {
                var nodeName = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
                Instance.State = HtmlProcessorStates.NodeOpen | HtmlProcessorStates.ExctractAttributes;
                
                AddElementToInstance(nodeName);
                Instance.Commit();
                
                DetectedNode?.Invoke(this, nodeName);
            }
        }
    }
}
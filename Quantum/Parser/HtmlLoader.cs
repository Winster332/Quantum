using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Quantum.CSSOM;
using Quantum.DOM;
using Quantum.Extensions;
using Quantum.HTML;
using Quantum.Parser.HTML;

namespace Quantum.Parser
{
    public class HtmlLoader
    {
        private HtmlStateMachineProcessor _stateMachine;
        public List<HTMLElement> LoadSource(string source, Assembly assembly)
        {
            var list = new List<string>();
            var resolver = new HtmlElementResolver();
            var window = new Window();
            window.Document = new Document();
            
            _stateMachine = new HtmlStateMachineProcessor(source);
            _stateMachine.DetectedNode += (sender, s) =>
            {
                var tag = $"<{s}>";
                
                list.Add(tag);
                resolver.FactoryElements(tag);
            };
            _stateMachine.DetectedText += (sender, s) =>
            {
                if (s.Replace(" ", "").Replace("\n", "") == "-->")
                {
//                    resolver.Factory($"<{s}");

                    list.Add($"<{s}");
                }
                else
                {
                    resolver.FactoryText(s);
                    list.Add(s);
                }
            };
            _stateMachine.DetectedAttr += (sender, attrs) =>
            {
                resolver.AttachAttributes(attrs);
            };
//            resolver.ElementComplated += (sender, element) =>
//            {
//                if (element is HTMLScriptElement)
//                {
//                    var scriptElement = element as HTMLScriptElement;
//                    var src = scriptElement.GetAttribute("src");
//
//                    if (src != null)
//                    {
//                        var needType = src.Value.Replace("\"", "");
//                        var type = assembly.GetType(needType);
//
//                        if (type != null)
//                        {
//                            var script = Activator.CreateInstance(type) as IScriptable;
//
//                            if (script != null)
//                            {
//                                script.Start();
//                            }
//                        }
//                    }
//                }
//            };
            _stateMachine.Run();

            var roots = resolver.CreateTree(resolver.Instructions).Select(x => x.ElementInstance as HTMLElement).ToList();
            window.Document.ChildNodes = roots.Select(x => x as Node).ToList();
            window.Screen = new Screen();
            roots.GraphLookup()
                .Where(x => x is HTMLScriptElement)
                .Where(x => x.GetAttribute("src") != null)
                .Select(x => x.GetAttribute("src").Value.Replace("\"", ""))
                .Select(x => assembly.GetType(x))
                .Where(x => x != null)
                .Select(x => Activator.CreateInstance(x) as Script)
                .Where(x => x != null)
                .ToList()
                .ForEach(script =>
                {
                    script.Window = window;

                    var scriptable = script as IScriptable;

                    if (scriptable != null)
                    {
                        scriptable.Start();
                    }
                });
            
            return roots;
        }

        public List<HTMLElement> LoadFromFile(string file, Assembly assembly)
        {
            var source = ReadFromFile(file);
            
            return LoadSource(source, assembly);
        }
        
//        private List<Node> CreateTree()
//        {
//            var elements = _stateMachine.Instance.Elements;
//            var stackOpenElements = new HtmlStack();
//            var currentLevel = 0;
//            
//            for (var i = 0; i < elements.Count; i++)
//            {
//                var element = elements[i];
//
//                if (element.IsOpen != null)
//                {
//                    if (element.IsOpen.Value)
//                    {
//                        stackOpenElements.Push(element);
//                        currentLevel++;
//                    }
//                    else
//                    {
//                        var openedElement = stackOpenElements.Pop(element.NodeName.Substring(1, element.NodeName.Length - 1));
//
//                        if (openedElement != null)
//                        {
//                            openedElement.CloseElement = element;
//                        }
//
//                        GetChilds(openedElement, element, elements);
//                    }
//                }
//            }
//
//            var roots = elements.Where(x => x.ParentNode == null && x.IsOpen == true).ToList();
//
//            return roots;
//        }
        
//        private void GetChilds(Node openNode, Node closeNode, List<Node> elements)
//        {
//            var result = new List<Node>();
//            var startIndex = openNode.Index+1;
//            var endIndex = closeNode.Index;
//            
//            for (var i = startIndex; i < endIndex; i++)
//            {
//                var element = elements[i];
//                if (element.Parent == null)
//                {
//                    element.Parent = openNode;
//
//
//                    if (element.IsOpen != null)
//                    {
//                        if (element.IsOpen.Value)
//                        {
//                            openNode.Elements.Add(element);
//                        }
//                    }
//
//                    if (element.IsOpen == null)
//                    {
//                        openNode.Elements.Add(element);
//                    }
//                }
//
//                result.Add(element);
//            }
//        }
        
        private string ReadFromFile(string fileName)
        {
            var fileContent = default(string);
            
            using (var stream = new StreamReader(fileName))
            {
                fileContent = stream.ReadToEnd();
            }

            return fileContent;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Quantum.DOM;
using Quantum.Parser.HTML;

namespace Quantum.Parser
{
    public class HtmlLoader
    {
        private HtmlStateMachineProcessor _stateMachine;
        public void LoadSource(string source)
        {
            var list = new List<string>();
            var resolver = new HtmlElementResolver();
            
            _stateMachine = new HtmlStateMachineProcessor(source);
            _stateMachine.DetectedNode += (sender, s) =>
            {
                list.Add(s);
                resolver.Factory(s);
            };
            _stateMachine.DetectedText += (sender, s) =>
            {
                list.Add(s);
            };
            _stateMachine.Run();
//            var rootsNodes = CreateTree();

            Console.WriteLine("13");
        }

        public void LoadFromFile(string file)
        {
            var source = ReadFromFile(file);
            
            LoadSource(source);
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
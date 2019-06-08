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
        public Window LoadSource(string source)
        {
            var list = new List<string>();
            
            _stateMachine = new HtmlStateMachineProcessor(source);
            _stateMachine.Run();

            var window = new Window();
            window.Document = _stateMachine.Document;
            window.Screen = new Screen();
            
            InitDocument(window.Document);

            return window;
        }

        private void InitDocument(Document document)
        {
            InitElements(document.ChildNodes.Select(x => x as HTMLElement).ToList());
        }

        private void InitElements(List<HTMLElement> elements)
        {
            foreach (var element in elements)
            {
                if (element == null)
                {
                    continue;
                }
                
                element.Load();
                
                InitElements(element.Children.Select(x => x as HTMLElement).ToList());
            }
        }

        public Window LoadFromFile(string file)
        {
            var source = ReadFromFile(file);
            
            return LoadSource(source);
        }
        
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
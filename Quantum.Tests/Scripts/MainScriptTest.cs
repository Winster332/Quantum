using System;
using Quantum.HTML;

namespace Quantum.Tests.Parsers.Scripts
{
    public class MainScriptTest : Script, IScriptable
    {
        public void Start()
        {
//            var element = Document.CreateElement<HTMLDivElement>();
            
//            Document.Body.AppendChild(element);

            var elementById = Document.GetElementById("password-input");
            var elementByName = Document.GetElementsByClassName("link");
            Console.WriteLine("123");
        }
    }
}
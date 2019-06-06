using System;
using Quantum.HTML;

namespace Quantum.Tests.Parsers
{
    public class MainScriptTest : Script, IScriptable
    {
        public void Start()
        {
            Console.WriteLine("Main script started");
        }
    }
}
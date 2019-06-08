using System;
using Quantum.HTML;

namespace Quantum.Tests.Parsers.Scripts
{
    public class TestScriptShowLog : Script, IScriptable
    {
        public void Start()
        {
            Console.WriteLine("Execute");
        }
    }
}
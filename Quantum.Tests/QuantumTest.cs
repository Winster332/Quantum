using Quantum.DOM;
using Quantum.Parser;
using Xunit;

namespace Quantum.Tests
{
    public class QuantumTest : IClassFixture<QuantumTest>
    {
        public Window Window { get; set; }
        public Document Document => Window?.Document;
        
        public QuantumTest()
        {
        }

        public void ProcessingHtmlFile(string fileName)
        {
            var loader = new HtmlLoader();
            Window = loader.LoadFromFile(fileName);
        }
    }
}
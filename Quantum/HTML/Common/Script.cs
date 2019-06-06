using Quantum.DOM;

namespace Quantum.HTML
{
    public abstract class Script
    {
        public Document Document => Window.Document;
        public Window Window { get; set; }
    }
}
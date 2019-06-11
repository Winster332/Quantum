using Quantum.Platform;

namespace ViewSimplePage
{
    class Program
    {
        static void Main(string[] args)
        {
            QuantumBuilder.Config(new QuantumBuilderOptions(500, 400))
                .Startup("HTML/test.html");
        }
    }
}
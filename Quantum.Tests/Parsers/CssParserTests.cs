using System;
using Quantum.Parser;
using Xunit;

namespace Quantum.Tests.Parsers
{
  public class CssParserTests : QuantumTest
  {
    public CssLoader Loader { get; set; }

    public CssParserTests()
    {
      Loader = new CssLoader();
    }

    [Fact]
    public void ParseFromFileTest()
    {
      var stylesheet = Loader.LoadFromFile($"Contents/main.css");

      Console.WriteLine("TEST");
    }
  }
}
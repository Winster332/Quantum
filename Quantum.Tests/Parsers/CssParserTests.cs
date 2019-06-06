using System;
using Quantum.Parser;
using Xunit;

namespace Quantum.Tests.Parsers
{
  public class CssParserTests
  {
    public CssLoader Loader { get; set; }

    public CssParserTests()
    {
      Loader = new CssLoader();
    }

    [Fact]
    public void ParseFromFileTest()
    {
      Loader.LoadFromFile($"Contents/main.css");

      Console.WriteLine("TEST");
    }
  }
}
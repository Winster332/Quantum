using System;
using FluentAssertions;
using Quantum.CSSOM.Common;
using Xunit;

namespace Quantum.Tests.CSS
{
  public class CSSColorTests : QuantumTest
  {
    [Fact]
    public void CSSColorParseHexTest()
    {
      var color = CSSColor.ParseHex("FFFFFFCC");

      color.Should().NotBeNull();
      
      color.A.Should().BeGreaterOrEqualTo(204);
      color.R.Should().BeGreaterOrEqualTo(255);
      color.G.Should().BeGreaterOrEqualTo(255);
      color.B.Should().BeGreaterOrEqualTo(255);
    }
    
    [Fact]
    public void CSSColorParseHexWithoutAlpha()
    {
      var color = CSSColor.ParseHex("#FFFFFF");

      color.Should().NotBeNull();
      
      color.A.Should().BeGreaterOrEqualTo(255);
      color.R.Should().BeGreaterOrEqualTo(255);
      color.G.Should().BeGreaterOrEqualTo(255);
      color.B.Should().BeGreaterOrEqualTo(255);
    }
    
    [Fact]
    public void CSSColorParseConstTest()
    {
      var color = CSSColor.ParseConstant("black");

      color.Should().NotBeNull();

      color.A.Should().BeGreaterOrEqualTo(255);
      color.R.Should().BeGreaterOrEqualTo(0);
      color.G.Should().BeGreaterOrEqualTo(0);
      color.B.Should().BeGreaterOrEqualTo(0);
    }
    
    [Fact]
    public void CSSColorParseCombinationTest()
    {
      var colorHex = CSSColor.Parse("FFFFFFCC");
      
      colorHex.Should().NotBeNull();

      colorHex.A.Should().BeGreaterOrEqualTo(204);
      colorHex.R.Should().BeGreaterOrEqualTo(255);
      colorHex.G.Should().BeGreaterOrEqualTo(255);
      colorHex.B.Should().BeGreaterOrEqualTo(255);
      
      var colorConst = CSSColor.Parse("white");
      
      colorConst.Should().NotBeNull();

      colorConst.A.Should().BeGreaterOrEqualTo(255);
      colorConst.R.Should().BeGreaterOrEqualTo(255);
      colorConst.G.Should().BeGreaterOrEqualTo(255);
      colorConst.B.Should().BeGreaterOrEqualTo(255);
    }
  }
}
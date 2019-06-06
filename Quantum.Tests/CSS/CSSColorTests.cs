using System;
using FluentAssertions;
using Quantum.CSSOM.Common;
using Xunit;

namespace Quantum.Tests.CSS
{
  public class CSSColorTests
  {
    [Fact]
    public void CSSColorParseTest()
    {
      var color = CSSColor.Parse("FFFFFFCC");

      color.A.Should().BeGreaterOrEqualTo(204);
      color.R.Should().BeGreaterOrEqualTo(255);
      color.G.Should().BeGreaterOrEqualTo(255);
      color.B.Should().BeGreaterOrEqualTo(255);
    }
  }
}
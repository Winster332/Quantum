using System;
using FluentAssertions;
using Quantum.CSSOM.Common;
using Quantum.Parser;
using Xunit;

namespace Quantum.Tests.CSS
{
    public class CSSMarginTests
    {
        [Fact]
        public void MarginFromFile_OneField_Test()
        {
            var loader = new CssLoader();
            var sheet = loader.LoadFromFile("Contents/css/test_margin_style.css");

            sheet.CssRules.Should().HaveCount(3);
            var marginOne = sheet.CssRules[0];
            marginOne.SelectorText.Should().BeEquivalentTo(".marginOneFieldTest");
            
            marginOne.Style.Margin.Bottom.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Bottom.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Top.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Top.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Left.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Left.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Right.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Right.Value.Should().BeGreaterOrEqualTo(10);
        }

        [Fact]
        public void MarginFromFile_TwoField_Test()
        {
            var loader = new CssLoader();
            var sheet = loader.LoadFromFile("Contents/css/test_margin_style.css");

            sheet.CssRules.Should().HaveCount(3);
            var marginOne = sheet.CssRules[1];
            marginOne.SelectorText.Should().BeEquivalentTo(".marginOneFieldTest");
            
            marginOne.Style.Margin.Bottom.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Bottom.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Top.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Top.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Left.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Left.Value.Should().BeGreaterOrEqualTo(10);
            
            marginOne.Style.Margin.Right.Type.Should().BeEquivalentTo(CSSNumberType.Px);
            marginOne.Style.Margin.Right.Value.Should().BeGreaterOrEqualTo(10);
        }
    }
}
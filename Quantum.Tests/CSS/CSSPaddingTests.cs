using System;
using Quantum.CSSOM.Common.BoxModel;
using Xunit;

namespace Quantum.Tests.CSS
{
    public class CSSPaddingTests
    {
        [Fact]
        public void CSSPaddingParseFullArgs()
        {
            var padding = CSSPadding.Parse("35px 70px 50px 90px");
            
            Console.WriteLine("123");
        }
    }
}
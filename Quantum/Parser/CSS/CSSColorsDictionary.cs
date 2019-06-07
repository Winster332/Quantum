using System.Collections.Generic;
using Quantum.CSSOM.Common;

namespace Quantum.Parser.CSS
{
    internal static class CSSColorsDictionary
    {
        public static Dictionary<string, CSSColor> Colors { get; set; } = new Dictionary<string, CSSColor>
        {
            { "white", CSSColor.White },
            { "black", CSSColor.Black }
        };
    }
}
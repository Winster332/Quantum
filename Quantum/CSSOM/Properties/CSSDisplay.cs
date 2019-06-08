namespace Quantum.CSSOM.Properties
{
    public enum CSSDisplayType
    {
        Block,
        Inline,
        InlineBlock
    }

    public class CSSDisplay
    {
        public CSSDisplayType Value { get; set; }
        
        public CSSDisplay()
        {
            Value = CSSDisplayType.Block;
        }

        public static CSSDisplay Parse(string source)
        {
            // TODO: Impl
            return null;
        }
    }
}
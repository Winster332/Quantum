namespace Quantum.CSSOM.Properties
{
    public enum CSSPositionType
    {
        Absolute,
        Fixed
    }

    public class CSSPosition
    {
        public CSSPositionType Value { get; set; }
        
        public CSSPosition()
        {
            Value = CSSPositionType.Absolute;
        }

        public static CSSDisplay Parse(string source)
        {
            // TODO: Impl
            return null;
        }
    }
}
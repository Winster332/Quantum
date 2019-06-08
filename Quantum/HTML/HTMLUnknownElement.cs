using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLUnknownElement : HTMLElement
    {
        public HTMLUnknownElement()
        {
            IsNeedClose = false;
        }
        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
            return false;
        }
    }
}

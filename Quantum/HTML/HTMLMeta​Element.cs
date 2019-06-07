using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLMetaElement : HTMLElement
    {
        public string Content { get; set; }
        public string HttpEquiv { get; set; }
        public string Name { get; set; }
        
        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}
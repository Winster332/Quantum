using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("img")]
    public class HTMLImageElement : HTMLElement
    {
        public string Alt { get; set; }
        public bool Complete { get; set; }
        public string CrossOrigin { get; set; }
        public string CurrentSrc { get; set; }
        public string Decoding { get; set; }
        public float Height { get; set; }
        public bool IsMap { get; set; }
        public float NaturalHeight { get; set; }
        public float NaturalWidth { get; set; }
        public string ReferrerPolicy { get; set; }
        public string Src { get; set; }
        public string Sizes { get; set; }
        public string Srcset { get; set; }
        public string UseMap { get; set; }
        public float Width { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        
        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
            return false;
        }

        public void Decode()
        {
        }
    }
}
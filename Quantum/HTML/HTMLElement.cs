using Quantum.DOM;
using SkiaSharp;

namespace Quantum.HTML
{
    public abstract class HTMLElement : Element
    {
        public string AccessKey { get; set; }
        internal bool IsNeedClose { get; set; } = true;

        protected void Init(string tagName)
        {
            TagName = tagName;
        }

        internal abstract void Load();

        internal abstract bool Draw(SKCanvas canvas);
        
    }
}
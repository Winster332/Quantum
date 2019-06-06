using Quantum.DOM;
using SkiaSharp;

namespace Quantum.HTML
{
    public abstract class HTMLElement : Element
    {
        public string AccessKey { get; set; }

        protected void Init(string tagName)
        {
        }

        internal abstract bool Draw(SKCanvas canvas);
    }
}
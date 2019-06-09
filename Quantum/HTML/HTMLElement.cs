using System.Linq;
using Quantum.CSSOM;
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

        internal void DrawChildren(SKCanvas canvas)
        {
            var elements = Children.Select(x => x as HTMLElement).ToList();

            foreach (var element in elements)
            {
                element.Draw(canvas);
            }
        }
        
        internal StyleSheet GetStyle()
        {
            return null;
        }
    }
}
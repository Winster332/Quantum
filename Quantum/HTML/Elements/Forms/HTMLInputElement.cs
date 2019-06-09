using System.Collections.Generic;
using Quantum.DOM;
using SkiaSharp;

namespace Quantum.HTML.Elements.Forms
{
    [HtmlName("input")]
    public class HTMLInputElement : HTMLElement
    {
        public HTMLFormElement Form { get; set; }
        public string FormAction => Form.Action;
        public string FormMethod => Form.Method;
        public string FormTarget => Form.Target;
        public string Name { get; set; }
        public HTMLInputType Type { get; set; }
        public bool Disabled { get; set; }
        public bool Autofocus { get; set; }
        public bool Value { get; set; }
        
        // "checkbox" or "radio"
        public bool Checked { get; set; }
        public bool DefaultChecked { get; set; }
        public bool Indeterminate { get; set; }
        
        // "image"
        public bool Alt { get; set; }
        public float Height { get; set; }
        public string Src { get; set; }
        public float Width { get; set; }
        
        // "file"
        public string Accept { get; set; }
        public bool Allowdirs { get; set; }
        public List<File> Files { get; set; }
        
        // TODO: IMPL AND ADD MORE

        public HTMLInputElement()
        {
            Init("INPUT");
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
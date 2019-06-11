using System.Collections.Generic;
using Quantum.DOM;
using Quantum.HTML.Elements.Forms;
using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("out")]
    public class HTMLOutputElement : HTMLElement
    {
        public string DefaultValue { get; set; }
        public HTMLFormElement Form { get; set; }
        public DOMTokenList HtmlFor { get; set; }
        public List<HTMLLabelElement> Labels { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ValidationMessage { get; set; }
        // validity
        public string Value => TextContent;
        public bool WillValidate { get; set; }

        public HTMLOutputElement()
        {
            Init("OUTPUT");
        }

        public bool CheckValidity()
        {
            // TODO: Impl
            return false;
        }

        public bool ReportValidity()
        {
            // TODO: Impl
            return false;
        }

        public void SetCustomValidity()
        {
            // TODO: Impl
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
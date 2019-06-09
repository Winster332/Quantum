using Quantum.DOM;

namespace Quantum.HTML
{
    public class HTMLAnchorElement : HTMLHyperlinkElementUtils
    {
        public string AccessKey { get; set; }
        public string Download { get; set; }
        public string Hreflang { get; set; }
        public string Media { get; set; }
        public string ReferrerPolicy { get; set; }
        public LinkType Rel { get; set; }
        public DOMTokenList RelList { get; set; }
        public long TabIndex { get; set; }
        public string Target { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }

        public void Blur()
        {
        }

        public void Focus()
        {
        }

        public override string ToString()
        {
            return Href;
        }
    }
}
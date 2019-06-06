namespace Quantum.HTML
{
    public class HTMLScriptElement : HTMLElement
    {
        public string Type { get; set; }
        public string Src { get; set; }
        public string Charset { get; set; }
        public bool Async { get; set; }
        public bool Defer { get; set; }
        public string Text { get; set; }
        public bool NoModule { get; set; }
        public string ReferrerPolicy { get; set; }
        public HTMLScriptElement()
        {
            Init("SCRIPT");
        }
    }
}
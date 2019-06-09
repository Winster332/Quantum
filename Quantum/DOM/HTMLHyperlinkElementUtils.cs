namespace Quantum.DOM
{
    public class HTMLHyperlinkElementUtils
    {
        public string Href { get; set; }
        public string Protocol { get; set; }
        public string Host { get; set; }
        public string HostName { get; set; }
        public string Port { get; set; }
        public string PathName { get; set; }
        public string Search { get; set; }
        public string Hash { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Origin { get; set; }

        public override string ToString()
        {
            return Href;
        }
    }
}
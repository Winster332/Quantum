namespace Quantum.HTML
{
    public class HTMLLabelElement : HTMLElement
    {
        public HTMLElement Control { get; set; }
        public HTMLFormElement Form { get; set; }
        public string HtmlFor { get; set; }

        public HTMLLabelElement()
        {
            Init("LABEL");
        }
    }
}
using System.Collections.Generic;

namespace Quantum.HTML
{
    public class HTMLButtonElement : HTMLElement
    {
        public HTMLFormElement Form { get; set; }
        public string FormAction => Form.Action;
        public string FormMethod => Form.Method;
        public string FormTarget => Form.Target;
        public bool Disabled { get; set; }
        public bool Autofocus { get; set; }
        public List<HTMLLabelElement> Labels { get; set; }
        public HTMLMenuElement Menu { get; set; }
        public string Name { get; set; }
        public long TabIndex { get; set; }
        public bool Value { get; set; }
        public HTMLButtonType Type { get; set; }
        
        public HTMLButtonElement()
        {
            Init("BUTTON");
            Type = HTMLButtonType.Button;
        }
    }
}
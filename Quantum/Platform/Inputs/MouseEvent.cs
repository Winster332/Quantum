using System.Collections.Generic;
using Quantum.HTML;

namespace Quantum.Platform.Inputs
{
    public class MouseEvent
    {
        public bool AltKey { get; set; }
        public bool Bubles { get; set; }
        public float ClientX { get; set; }
        public float ClientY { get; set; }
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        public float PageX { get; set; }
        public float PageY { get; set; }
        public float ScreenX { get; set; }
        public float ScreenY { get; set; }
        public HTMLElement SrcElement { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public IList<HTMLElement> Path { get; set; }

        public MouseEvent()
        {
            AltKey = false;
            Bubles = true;
            Path = new List<HTMLElement>();
        }
    }
}
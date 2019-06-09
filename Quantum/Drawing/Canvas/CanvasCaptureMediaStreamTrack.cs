using Quantum.DOM.Media;
using Quantum.HTML.Elements;

namespace Quantum.Drawing.Canvas
{
    public class CanvasCaptureMediaStreamTrack : MediaStreamTrack
    {
        public HTMLCanvasElement Canvas { get; set; }

        public void RequestFrame()
        {
        }
    }
}
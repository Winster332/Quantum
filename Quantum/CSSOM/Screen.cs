using Quantum.DOM.Events;

namespace Quantum.CSSOM
{
    public class Screen : EventTarget
    {
        public int AvailHeight { get; set; }
        public int AvailWidth { get; set; }
        public int ColorDepth { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public ScreenOrientation Orientation { get; set; }
        public int PixelDepth { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }

        public Screen()
        {
            Orientation = new ScreenOrientation();
        }
        
        public void LockOrientation()
        {
            Orientation.Lock();
        }

        public void UnlockOrientation()
        {
            Orientation.Unlock();
        }
    }
}
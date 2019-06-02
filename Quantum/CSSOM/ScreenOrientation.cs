using Quantum.DOM.Events;

namespace Quantum.CSSOM
{
    public class ScreenOrientation
    {
        private bool _isLock { get; set; }
        public ScreenOrientationType Type
        {
            get => _type;
            set
            {
                if (!_isLock)
                {
                    if (_type != value)
                    {
                        var changeEvent = new Event<ScreenOrientation>
                        {
                            Instance = this
                        };
                        OnChange?.Invoke(changeEvent);
                    }

                    _type = value;
                }
            }
        }
        private ScreenOrientationType _type { get; set; }
        public float Angle { get; set; }
        private DOMEventHandler<ScreenOrientation> OnChange;

        public ScreenOrientation()
        {
            _isLock = true;
            Type = ScreenOrientationType.LandscapePrimary;
            Angle = 0;
        }
        
        public void Lock()
        {
            _isLock = true;
        }
        
        public void Unlock()
        {
            _isLock = false;
        }
    }
}
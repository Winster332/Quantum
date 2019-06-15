using System;
using OpenTK.Input;
using Quantum.Platform.Core;

namespace Quantum.Platform.Inputs.Mouse
{
    public class DesktopMouseEventHandler : IMouseEventHandler
    {
        private DesktopWindow _window;
        public event EventHandler<MouseEvent> OnMouseDown;
        public event EventHandler<MouseEvent> OnMouseUp;
        public event EventHandler<MouseEvent> OnMouseMove;

        public DesktopMouseEventHandler(DesktopWindow window)
        {
            _window = window;
            
            _window.MouseDown += WindowOnMouseDown;
            _window.MouseUp += WindowOnMouseUp;
            _window.MouseMove += WindowOnMouseMove;
        }
        
        private void WindowOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var mouseEvent = ConvertMouseButtonEventToMouseEvent(e);
            
            OnMouseDown?.Invoke(this, mouseEvent);
        }

        private void WindowOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var mouseEvent = ConvertMouseButtonEventToMouseEvent(e);
            
            OnMouseDown?.Invoke(this, mouseEvent);
        }

        private void WindowOnMouseMove(object sender, MouseMoveEventArgs e)
        {
            var mouseEvent = ConvertMouseButtonEventToMouseEvent(e);
            
            OnMouseMove?.Invoke(this, mouseEvent);
        }

        private MouseEvent ConvertMouseButtonEventToMouseEvent(MouseButtonEventArgs e)
        {
            var mouseEvent = new MouseEvent
            {
                X = e.X,
                Y = e.Y,
                OffsetX = e.X,
                OffsetY = e.Y
            };

            return mouseEvent;
        }
        
        private MouseEvent ConvertMouseButtonEventToMouseEvent(MouseMoveEventArgs e)
        {
            var mouseEvent = new MouseEvent
            {
                X = e.X,
                Y = e.Y,
                OffsetX = e.X,
                OffsetY = e.Y
            };

            return mouseEvent;
        }
    }
}
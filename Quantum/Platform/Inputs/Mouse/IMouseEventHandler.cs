using System;

namespace Quantum.Platform.Inputs.Mouse
{
    public interface IMouseEventHandler
    {
        event EventHandler<MouseEvent> OnMouseDown;
        event EventHandler<MouseEvent> OnMouseUp;
        event EventHandler<MouseEvent> OnMouseMove;
    }
}
using System;
using Quantum.DOM;

namespace Quantum.Platform.Graphics
{
  public class RenderCompositor
  {
    private Window _window;
    public RenderCompositor(Window window)
    {
      _window = window;
    }
    
    public void CompositeApply(RenderLayout layout)
    {
      Console.WriteLine(layout);
    }
  }
}
using SkiaSharp;

namespace Quantum.HTML
{
    public class HTMLUnknownElement : HTMLElement
    {
      internal override bool Draw(SKCanvas canvas)
      {
        return false;
      }
    }
}
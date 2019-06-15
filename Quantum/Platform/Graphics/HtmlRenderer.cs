using System.Collections.Generic;
using System.Linq;
using Quantum.DOM;
using Quantum.HTML;
using SkiaSharp;

namespace Quantum.Platform.Graphics
{
  public class HtmlRenderer
  {
    private Window _window;
    private Document _document;

    public HtmlRenderer(Window window)
    {
      _window = window;
      _document = _window.Document;
    }

    public void Render(SKCanvas canvas)
    {
      var roots = _document.ChildNodes.OfType<HTMLElement>();
      
      foreach (var element in roots)
      {
        element.Draw(canvas);
      }
    }

    private void GetBound(Element element, SKPaint paint)
    {
      var prevSibling = element.ParentNode.PreviousSibling as Element;
      var bounds = new SKRect();

      paint.MeasureText(element.TextContent, ref bounds);

      element.OffsetTop = bounds.Top;
      element.OffsetLeft = bounds.Left;
      
      if (prevSibling != null)
      {
        var pTop = prevSibling.OffsetTop;
        var pLeft = prevSibling.OffsetLeft;

        element.OffsetLeft = prevSibling.OffsetWidth;
//        element.OffsetLeft = pLeft + prevSibling.OffsetWidth + bounds.Width + bounds.Left;

//        element.OffsetTop = element.OffsetTop + pTop + bounds.Height;
//        element.OffsetLeft = element.OffsetLeft + pLeft + bounds.Width;
      }

      element.OffsetWidth = bounds.Width;
      element.OffsetHeight = bounds.Height;
    }

    private bool DrawElement(SKCanvas canvas, HTMLElement element)
    {
      if (element == null)
      {
        return false;
      }
      
      element.Draw(canvas);

      return true;
    }
  }
}
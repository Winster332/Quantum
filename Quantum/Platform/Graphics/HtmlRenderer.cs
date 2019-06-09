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
//      DrawTreeElements(canvas, _document.ChildNodes.OfType<Element>().ToList());
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

//      if (element.NodeName == "#NodeNametext")
//      {
//          var textPen = new SKPaint
//          {
//            IsAntialias = true,
//            Color = new SKColor(110, 102, 244),
//            TextSize = 15
//          };
//          GetBound(element, textPen);
//          var bounds = new SKRect();
//          
//          textPen.MeasureText(element.TextContent, ref bounds);
//          canvas.DrawLine(bounds.Left + 100, bounds.Bottom + 100, bounds.Right + 100, bounds.Bottom + 100,
//            new SKPaint
//            {
//              IsAntialias = true,
//              Style = SKPaintStyle.Stroke,
//              StrokeWidth = 1,
//              Color = textPen.Color
//            });
//          
////          element.OffsetTop = bounds.Top;
////          element.OffsetLeft = bounds.Left;
//          element.OffsetWidth = bounds.Width;
//          element.OffsetHeight = bounds.Height;
//          
//          canvas.DrawText(element.TextContent, element.OffsetLeft, element.OffsetTop, textPen);
//          canvas.DrawRect(element.OffsetLeft + bounds.Left, element.OffsetTop + bounds.Top, element.OffsetWidth, element.OffsetHeight,
//            new SKPaint
//            {
//              IsAntialias = true,
//              Style = SKPaintStyle.Stroke,
//              StrokeWidth = 1,
//              Color = SKColors.Red
//            });
//      }

      return true;
    }

    private void DrawTreeElements(SKCanvas canvas, List<Element> elements)
    {
      foreach (var element in elements)
      {
        if (element.NodeType == NodeType.TextNode)
        {
//          var textPen = new SKPaint
//          {
//            IsAntialias = true,
//            Color = new SKColor(110, 102, 244),
//            TextSize = 15
//          };
//          var bounds = new SKRect();
//          textPen.MeasureText(element.TextContent, ref bounds);
//          canvas.DrawText(element.TextContent, pos.X, pos.Y, textPen);
//          canvas.DrawLine(bounds.Left + pos.X, bounds.Bottom + pos.Y, bounds.Right + pos.X, bounds.Bottom + pos.Y,
//            new SKPaint
//            {
//              IsAntialias = true,
//              Style = SKPaintStyle.Stroke,
//              StrokeWidth = 1,
//              Color = textPen.Color
//            });
        }
        else
        {
        }

        var htmlElement = element as HTMLElement;
        DrawElement(canvas, htmlElement);

        if (element.Children.Count != 0)
        {
//          DrawTreeElements(canvas, element.Children);

//          canvas.DrawLine(startLineX + 5, startLineY + 5, pos.X + 5, pos.Y - 15, new SKPaint
//          {
//            IsAntialias = true,
//            Style = SKPaintStyle.Stroke,
//            Color = SKColors.Cyan
//          });
        }
      }
    }
  }
}
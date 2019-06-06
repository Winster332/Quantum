using SkiaSharp;

namespace Quantum.HTML
{
  public class HTMLTextElement : HTMLElement
  {
    internal override bool Draw(SKCanvas canvas)
    {
      if (ParentNode.GetType() == typeof(HTMLLinkElement))
      {
        var textPen = new SKPaint
        {
          IsAntialias = true,
          Color = new SKColor(110, 102, 244),
          TextSize = 15
        };
        var bounds = new SKRect();
        textPen.MeasureText(TextContent, ref bounds);

        var x = OffsetLeft;
        OffsetTop = bounds.Top;
        OffsetLeft = bounds.Left;
        OffsetWidth = bounds.Width;
        OffsetHeight = bounds.Height;
        
        var prevElement = ParentNode.PreviousSibling as HTMLElement;

        if (prevElement != null)
        {
          x += prevElement.OffsetWidth + bounds.Left + 10;
        }

        canvas.DrawText(TextContent, x, OffsetTop, textPen);
        canvas.DrawLine(x, bounds.Bottom + OffsetTop, x + bounds.Right,
          bounds.Bottom + OffsetTop,
          new SKPaint
          {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 1,
            Color = textPen.Color
          });
      }

      return true;
    }
  }
}
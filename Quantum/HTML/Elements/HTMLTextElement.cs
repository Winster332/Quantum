using SkiaSharp;

namespace Quantum.HTML.Elements
{
  [HtmlName("text")]
  public class HTMLTextElement : HTMLElement
  {
    internal override void Load()
    {
    }

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

        OffsetTop = bounds.Top + 10;
        OffsetLeft = bounds.Left;
        OffsetWidth = bounds.Width;
        OffsetHeight = bounds.Height;

        canvas.DrawText(TextContent, OffsetLeft, OffsetTop, textPen);
        canvas.DrawLine(OffsetLeft, OffsetTop + 2, OffsetLeft + OffsetWidth, OffsetTop + 2,
          new SKPaint
          {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 1,
            Color = textPen.Color
          });
      }
      else
      {
        var textPen = new SKPaint
        {
          IsAntialias = true,
          Color = new SKColor(50, 50, 50),
          TextSize = 15
        };
        var bounds = new SKRect();
        textPen.MeasureText(TextContent, ref bounds);

        OffsetTop = bounds.Top + 10;
        OffsetLeft = bounds.Left;
        OffsetWidth = bounds.Width;
        OffsetHeight = bounds.Height;

        canvas.DrawText(TextContent, OffsetLeft, OffsetTop, textPen);
      }

      return true;
    }
  }
}

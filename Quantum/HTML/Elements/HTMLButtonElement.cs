using System.Collections.Generic;
using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("button")]
    public class HTMLButtonElement : HTMLElement
    {
        public HTMLFormElement Form { get; set; }
        public string FormAction => Form.Action;
        public string FormMethod => Form.Method;
        public string FormTarget => Form.Target;
        public bool Disabled { get; set; }
        public bool Autofocus { get; set; }
        public List<HTMLLabelElement> Labels { get; set; }
        public HTMLMenuElement Menu { get; set; }
        public string Name { get; set; }
        public long TabIndex { get; set; }
        public bool Value { get; set; }
        public HTMLButtonType Type { get; set; }
        
        public HTMLButtonElement()
        {
            Init("BUTTON");
            Type = HTMLButtonType.Button;
        }

        internal override void Load()
        {
        }

        internal override bool Draw(SKCanvas canvas)
        {
          var x = OffsetLeft - 5;
          var y = OffsetTop - 5;
          var width = OffsetWidth + 10;
          var height = OffsetHeight + 10;

          canvas.Save();
          canvas.Translate(x, y);
          canvas.DrawRoundRect(0, 0,width, height, 2, 2, new SKPaint
          {
            IsAntialias = true,
            Shader = SKShader.CreateLinearGradient(
              new SKPoint(width / 2, 0),
              new SKPoint(width / 2, height),
              new SKColor[]
              {
                new SKColor(240, 240, 240), 
                new SKColor(200, 200, 200),
              },
              new float[] { 0, 1 },
              SKShaderTileMode.Repeat)
          });
          canvas.DrawRoundRect(0, 0,width, height, 1, 1, new SKPaint
          {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            Color = new SKColor(150, 150, 150)
          });
          
          canvas.Restore();
          
          DrawChildren(canvas);
          
          return false;
        }
    }
}
using System;
using Quantum.Drawing.Canvas;
using Quantum.HTML;
using Quantum.HTML.Elements;

namespace Quantum.Drawing
{
    public class CanvasRenderingContext2D : RenderingContext
    {
        #region Line styles
        
        public float LineWidth { get; set; }
        public CanvasLineCapType LineCap { get; set; }
        public CanvasLineJoinType LineJoin { get; set; }
        public float MiterLimit { get; set; }

        public float[] GetLineDash()
        {
            // TODO: Impl
            return null;
        }
        
        public void SetLineDash(float[] arrayPoints)
        {
            // TODO: Impl
        }
        
        public float LineDashOffset { get; set; }
        
        #endregion
        
        #region Text style
        
        public string Font { get; set; }
        public CanvasTextAlignType TextAlign { get; set; }
        public CanvasTextBaselineType TextBaseline { get; set; }
        public CanvasDirectionType Direction { get; set; }
        
        #endregion
        
        #region Fill and stroke styles
        
        public string FillStyle { get; set; }
        public string StrokeStyle { get; set; }
        
        #endregion

        #region Gradient and patterns
        
        // TODO: Need impl
        
        #endregion
        
        #region Shadow
        
        // TODO: Need impl
        
        #endregion
        
        #region Paths

        public void BeginPath()
        {
        }
        
        public void ClosePath()
        {
        }
        
        public void MoveTo(float x, float y)
        {
        }

        public void LineTo(float x, float y)
        {
        }

        public void BezierCurveTo()
        {
        }

        public void QuadraticCurveTo()
        {
        }

        public void Arc(float x, float y, float radius, float startAngle, float endAngle)
        {
        }
        
        public void ArcTo(float x, float y, float radius, float startAngle, float endAngle)
        {
        }

        public void Ellipse(float x, float y, float radiusX, float radiusY, float rotation, float startAngle, float endAngle)
        {
        }

        public void Rect(float x, float y, float width, float height)
        {
        }

        #endregion
        
        #region Drawing paths
        
        public void Fill()
        {
        }
        
        public void Stroke()
        {
        }

        public void DrawFocusIfNeeded()
        {
        }

        public void ScrollPathIntoView()
        {
        }

        public void Clip()
        {
        }

        public void IsPointInPath()
        {
        }

        public void IsPointInStroke()
        {
        }

        #endregion
        
        #region  Transformations
        
        public SVGMatrix CurrentTransform { get; set; }

        public void Rotate()
        {
        }

        public void Scale()
        {
        }
        
        public void Translate()
        {
        }
        
        public void Transform()
        {
        }
        
        public void SetTransform()
        {
        }
        
        public void ResetTransform()
        {
        }

        #endregion
        
        #region Compositing
        
        public float GlobalAlpha { get; set; }
        public CanvasGlobalCompositeOperationType GlobalCompositeOperation { get; set; }
        
        #endregion
        
        #region Image smoothing
        
        public bool ImageSmoothingEnabled { get; set; }
        public CanvasImageSmoothingQualityType ImageSmoothingQuality { get; set; }
        
        #endregion
        
        public CanvasRenderingContext2D()
        {
            LineWidth = 1;
            LineCap = CanvasLineCapType.Butt;
            LineJoin = CanvasLineJoinType.Miter;
            MiterLimit = 10.0f;
            LineDashOffset = 0.0f;
            Font = "10px sans-serif";
            TextAlign = CanvasTextAlignType.Start;
            TextBaseline = CanvasTextBaselineType.Alphabetic;
            Direction = CanvasDirectionType.Inherit;
            FillStyle = "#000";
            StrokeStyle = "#000";
            CurrentTransform = new SVGMatrix();
            GlobalAlpha = 1.0f;
            GlobalCompositeOperation = CanvasGlobalCompositeOperationType.SourceOver;
            ImageSmoothingEnabled = true;
            ImageSmoothingQuality = CanvasImageSmoothingQualityType.Medium;
            Filter = CanvasFilter.Empty;
        }
        
        internal override void Render()
        {
        }
        
        #region The canvas state

        public void Save()
        {
        }

        public void Restore()
        {
        }

        public HTMLCanvasElement Canvas => HTMLCanvas;
        
        #endregion
        
        #region Hit regions

        public void AddHitRegion()
        {
        }

        public void RemoveHitRegion()
        {
        }

        public void ClearHitRegions()
        {
        }

        #endregion

        #region Filters
        
        public CanvasFilter Filter { get; set; }
        
        #endregion
        
        #region Drawing images
        
        public void DrawImage(HTMLImageElement image, float x, float y, float width, float height)
        {
        }
        
        public void DrawImage(HTMLImageElement image, float x, float y)
        {
        }
        
        #endregion
        
        #region Pixel manipulation

        public ImageData CreateImageData()
        {
            return null;
        }
        
        public ImageData GetImageData()
        {
            return null;
        }
        
        public void PutImageData(ImageData imageData)
        {
        }
        
        #endregion

        #region Drawing rectangles
        
        public void ClearRect(float x, float y, float width, float height)
        {
        }
        
        public void FillRect(float x, float y, float width, float height)
        {
        }
        
        public void StrokeRect(float x, float y, float width, float height)
        {
        }
        
        #endregion
        
        #region Drawing text

        public void FillText(string text, float x, float y)
        {
        }

        public void StrokeText(string text, float x, float y)
        {
        }

        public TextMetrics MeasureText()
        {
            throw new NotImplementedException();
            return null;
        }
        
        #endregion
        
    }
}
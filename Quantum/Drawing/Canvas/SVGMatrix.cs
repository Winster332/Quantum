namespace Quantum.Drawing.Canvas
{
    public class SVGMatrix
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public float D { get; set; }
        public float E { get; set; }
        public float F { get; set; }

        public SVGMatrix()
        {
        }

        public SVGMatrix Multiply(SVGMatrix matrix)
        {
            // TODO: Impl
            return new SVGMatrix();
        }

        public SVGMatrix Inverse()
        {
            // TODO: Impl
            return this;
        }

        public void Translate()
        {
        }

        public void Scale()
        {
        }

        public void ScaleNonUniform()
        {
        }

        public void Rotate()
        {
        }

        public void RotateFromVector()
        {
        }

        public void FlipX()
        {
        }

        public void FlipY()
        {
        }

        public void SkewX()
        {
        }

        public void SkewY()
        {
        }
    }
}
namespace Quantum.Platform
{
    public class QuantumBuilderOptions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public double UpdatesPerSeconds { get; set; }
        public double FramesPerSeconds { get; set; }

        public QuantumBuilderOptions()
        {
            Width = 500;
            Height = 400;
            UpdatesPerSeconds = 30.0f;
            FramesPerSeconds = 30.0f;
        }
        
        public QuantumBuilderOptions(int width, int height)
        {
            Width = width;
            Height = height;
            UpdatesPerSeconds = 30.0f;
            FramesPerSeconds = 30.0f;
        }
    }
}
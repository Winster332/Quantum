using System;
using Quantum.Platform.Core;

namespace Quantum.Platform
{
    public class QuantumBuilder
    {
        private DesktopWindow _window;
        private QuantumBuilderOptions _options;

        private QuantumBuilder(QuantumBuilderOptions options)
        {
            _options = options;
        }

        public void Startup(string pathToFileIndex)
        {
            // TODO: Impl
            
            RunWindow();
        }
        
        public void Startup(Uri uri)
        {
            // TODO: Impl
            
            RunWindow();
        }

        private void RunWindow()
        {
            try
            {
                using (var window = new DesktopWindow(_options.Width, _options.Height))
                {
                    window.Run(_options.UpdatesPerSeconds, _options.FramesPerSeconds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static QuantumBuilder Config(QuantumBuilderOptions options = null)
        {
            if (options == null)
            {
                options = new QuantumBuilderOptions();
            }

            var builder = new QuantumBuilder(options);

            return builder;
        }
    }
}
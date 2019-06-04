using System;
using Quantum.Platform.Core;

namespace ViewSimplePage
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new DesktopWindow(500, 400))
            {
                window.Run(30.0f);
            }
        }
    }
}
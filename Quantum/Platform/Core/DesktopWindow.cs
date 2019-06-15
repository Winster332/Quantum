using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Quantum.Platform.Audio;
using Quantum.Platform.Inputs.Mouse;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace Quantum.Platform.Core
{
    public class DesktopWindow : GameWindow
    {
        private GRContext _context;
        private GRBackendRenderTarget _renderTarget;
        public event EventHandler<SKPaintGLSurfaceEventArgs> PaintSurface;
        public event EventHandler<double> UpdateSurface;
        private IMouseEventHandler _mouseHandler;
        
        public DesktopWindow(int width, int height)
            : base(width, height, GraphicsMode.Default, "Main window", GameWindowFlags.Default, DisplayDevice.Default)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            UpdateSurface?.Invoke(this, e.Time);
        }
        
        protected override void OnLoad(EventArgs ee)
        {
            base.OnLoad(ee);
            var glInterface = GRGlInterface.CreateNativeGlInterface();
            Debug.Assert(glInterface.Validate());

            this._context = GRContext.Create(GRBackend.OpenGL, glInterface);
            Debug.Assert(this._context.Handle != IntPtr.Zero);
            this._renderTarget = CreateRenderTarget(_context);

            this.KeyDown += (o, e) =>
            {
                if (e.Key == Key.Escape)
                    this.Close();
            };
            FocusedChanged += OnFocusedChanged;
            
            InitMouse();
            
            //    WindowState = WindowState.Fullscreen;
            CursorVisible = false;
            this.CursorVisible = true;
        }

        private void InitMouse()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
                     RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || 
                     RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _mouseHandler = new DesktopMouseEventHandler(this);
            }

            _mouseHandler.OnMouseDown += (o, e) => { };
            _mouseHandler.OnMouseMove += (o, e) => { };
            _mouseHandler.OnMouseUp += (o, e) => { };
        }
        
        private void OnFocusedChanged(object sender, EventArgs e)
        {
            var isWindowFocus = Focused;
        }
        
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";

            var props = new SKSurfaceProperties(SKSurfacePropsFlags.None, SKPixelGeometry.BgrHorizontal);
            using (var surface = SKSurface.Create(_context, _renderTarget, SKColorType.Bgra8888, props))
            {
                if (surface != null)
                {
                    Debug.Assert(surface != null);
                    Debug.Assert(surface.Handle != IntPtr.Zero);

                    var canvas = surface.Canvas;

                    canvas.Flush();

                    var info = this._renderTarget;

                    PaintSurface?.Invoke(this, new SKPaintGLSurfaceEventArgs(surface, _renderTarget));
                    
                    canvas.Flush();
                }
                else
                {
                }
            }

            this._context.Flush();
            SwapBuffers();
        }
        
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            this._context?.Dispose();
            this._context = null;
        }
        
        public GRBackendRenderTarget CreateRenderTarget(GRContext grContext)
        {
            GL.GetInteger(GetPName.FramebufferBinding, out int framebuffer);
            GL.GetInteger(GetPName.StencilBits, out int stencil);
            GL.GetInteger(GetPName.Samples, out int samples);

            int bufferWidth = 0;
            int bufferHeight = 0;

            GL.GetRenderbufferParameter(RenderbufferTarget.Renderbuffer, RenderbufferParameterName.RenderbufferWidth,
                out bufferWidth);
            GL.GetRenderbufferParameter(RenderbufferTarget.Renderbuffer, RenderbufferParameterName.RenderbufferHeight,
                out bufferHeight);
            
            var colorType = SKColorType.Rgba8888; 
            var glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());
            return new GRBackendRenderTarget(Width, Height, grContext.GetMaxSurfaceSampleCount(colorType), stencil, glInfo);
        }
    }
}
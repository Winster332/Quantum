using System;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
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
        
        public DesktopWindow(int width, int height)
            : base(width, height, GraphicsMode.Default, "Main window", GameWindowFlags.Default, DisplayDevice.Default)
        {
            VSync = VSyncMode.On;
            
//            PaintSurface += OnPaintSurface;
        }

        private void OnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear(new SKColor(50, 50, 50));
            
            canvas.DrawRoundRect(100, 100, 80, 28, 100, 100, new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.White,
            });
//            canvas.DrawCircle(100, 100, 50, new SKPaint
//            {
//                Color = new SKColor(150, 100, 100),
//                IsAntialias = true
//            });
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
            
            //    WindowState = WindowState.Fullscreen;
            CursorVisible = false;
            this.CursorVisible = true;
        }
        
        private void OnFocusedChanged(object sender, EventArgs e)
        {
            var isWindowFocus = Focused;

//            InputMouse.Enabled = isWindowFocus;
        }
        
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";

//            this._renderTarget.Width = this.Width;
//            this._renderTarget.Height = this.Height;

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
//            GL.Rotate(10, 10, 10, 10);
            GL.GetInteger(GetPName.FramebufferBinding, out int framebuffer);
            // debug: framebuffer = 0
            GL.GetInteger(GetPName.StencilBits, out int stencil);
            // debug: stencil = 0
            GL.GetInteger(GetPName.Samples, out int samples);
            // debug: samples = 0

            int bufferWidth = 0;
            int bufferHeight = 0;

            //#if __IOS__ || __TVOS__
            GL.GetRenderbufferParameter(RenderbufferTarget.Renderbuffer, RenderbufferParameterName.RenderbufferWidth,
                out bufferWidth);
            // debug: bufferWidth = 0
            GL.GetRenderbufferParameter(RenderbufferTarget.Renderbuffer, RenderbufferParameterName.RenderbufferHeight,
                out bufferHeight);
            // debug: bufferHeight = 0
            //#endif
            var colorType = SKColorType.Rgba8888; 
            var glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());
            return new GRBackendRenderTarget(Width, Height, grContext.GetMaxSurfaceSampleCount(colorType), stencil, glInfo);
            
//            return new GRBackendRenderTarget(bufferWidth, bufferHeight, samples, stencil, new GRGlFramebufferInfo((uint) framebuffer));

//            return new GRBackendRenderTargetDesc
//            {
//                Width = bufferWidth,
//                Height = bufferHeight,
//                Config = GRPixelConfig.Bgra8888, // Question: Is this the right format and how to do it platform independent?
//                Origin = GRSurfaceOrigin.BottomLeft,
//                SampleCount = samples,
//                StencilBits = stencil,
//                RenderTargetHandle = (IntPtr) framebuffer,
//            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGLx64.Drawing;
namespace OpenGLx64.GLForms
{
    public class GLForm
    {

        public event EventHandler<GLFormKeyPressEventArgs> KeyPress;
        public event EventHandler Resize;
        IntPtr handle;
        GLGraphics graphics;
        GLFormKeyListener keyListener;
        GLSize size;
        List<GLControl> controls;

        OpenGLx64API.WindowResizeCallBack resizeCallBack;
        public List<GLControl> Controls
        {
            get => controls;
            set => controls = value;
        }
        public GLColor BackColor { get; set; }
        public GLSize Size
        {
            get => size;
            set
            {
                size = value;
                OpenGLx64API.GLSetWindowSize(handle, (int)value.Width, (int)value.Height);
            }
        }
        public IntPtr Handle => handle;
        public GLForm()
        {
            handle = OpenGLx64API.GLCreateWindow(0, 0, 800, 600, false, true, true, "GLForm");
            OpenGLx64API.GLMakeContextCurrent(handle);
            graphics = new GLGraphics(size);
            size = new GLSize(800, 600);
            BackColor = new GLColor(System.Drawing.Color.White);
            resizeCallBack = new OpenGLx64API.WindowResizeCallBack(resize);
            OpenGLx64API.GLSetWindowSizeCallBack(handle, resizeCallBack);
            keyListener = new GLFormKeyListener(handle);
            keyListener.KeyPress += KeyListener_KeyPress;
            controls = new List<GLControl>();
        }

        private void KeyListener_KeyPress(object sender, GLFormKeyPressEventArgs e)
        {
            KeyPress?.Invoke(this, e);
        }

        void resize(IntPtr handle, int width, int height)
        {
            System.Diagnostics.Debug.WriteLine($"W={width}, h={height}");
            size = new GLSize(width, height);
            graphics = new GLGraphics(size);
            OpenGLx64API.GLViewport(0, 0, width, height);
            Resize?.Invoke(this, new EventArgs());
        }
        public GLGraphics CreateGraphics() => new GLGraphics(size);

        void checkKeys()
        {

        }

        public void MainLoop()
        {
            while (true)
            {
                graphics.Clear(BackColor);
                foreach (var control in controls)
                {
                    control.PollEvents();
                    control.Invalidate();
                }
                keyListener.MainLoopFunction();
                OpenGLx64API.GLSwapBuffers(handle);
                System.Threading.Thread.Sleep(1000 / 60);
            }
        }
    }

}

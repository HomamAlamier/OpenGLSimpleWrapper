using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenGLx64.Drawing;
namespace OpenGLx64.GLForms
{
    public class GLControl
    {
        GLGraphics graphics;
        GLPoint loc;
        GLSize sz;
        GLColor backcolor;
        GLSize viewport;
        IntPtr parentHandle;
        GLRectangle ripple;

        public GLRectangle ClientRectangle => new GLRectangle(loc, sz);
        public GLPoint Location
        {
            get => loc;
            set => loc = value;
        }
        public GLSize Size
        {
            get => sz;
            set => sz = value;
        }
        public GLColor BackColor
        {
            get => backcolor;
            set => backcolor = value;
        }
        public GLGraphics Graphics => graphics;
        public void SetGraphics(GLGraphics graphics) => this.graphics = graphics;
        public GLControl(GLSize viewport, IntPtr parentHandle)
        {
            // shader = OpenGLx64.GLCreateShader(File.ReadAllText("vert.glsl"), File.ReadAllText("frag.glsl"));
            graphics = new GLGraphics(viewport);
            Paint(graphics);
            this.viewport = viewport;
            this.parentHandle = parentHandle;
            #region TestCode
            /*float x = 0, y = 0, x1 = 0.5f, y1 = 0.5f;
            shape = new GLShape();
            shape.Points = new GLPoint[]
            {
                new GLPoint(x, y),
                new GLPoint(x1, y),

                new GLPoint(x1, y),
                new GLPoint(x1, y1),

                new GLPoint(x1, y1),
                new GLPoint(x, y1),

                new GLPoint(x, y1),
                new GLPoint(x, y)
            };
            shape.Colors = new GLColor[]
            {
                new GLColor(1f, 0f, 0f, 1f),
                new GLColor(0f, 1f, 0f, 1f),

                new GLColor(0f, 1f, 0f, 1f),
                new GLColor(0f, 0f, 1f, 1f),

                new GLColor(0f, 0f, 1f, 1f),
                new GLColor(1f, 1f, 0f, 1f),

                new GLColor(1f, 1f, 0f, 1f),
                new GLColor(1f, 0f, 0f, 1f)
            };
            shape.CreateVertexBuffer();*/
            #endregion
        }
        GLMouseButton getMButton()
        {
            if (OpenGLx64API.GLGetMouseButton(parentHandle, GLMouseButton.LEFT) > 0) return GLMouseButton.LEFT;
            else if (OpenGLx64API.GLGetMouseButton(parentHandle, GLMouseButton.RIGHT) > 0) return GLMouseButton.RIGHT;
            else if (OpenGLx64API.GLGetMouseButton(parentHandle, GLMouseButton.MIDDLE) > 0) return GLMouseButton.MIDDLE;
            else return GLMouseButton.NONE;
        }
        public virtual void PollEvents()
        {
            var ptr = OpenGLx64API.GLGetCursorPos(parentHandle);
            float[] pntF = new float[2];
            Marshal.Copy(ptr, pntF, 0, 2);
            if (ClientRectangle.Contains(new GLPoint(pntF[0], pntF[1])))
            {
                if (getMButton() == GLMouseButton.LEFT)
                {
                    ripple = new GLRectangle(loc.X + (sz.Width / 2), loc.Y + (sz.Height / 2), 2, 2);
                    backcolor = new GLColor(0f, 1f, 0f, 1f);
                }
                else
                {
                    backcolor = new GLColor(0f, 0f, 1f, 1f);
                }
            }
            else
            {
                backcolor = new GLColor(1f, 0f, 0f, 1f);
            }
            if (ripple.Width < sz.Width)
            {
                float step = 5f;
                ripple.X -= step;
                ripple.Y -= step;
                ripple.Width += step * 2;
                ripple.Height += step * 2;
            }
        }
        public virtual void Invalidate()
        {
            Paint(graphics);
        }
        public virtual void Paint(GLGraphics graphics)
        {
            graphics.FillRectangle(new GLRectangle(loc.X, loc.Y, sz.Width, sz.Height - 5), backcolor);
            //graphics.SetClipRectangle(ClientRectangle);
            graphics.LinearGradiantRectangle_Veritcal(new GLRectangle(loc.X, loc.Y + (sz.Height - 6), sz.Width, 6)
                , new GLColor(0.3f, 0.3f, 0.3f, 1f), new GLColor(0f, 0f, 0f, 0f));
            float cX = (loc.X + (sz.Width / 2));
            float cY = (loc.Y + (sz.Height / 2));
            float r = ripple.Width / 2;
            graphics.ClipInto(new GLPath() { vectors = GLMath.Circle3f(cX, cY, r) }, ClientRectangle);
            //graphics.FillPath(GLMath.Circle3f(cX, cY, 0.75f), GLColor.Blue);
            //graphics.UnsetClipRectangle();
        }

    }
}

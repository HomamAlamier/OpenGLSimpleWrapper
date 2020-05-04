using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OpenGLx64.Drawing
{
    public class GLGraphics
    {
        List<GLComplexShape> shapes;
        GLSize viewport;
        public GLComplexShape[] Shapes => shapes.ToArray();
        public GLGraphics(GLSize viewport)
        {
            shapes = new List<GLComplexShape>();
            this.viewport = viewport;
        }
        public void DrawRectangle(GLRectangle rect, GLColor color)
        {
            float paddingX = 1 / viewport.Width;
            float paddingY = 1 / viewport.Height;

            float x1 = GLMath.Normalize(rect.X / viewport.Width) + paddingX;
            float y1 = -GLMath.Normalize(rect.Y / viewport.Height) - paddingY;

            float x2 = GLMath.Normalize((rect.X + rect.Width) / viewport.Width) - paddingX;
            float y2 = -GLMath.Normalize((rect.Y + rect.Height) / viewport.Height) + paddingY;

            OpenGLx64API.GLColor4f(color.R, color.G, color.B, color.A);
            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_LINES);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);
            OpenGLx64API.GLEnd();
        }
        public void FillRectangle(GLRectangle rect, GLColor color)
        {
            float paddingX = 1 / viewport.Width;
            float paddingY = 1 / viewport.Height;

            float x1 = GLMath.Normalize(rect.X / viewport.Width) + paddingX;
            float y1 = -GLMath.Normalize(rect.Y / viewport.Height) - paddingY;

            float x2 = GLMath.Normalize((rect.X + rect.Width) / viewport.Width) - paddingX;
            float y2 = -GLMath.Normalize((rect.Y + rect.Height) / viewport.Height) + paddingY;


            OpenGLx64API.GLColor4f(color.R, color.G, color.B, color.A);
            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_POLYGON);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);
            OpenGLx64API.GLEnd();
        }
        public void LinearGradiantRectangle_Horizontal(GLRectangle rect, GLColor startcolor, GLColor endcolor)
        {
            float paddingX = 1 / viewport.Width;
            float paddingY = 1 / viewport.Height;

            float x1 = GLMath.Normalize(rect.X / viewport.Width) + paddingX;
            float y1 = -GLMath.Normalize(rect.Y / viewport.Height) - paddingY;

            float x2 = GLMath.Normalize((rect.X + rect.Width) / viewport.Width) - paddingX;
            float y2 = -GLMath.Normalize((rect.Y + rect.Height) / viewport.Height) + paddingY;


            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_POLYGON);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);

            OpenGLx64API.GLEnd();
        }
        public void LinearGradiantRectangle_Veritcal(GLRectangle rect, GLColor startcolor, GLColor endcolor)
        {
            float paddingX = 1 / viewport.Width;
            float paddingY = 1 / viewport.Height;

            float x1 = GLMath.Normalize(rect.X / viewport.Width) + paddingX;
            float y1 = -GLMath.Normalize(rect.Y / viewport.Height) - paddingY;

            float x2 = GLMath.Normalize((rect.X + rect.Width) / viewport.Width) - paddingX;
            float y2 = -GLMath.Normalize((rect.Y + rect.Height) / viewport.Height) + paddingY;


            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_POLYGON);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x2, y1, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x2, y2, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);

            OpenGLx64API.GLColor4f(endcolor.R, endcolor.G, endcolor.B, endcolor.A);
            OpenGLx64API.GLVertex3f(x1, y2, 0f);

            OpenGLx64API.GLColor4f(startcolor.R, startcolor.G, startcolor.B, startcolor.A);
            OpenGLx64API.GLVertex3f(x1, y1, 0f);

            OpenGLx64API.GLEnd();
        }
        public void FillCircle(GLRectangle rect, GLColor color)
        {
            OpenGLx64API.GLColor4f(color.R, color.G, color.B, color.A);
            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_POLYGON);

            float cX = GLMath.Normalize((rect.X + (rect.Width / 2)) / viewport.Width);
            float cY = -GLMath.Normalize((rect.Y + (rect.Height / 2)) / viewport.Height);

            float r = 0;
            if (rect.Width > rect.Height)
                r = (rect.Height / 2) / viewport.Height;
            else
                r = (rect.Width / 2) / viewport.Width;

            for (int angle = 0; angle < 360; angle++)
            {
                double rad = angle * Math.PI / 180;

                float x = r * (float)Math.Cos(rad);
                float y = r * (float)Math.Sin(rad);

                OpenGLx64API.GLVertex3f(x + cX, y + cY, 0f);
            }
            OpenGLx64API.GLEnd();
        }
        public void ComplexEffect(uint shader, GLComplexShape shape)
        {
            OpenGLx64API.GLEnableVertexArray(shape.bufferId, 7, new int[] { 0, 3 }, new int[] { 3, 4 }, 2);
            OpenGLx64API.GLUseShader(shader);
            OpenGLx64API.GLDraw(OpenGLx64API.GLMode.GL_POLYGON, shape.count);
            OpenGLx64API.GLUseShader(0);
        }
        public void FillPath(Vector3[] points, GLColor color)
        {
            OpenGLx64API.GLColor4f(color.R, color.G, color.B, color.A);
            OpenGLx64API.GLBegin(OpenGLx64API.GLMode.GL_POLYGON);
            for (int i = 0; i < points.Length; i++)
            {
                OpenGLx64API.GLVertex3f(points[i].X, points[i].Y, points[i].Z);
            }
            OpenGLx64API.GLEnd();
        }
        public void ClipInto(GLPath path, GLRectangle rect)
        {
            List<Vector3> vecs = new List<Vector3>();

            foreach (var item in path.vectors)
            {
                if (rect.Contains(new GLPoint(item.X, item.Y)))
                {
                    vecs.Add(new Vector3(GLMath.Normalize(item.X / viewport.Width), -GLMath.Normalize(item.Y / viewport.Height), item.Z));
                }
            }
            FillPath(vecs.ToArray(), new GLColor(1.0f, 0.5f, 0.2f, 1f));
        }
        public void Clear(GLColor backColor)
        {
            OpenGLx64API.GLClear(backColor.R, backColor.G, backColor.B, backColor.A);
        }
        public void SetClipRectangle(GLRectangle rect)
        {
            OpenGLx64API.GLEnableScissor(rect.X / viewport.Width, rect.Y / viewport.Height, rect.Width / viewport.Width, rect.Height / viewport.Height);
        }
        public void UnsetClipRectangle()
        {
            OpenGLx64API.GLDisableScissor();
        }
    }
}

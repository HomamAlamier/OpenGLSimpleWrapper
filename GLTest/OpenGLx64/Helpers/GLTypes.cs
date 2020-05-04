using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenGLx64.Drawing
{
    public struct GLRectangle
    {
        public float X
        {
            get => x;
            set => x = value;
        }
        public float Y
        {
            get => y;
            set => y = value;
        }
        public float Width
        {
            get => w;
            set => w = value;
        }
        public float Height
        {
            get => h;
            set => h = value;
        }
        float x;
        float y;
        float w;
        float h;
        public GLRectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.w = width;
            this.h = height;
        }
        public GLRectangle(GLPoint point, GLSize size)
        {
            x = point.X;
            y = point.Y;
            w = size.Width;
            h = size.Height;
        }
        public bool Contains(GLPoint point)
        {
            return point.X >= x && point.Y >= y && point.X < (x + w) && point.Y < (y + h);
        }
        public GLRectangle Normalize(GLSize viewport)
        {
            return new GLRectangle(
               GLMath.Normalize(x / viewport.Width),
              -GLMath.Normalize(y / viewport.Height),
               GLMath.Normalize(w / viewport.Width),
              -GLMath.Normalize(h / viewport.Height)
               );
        }
        public override string ToString()
        {
            return $"[X={x}, Y={y}, Width={w}, Height={h}]";
        }
    }
    public struct GLSize
    {
        public float Width { get => w; set => w = value; }
        public float Height { get => h; set => h = value; }
        float w, h;
        public GLSize(float width, float height)
        {
            w = width;
            h = height;
        }
    }
    public struct Vector3
    {
        public float X => x;
        public float Y => y;
        public float Z => z;
        float x, y, z;
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public float[] ToArray() => new float[3] { x, y, z };
        public override string ToString()
        {
            return $"[X={x}, Y={y}, Z={z}]";
        }
    }
    public struct Vector2
    {
        public float X => x;
        public float Y => y;
        float x, y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public float[] ToArray() => new float[2] { x, y };
    }
    public struct GLColor
    {
        public static GLColor Red => new GLColor(1f, 0f, 0f, 1f);
        public static GLColor Green => new GLColor(0f, 1f, 0f, 1f);
        public static GLColor Blue => new GLColor(0f, 0f, 1f, 1f);
        public static GLColor Black => new GLColor(0f, 0f, 0f, 1f);
        public static GLColor White => new GLColor(1f, 1f, 1f, 1f);
        public static GLColor Transperant => new GLColor(0f, 0f, 0f, 0f);
        public float R => r;
        public float G => g;
        public float B => b;
        public float A => a;
        float r;
        float g;
        float b;
        float a;
        public GLColor(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        public GLColor(System.Drawing.Color color)
        {
            r = color.R / 255f;
            g = color.G / 255f;
            b = color.B / 255f;
            a = color.A / 255f;
        }
    }
    public struct GLPoint
    {
        float x, y;
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public GLPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct GLComplexShape
    {
        public int bufferId;
        public int len;
        public int count;
        public int[] offsets;
        public int[] dataLen;
        public GLPoint[] Points;
        public GLColor[] Colors;
        public void CreateVertexBuffer()
        {
            List<float> buf = new List<float>();
            for (int i = 0; i < Points.Length; i++)
            {
                buf.AddRange(new float[]
                {
                    Points[i].X, Points[i].Y, 0f, Colors[i].R, Colors[i].G, Colors[i].B, Colors[i].A
                });
            }
            var x = OpenGLx64API.GLCreateVertexBuffer(buf.ToArray(), buf.Count, 7, new int[] { 0, 3 }, new int[] { 3, 4 }, 2);
            int[] d = new int[4];
            Marshal.Copy(x, d, 0, 4);
            len = 2;
            offsets = new int[] { 0, 3 };
            dataLen = new int[] { 3, 4 };
            bufferId = d[d.Length - 1];
            count = buf.Count / 7;
        }
    }

    public struct GLPath
    {
        public Vector3[] vectors;
    }
}

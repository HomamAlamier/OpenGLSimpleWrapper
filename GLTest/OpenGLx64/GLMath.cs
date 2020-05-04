using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGLx64.Drawing;
namespace OpenGLx64
{
    public static class GLMath
    {
        public static float Normalize(float value)
        {
            return value * 2 - 1;
        }
        public static Vector3[] Circle3f(float cx, float cy, float r)
        {
            List<Vector3> vecs = new List<Vector3>();
            //r = GLMath.Normalize(r);

            for (int angle = 0; angle < 360; angle++)
            {
                double rad = angle * Math.PI / 180;
                float x = r * (float)Math.Cos(rad);
                float y = r * (float)Math.Sin(rad);
                vecs.Add(new Vector3(x + cx, y + cy, 0f));
            }
            return vecs.ToArray();
        }
    }

}

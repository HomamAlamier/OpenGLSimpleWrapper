using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGLx64;
using OpenGLx64.GLForms;
using OpenGLx64.Drawing;
using System.IO;
namespace GLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenGLx64API.SetLogCallBack((str) =>
            {
                Console.WriteLine(str);
            });
            OpenGLx64API.GLInit();
            GLForm frm = new GLForm();
            frm.KeyPress += (s, e) =>
            {
                Console.WriteLine($"Key={e.Key}, ctrl={e.Control}, alt={e.Alt}, shift={e.Shift}");
            };
            frm.BackColor = new GLColor(0.44f, 0.44f, 0.44f, 1f);
            OpenGLx64API.GLEnableBlending();
            //var shader = OpenGLx64.GLCreateShader(File.ReadAllText("vert.glsl"), File.ReadAllText("frag.glsl"));
            //OpenGLx64.GLUseShader(shader);
            GLControl c = new GLControl(frm.Size, frm.Handle);
            c.Location = new GLPoint(0, 0);
            c.Size = new GLSize(frm.Size.Width, 50);
            c.BackColor = new GLColor(1f, 0f, 0f, 1f);

            frm.Controls.Add(c);
            frm.MainLoop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGLx64.Drawing;
namespace OpenGLx64.GLForms
{
    public class GLFormKeyPressEventArgs : EventArgs
    {
        public bool Control { get; private set; }
        public bool Alt { get; private set; }
        public bool Shift { get; private set; }
        public GLKeys Key { get; private set; }
        public GLFormKeyPressEventArgs(bool control, bool alt, bool shift, GLKeys key)
        {
            Control = control;
            Alt = alt;
            Shift = shift;
            Key = key;
        }
    }
    public class GLMouseEventArgs : EventArgs
    {
        public GLMouseButton Button { get; private set; }
        public GLPoint Location { get; private set; }
        public GLMouseEventArgs(GLMouseButton button, GLPoint point)
        {
            Button = button;
            Location = point;
        }
    }
}

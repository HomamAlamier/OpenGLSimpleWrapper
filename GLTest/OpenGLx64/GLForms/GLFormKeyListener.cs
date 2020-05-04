using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGLx64.Drawing;
namespace OpenGLx64.GLForms
{
    public class GLFormKeyListener
    {
        IntPtr handle;
        public event EventHandler<GLFormKeyPressEventArgs> KeyPress;
        bool ctrl, alt, shift;
        Array keys = Enum.GetValues(typeof(GLKeys));
        GLKeys[] dkeys;
        long lastTick;
        int sbk = 80;
        GLKeys curKey = 0;
        public int SleepBetweenKeys
        {
            get => sbk;
            set => sbk = value;
        }




        public GLFormKeyListener(IntPtr handle)
        {
            this.handle = handle;
            dkeys = new GLKeys[]
            {
                GLKeys.LEFT_SHIFT,GLKeys.RIGHT_SHIFT,
                GLKeys.LEFT_CONTROL,GLKeys.RIGHT_CONTROL,
                GLKeys.LEFT_ALT,GLKeys.RIGHT_ALT
            };
        }
        public void MainLoopFunction()
        {
            if (KeyPress == null) return;
            long curTick = DateTime.Now.Ticks;

            if (curTick > lastTick + (10000 * sbk))
            {
                lastTick = curTick;
            }
            else return;

            if (OpenGLx64API.GLGetKey(handle, curKey) == 0) curKey = 0;

            ctrl = OpenGLx64API.GLGetKey(handle, GLKeys.LEFT_CONTROL) > 0 || OpenGLx64API.GLGetKey(handle, GLKeys.RIGHT_CONTROL) > 0;
            alt = OpenGLx64API.GLGetKey(handle, GLKeys.LEFT_ALT) > 0 || OpenGLx64API.GLGetKey(handle, GLKeys.RIGHT_ALT) > 0;
            shift = OpenGLx64API.GLGetKey(handle, GLKeys.LEFT_SHIFT) > 0 || OpenGLx64API.GLGetKey(handle, GLKeys.RIGHT_SHIFT) > 0;
            foreach (var key in keys)
            {
                if (OpenGLx64API.GLGetKey(handle, (GLKeys)((int)key)) == 1 && !dkeys.Contains((GLKeys)((int)key)) && (GLKeys)((int)key) != curKey)
                {
                    KeyPress?.Invoke(this, new GLFormKeyPressEventArgs(ctrl, alt, shift, (GLKeys)((int)key)));
                    curKey = (GLKeys)((int)key);
                }
            }
        }
    }
}

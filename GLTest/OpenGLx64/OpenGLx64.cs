using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using GLFWwindow = System.IntPtr;
using System.IO;

namespace OpenGLx64
{
    public enum GLKeys
    {
        SPACE = 32,
        APOSTROPHE = 39,
        COMMA = 44,
        MINUS = 45,
        PERIOD = 46,
        SLASH = 47,
        NUM0 = 48,
        NUM1 = 49,
        NUM2 = 50,
        NUM3 = 51,
        NUM4 = 52,
        NUM5 = 53,
        NUM6 = 54,
        NUM7 = 55,
        NUM8 = 56,
        NUM9 = 57,
        SEMICOLON = 59,
        EQUAL = 61,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LEFT_BRACKET = 91,
        BACKSLASH = 92,
        RIGHT_BRACKET = 93,
        GRAVE_ACCENT = 96,
        WORLD_1 = 161,
        WORLD_2 = 162,
        ESCAPE = 256,
        ENTER = 257,
        TAB = 258,
        BACKSPACE = 259,
        INSERT = 260,
        DELETE = 261,
        RIGHT = 262,
        LEFT = 263,
        DOWN = 264,
        UP = 265,
        PAGE_UP = 266,
        PAGE_DOWN = 267,
        HOME = 268,
        END = 269,
        CAPS_LOCK = 280,
        SCROLL_LOCK = 281,
        NUM_LOCK = 282,
        PRINT_SCREEN = 283,
        PAUSE = 284,
        F1 = 290,
        F2 = 291,
        F3 = 292,
        F4 = 293,
        F5 = 294,
        F6 = 295,
        F7 = 296,
        F8 = 297,
        F9 = 298,
        F10 = 299,
        F11 = 300,
        F12 = 301,
        KP_0 = 320,
        KP_1 = 321,
        KP_2 = 322,
        KP_3 = 323,
        KP_4 = 324,
        KP_5 = 325,
        KP_6 = 326,
        KP_7 = 327,
        KP_8 = 328,
        KP_9 = 329,
        KP_DECIMAL = 330,
        KP_DIVIDE = 331,
        KP_MULTIPLY = 332,
        KP_SUBTRACT = 333,
        KP_ADD = 334,
        KP_ENTER = 335,
        KP_EQUAL = 336,
        LEFT_SHIFT = 340,
        LEFT_CONTROL = 341,
        LEFT_ALT = 342,
        LEFT_SUPER = 343,
        RIGHT_SHIFT = 344,
        RIGHT_CONTROL = 345,
        RIGHT_ALT = 346,
        RIGHT_SUPER = 347,
        MENU = 348
    }
    public enum GLMouseButton
    {
        NONE = -1,
        LEFT = 0,
        RIGHT = 1,
        MIDDLE = 2
    }
    public enum GLInitError
    {
        OK = 0,
        FailedToInitializeGLFW = -1,
        FailedToInitializeGLEW = -2
    }
    public enum GLCreateWindowError
    {
        OK = 0,
        FailedToInitializeGLEW = -1,
        NotInitializedWithWindowModeEnabled = -2
    }
    public enum GLPushShaderError
    {
        OK = 0,
        FailedToCompileVetexShader = -1,
        FailedToCompileFragmentShader = -2,
        FailedToLinkProgram = -3
    }
    public enum GLDrawError
    {
        OK = 0,
        TextureNotInitialized = -1,
        ShaderNotInitialized = -2,
    }
    public enum GLPushUniformError
    {
        OK = 0,
        ShaderNotInitialized = -1,
        UniformNameNotFound = -2
    }
    public static class OpenGLx64API
    {

        public const int GLFW_RESIZABLE = 0x00020003;
        public const int GLFW_VISIBLE = 0x00020004;
        public const int GL_TRUE = 1;
        public const int GL_FALSE = 0;
        public enum GLMode
        {
            GL_LINES = 0x0001,
            GL_LINE_LOOP = 0x0002,
            GL_POLYGON = 0x0009,
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void LogCallBack(string line);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WindowResizeCallBack(GLFWwindow window, int width, int height);

        //[UnmanagedFunctionPointer(CallingConvention.StdCall)]
        //public delegate void WindowResizeCallBack(IntPtr window, int width, int height);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLInit();
        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLFWwindow GLCreateWindow(int x,
                                                    int y,
                                                    int w,
                                                    int h,
                                                    bool fullscreen,
                                                    bool sizable,
                                                    bool visible,
                                                    string title);


        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLMakeContextCurrent(GLFWwindow ptr);



        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetLogCallBack(LogCallBack callback);


        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLDraw(GLMode mode, int len);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLClear(float r, float g, float b, float a);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLEnableVertexArray(int bufferID, int itemsize, int[] offsets, int[] dataLen, int len);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLUseShader(uint shaderID);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLFreeVertexBuffer(int bufferId, int len);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetUniformFloat(uint shaderID, string name, float value);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetUniformFloatArray(uint shaderID, string name, float[] value, int count);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetUniformInt(uint shaderID, string name, int value);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLBegin(GLMode mode);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GLGetCursorPos(GLFWwindow ptr);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLVertex3f(float x, float y, float z);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLColor4f(float r, float g, float b, float a);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLEnd();

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLEnableBlending();

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetWindowSize(GLFWwindow ptr, int newWidth, int newHeight);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetWindowAttrib(GLFWwindow ptr, int attrib, int value);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetUniformIntArray(uint shaderID, string name, int[] value, int count);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSetWindowSizeCallBack(GLFWwindow window, WindowResizeCallBack callback);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLViewport(int x, int y, int w, int h);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLSwapBuffers(GLFWwindow ptr);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLEnableScissor(float x, float y, float w, float h);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GLDisableScissor();

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLGetKey(GLFWwindow ptr, GLKeys key);


        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GLGetMouseButton(GLFWwindow ptr, GLMouseButton key);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint GLCreateShader(string VertexShaderCode, string FragmentShaderCode);

        [DllImport("OpenGLx64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GLCreateVertexBuffer(float[] points, int arrayLen, int itemsize, int[] offsets, int[] dataLen, int offsetsLen);
    }



}

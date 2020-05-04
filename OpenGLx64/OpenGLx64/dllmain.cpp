// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include "OpenGL.h"

extern "C"
{
	__declspec(dllexport) int _stdcall GLInit()
	{
		return _Init();
	}
	__declspec(dllexport) void* _cdecl GLCreateWindow(int x,
		int y,
		int w,
		int h,
		bool fullscreen,
		bool sizable,
		bool visible,
		const char* title)
	{
		return _CreateWindow(x, y, w, h, fullscreen, sizable, visible, title);
	}
	__declspec(dllexport) int _cdecl GLMakeContextCurrent(void* ptr)
	{
		return _MakeContextCurrent((GLFWwindow*)ptr);
	}
	__declspec(dllexport) void _stdcall GLSetViewport(int x, int y, int w, int h)
	{
		_SetViewport(x, y, w, h);
	}
	__declspec(dllexport) void _stdcall SetLogCallBack(LOGCALLBACK cb)
	{
		_SetLogCallBack(cb);
	}
	__declspec(dllexport) void _stdcall GLDraw(int mode, int len)
	{
		_Draw(mode, len);
	}
	__declspec(dllexport) void _stdcall GLClear(float r, float g, float b, float a)
	{
		glClearColor(r, g, b, a);
		glClear(GL_COLOR_BUFFER_BIT);
	}
	__declspec(dllexport) void _stdcall GLSwapBuffers(void* ptr)
	{
		glfwSwapBuffers((GLFWwindow*)ptr);
		glfwPollEvents();
	}
	__declspec(dllexport) void _stdcall GLUseShader(uint ptr)
	{
		glUseProgram(ptr);
	}
	__declspec(dllexport) void _stdcall GLSetUniformFloat(uint ptr, const char* name, float val)
	{
		_SetUniform(ptr, name, val);
	}
	__declspec(dllexport) void _stdcall GLSetUniformInt(uint ptr, const char* name, int val)
	{
		_SetUniform(ptr, name, val);
	}
	__declspec(dllexport) void _stdcall GLSetUniformFloatArray(uint ptr, const char* name, float* val, int count)
	{
		_SetUniform(ptr, name, val, count);
	}
	__declspec(dllexport) void _stdcall GLSetUniformIntArray(uint ptr, const char* name, float* val, int count)
	{
		_SetUniform(ptr, name, val, count);
	}
	__declspec(dllexport) void _stdcall GLFreeVertexBuffer(int bufferId, int len)
	{
		for (size_t i = 0; i < len; i++)
		{
			glDisableVertexAttribArray(i);
		}
		glDeleteBuffers(1, (GLuint*)&bufferId);
	}
	__declspec(dllexport) void _stdcall GLEnableVertexArray(int bufferID, int itemsize, int* offsets, int* dataLen, int len)
	{
		glBindBuffer(GL_ARRAY_BUFFER, bufferID);
		for (size_t i = 0; i < len; i++)
		{
			glVertexAttribPointer(i, dataLen[i], GL_FLOAT, GL_FALSE, itemsize * sizeof(float), (void*)(offsets[i] * sizeof(float)));
			glEnableVertexAttribArray(i);
		}
	}
	__declspec(dllexport) void _stdcall GLUnBindVertexBuffer(int* ptr, int len)
	{
		for (size_t i = 0; i < len - 2; i++)
		{
			glDisableVertexAttribArray(ptr[i]);
		}
	}
	__declspec(dllexport) void _stdcall GLSetWindowSize(void* ptr, int nw, int nh)
	{
		glfwSetWindowSize((GLFWwindow*)ptr, nw, nh);
	}
	__declspec(dllexport) void _stdcall GLSetWindowSizeCallBack(void* ptr, GLFWwindowsizefun ptr2)
	{
		glfwSetWindowSizeCallback((GLFWwindow*)ptr, ptr2);
	}
	__declspec(dllexport) void _stdcall GLViewport(int x, int y, int w, int h)
	{
		glViewport(x, y, w, h);
	}
	__declspec(dllexport) void _stdcall GLSetWindowAttrib(void* ptr, int attr, int value)
	{
		glfwSetWindowAttrib((GLFWwindow*)ptr, attr, value);
	}
	__declspec(dllexport) int* _cdecl GLCreateVertexBuffer(float* points, int arrayLen, int itemsize, int* offsets, int* dataLen, int offsetsLen)
	{
		return _CreateVertexBuffer(points, arrayLen, itemsize, offsets, dataLen, offsetsLen);
	}
	__declspec(dllexport) int _cdecl GLGetKey(void* ptr, int key)
	{
		return glfwGetKey((GLFWwindow*)ptr, key);
	}
	__declspec(dllexport) int _cdecl GLGetMouseButton(void* ptr, int key)
	{
		return glfwGetMouseButton((GLFWwindow*)ptr, key);
	}
	__declspec(dllexport) void _stdcall GLBegin(int mode)
	{
		glBegin(mode);
	}
	__declspec(dllexport) void _stdcall GLEnableBlending()
	{
		glEnable(GL_BLEND);
		glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	}
	__declspec(dllexport) void _stdcall GLEnableScissor(float x, float y, float w, float h)
	{
		//glEnable(GL_SCISSOR_BOX);
		glEnable(GL_SCISSOR_TEST);
		glScissor(x, y, w, h);
	}
	__declspec(dllexport) void _stdcall GLDisableScissor()
	{
		//glDisable(GL_SCISSOR_BOX);
		glDisable(GL_SCISSOR_TEST);
	}
	__declspec(dllexport) void _stdcall GLVertex3f(float x, float y, float z)
	{
		glVertex3f(x, y, z);
	}
	__declspec(dllexport) void _stdcall GLEnd()
	{
		glEnd();
	}
	_declspec(dllexport) float* _cdecl GLGetCursorPos(void* ptr)
	{
		double pnt[2];
		glfwGetCursorPos((GLFWwindow*)ptr, &pnt[0], &pnt[1]);
		float xpnt[2];
		xpnt[0] = (float)pnt[0];
		xpnt[1] = (float)pnt[1];
		return xpnt;
	}
	__declspec(dllexport) void _stdcall GLColor4f(float r, float g, float b, float a)
	{
		glColor4f(r, g, b, a);
	}
	__declspec(dllexport) void _stdcall GLSetInput(void* ptr, GLFWkeyfun func)
	{
		glfwSetKeyCallback((GLFWwindow*)ptr, func);
	}
	__declspec(dllexport) uint _cdecl GLCreateShader(const char* VertexSourcePointer, const char* FragmentSourcePointer)
	{
		return _CreateShader(VertexSourcePointer, FragmentSourcePointer);
	}

}


BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}


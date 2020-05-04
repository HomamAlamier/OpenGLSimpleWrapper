
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
//GLEW
#define GLEW_STATIC
#include <GL/glew.h>
#include <glfw/glfw3.h>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
//else
#include <vector>
#include <iostream>
#include <fstream>
#include <sstream>


typedef void(*LOGCALLBACK)(const char*);
typedef unsigned int uint;
struct Window
{
	int x;
	int y;
	int w;
	int h;
	bool fullscreen;
	bool sizable;
	bool visible;
	const char* title;
};
struct ViewPort
{
	int x, y, w, h;
};


int _Init();
GLFWwindow* _CreateWindow(int x,
	int y,
	int w,
	int h,
	bool fullscreen,
	bool sizable,
	bool visible,
	const char* title);
int _MakeContextCurrent(GLFWwindow* wind);
void _SetViewport(int x, int y, int w, int h);
void _SetLogCallBack(LOGCALLBACK cb);
int* _CreateVertexBuffer(float* points, int arrayLen, int itemsize, int* offsets, int* dataLen, int offsetsLen);
void _Draw(int mode, int length);
uint _CreateShader(const char* VertexSourcePointer, const char* FragmentSourcePointer);
void _SetUniform(uint shader, const char* name, float val);
void _SetUniform(uint shader, const char* name, int val);
void _SetUniform(uint shader, const char* name, float* val, int count);
void _SetUniform(uint shader, const char* name, int* val, int count);
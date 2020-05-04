#include "pch.h"
#include "OpenGL.h"

LOGCALLBACK logCallBack = NULL;
std::stringstream strStream;
int logLine = 0;
bool glewNeedInit = true;


template<typename... ArgTypes>
void _log(ArgTypes... args);
template<typename T, typename... ArgTypes>
void _log(T t, ArgTypes... args)
{
	strStream << t;
	_log(args...);
}
template<> void _log()
{
	if (logCallBack != NULL) logCallBack(strStream.str().c_str());
}

template<typename... ArgTypes>
void logf(ArgTypes... args) {
	strStream = std::stringstream();
	strStream << "[ " << logLine++ << " ] ";
	_log(args...);
}

void glfwError(int code, const char* d)
{
	logf("(", code, ") ", d);
}

int _Init()
{
	if (!glfwInit())
	{
		logf("GLFW initialization failed !");
		glfwTerminate();
		return -1;
	}
	return 0;
}
GLFWwindow* _CreateWindow(int x,
	int y,
	int w,
	int h,
	bool fullscreen,
	bool sizable,
	bool visible,
	const char* title)
{
	logf(
		"Create Window :\n x=", x,
		"\ny=", y, "\nw=", w,
		"\nh=", h, "\nfullscreen=", fullscreen,
		"\nvisable=", visible, "\nsizable=", sizable
	);
	GLFWmonitor* mon = fullscreen ? glfwGetPrimaryMonitor() : NULL;
	glfwWindowHint(GLFW_VISIBLE, visible ? GL_TRUE : GL_FALSE);
	glfwWindowHint(GLFW_RESIZABLE, sizable ? GL_TRUE : GL_FALSE);

	GLFWwindow* wnd = glfwCreateWindow(w, h, title, mon, NULL);

	glfwSetInputMode(wnd, GLFW_STICKY_KEYS, GL_TRUE);

	return wnd;
}
int _MakeContextCurrent(GLFWwindow* wind)
{
	glfwMakeContextCurrent(wind);
	if (glewNeedInit && glewInit() != GLEW_OK)
	{
		return -1;
	}
	glewNeedInit = false;
	return 0;
}
void _SetViewport(int x, int y, int w, int h)
{
	glViewport(x, y, w, h);
}
void _SetLogCallBack(LOGCALLBACK cb)
{
	logCallBack = cb;
}
int* _CreateVertexBuffer(float* points, int arrayLen, int itemsize, int* offsets, int* dataLen, int offsetsLen)
{
	logf("CreateVertexBuffer indexsLen = ", offsetsLen + 2);
	int* indexs = new int[(int)(offsetsLen + 2)];
	unsigned int VAO, VBO;
	glGenBuffers(1, &VBO);
	glGenVertexArrays(1, &VAO);
	glBindVertexArray(VAO);
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(float) * arrayLen, points, GL_STATIC_DRAW);
	for (size_t i = 0; i < offsetsLen; i++)
	{
		logf("offset=", offsets[i], ", dataLen=", dataLen[i], ", index=", i);
		glVertexAttribPointer(i, dataLen[i], GL_FLOAT, GL_FALSE, itemsize * sizeof(float), (void*)(offsets[i] * sizeof(float)));
		indexs[i] = i;
	}
	indexs[offsetsLen] = VAO;
	indexs[offsetsLen + 1] = VBO;
	return indexs;
}
void _Draw(int mode, int length)
{
	glDrawArrays(mode, 0, length);
	glFlush();
}
uint _CreateShader(const char* VertexSourcePointer, const char* FragmentSourcePointer)
{
	// Create the shaders
	GLuint VertexShaderID = glCreateShader(GL_VERTEX_SHADER);
	GLuint FragmentShaderID = glCreateShader(GL_FRAGMENT_SHADER);
	GLint Result = GL_FALSE;
	int InfoLogLength;

	// Compile Vertex Shader
	logf("Compiling Vertex Shader...");
	glShaderSource(VertexShaderID, 1, &VertexSourcePointer, NULL);
	glCompileShader(VertexShaderID);

	// Check Vertex Shader
	glGetShaderiv(VertexShaderID, GL_COMPILE_STATUS, &Result);
	glGetShaderiv(VertexShaderID, GL_INFO_LOG_LENGTH, &InfoLogLength);
	if (InfoLogLength > 0) {
		std::vector<char> VertexShaderErrorMessage(InfoLogLength + 1);
		glGetShaderInfoLog(VertexShaderID, InfoLogLength, NULL, &VertexShaderErrorMessage[0]);
		if (VertexShaderErrorMessage[0] != 0)
		{
			logf("Vertex Shader Error : ", &VertexShaderErrorMessage[0]);
			return -1;
		}
	}

	logf("Compiling Fragment Shader...");
	// Compile Fragment Shader
	glShaderSource(FragmentShaderID, 1, &FragmentSourcePointer, NULL);
	glCompileShader(FragmentShaderID);

	// Check Fragment Shader
	glGetShaderiv(FragmentShaderID, GL_COMPILE_STATUS, &Result);
	glGetShaderiv(FragmentShaderID, GL_INFO_LOG_LENGTH, &InfoLogLength);
	if (InfoLogLength > 0) {
		std::vector<char> FragmentShaderErrorMessage(InfoLogLength + 1);
		glGetShaderInfoLog(FragmentShaderID, InfoLogLength, NULL, &FragmentShaderErrorMessage[0]);
		if (FragmentShaderErrorMessage[0] != 0)
		{
			logf("Fragment Shader Error : ", &FragmentShaderErrorMessage[0]);
			return -2;
		}
	}

	logf("Linking Shader...");
	// Link the program
	uint ProgramID = glCreateProgram();
	glAttachShader(ProgramID, VertexShaderID);
	glAttachShader(ProgramID, FragmentShaderID);
	glLinkProgram(ProgramID);

	// Check the program
	glGetProgramiv(ProgramID, GL_LINK_STATUS, &Result);
	glGetProgramiv(ProgramID, GL_INFO_LOG_LENGTH, &InfoLogLength);
	if (InfoLogLength > 0) {
		std::vector<char> ProgramErrorMessage(InfoLogLength + 1);
		glGetProgramInfoLog(ProgramID, InfoLogLength, NULL, &ProgramErrorMessage[0]);
		if (ProgramErrorMessage[0] != 0)
		{
			logf("Program Error : ", &ProgramErrorMessage[0]);
			return -3;
		}
	}

	glDetachShader(ProgramID, VertexShaderID);
	glDetachShader(ProgramID, FragmentShaderID);

	glDeleteShader(VertexShaderID);
	glDeleteShader(FragmentShaderID);

	return ProgramID;
}
void _SetUniform(uint shader, const char* name, float val)
{
	uint loc = glGetUniformLocation(shader, name);
	glUniform1f(loc, val);
}
void _SetUniform(uint shader, const char* name, float* val, int count)
{
	uint loc = glGetUniformLocation(shader, name);
	glUniform1fv(loc, count, val);
}
void _SetUniform(uint shader, const char* name, int val)
{
	uint loc = glGetUniformLocation(shader, name);
	glUniform1i(loc, val);
}
void _SetUniform(uint shader, const char* name, int* val, int count)
{
	uint loc = glGetUniformLocation(shader, name);
	glUniform1iv(loc, count, val);
}
#include "OpenCV.h"


extern "C" _declspec(dllexport) uchar* _stdcall ImageInitial(char* fileName, int & thres, bool isMatch, int selectedNo);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgOriginal();
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgOriginalHist();
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgGray();
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgHist(int selectedHist, int thresholdValue);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgFilter();
extern "C" _declspec(dllexport) void _stdcall ImgAmplify(int amplifyImage);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgBinary(int thresholdValue);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgDenoising(int opera, int sharp, int size);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgContours(int height, int width, int area);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgMinRect(int height, int width, int area);
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgRectification1();
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgRectification2();
extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgWhiteBlackBalance();
extern "C" _declspec(dllexport) void _stdcall DestroyInstance();
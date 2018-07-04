#include "APIEntry.h"

extern "C" _declspec(dllexport) uchar* _stdcall ImageInitial(char* fileName, int & thres, bool isMatch, int selectedNo)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImageInitial(fileName, OUT thres, isMatch, selectedNo);
}

extern "C" _declspec(dllexport) void _stdcall ImgAmplify(int amplifyImage)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgAmplify(amplifyImage);
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgOriginal()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgOriginal();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgOriginalHist()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgOriginalHist();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgGray()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgGray();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgHist(int selectedHist, int thresholdValue)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgHist(selectedHist, thresholdValue);
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgFilter()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgFilter();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgBinary(int thresholdValue)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgBinary(thresholdValue);
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgDenoising(int opera, int sharp, int size)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgDenoising(opera, sharp, size);
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgContours(int height, int width, int area)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgContours(height, width, area);
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgMinRect(int height, int width, int area)
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgMinRect(height, width, area);
}

extern "C" _declspec(dllexport) int _stdcall GetReadDataNum()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->GetReadDataNum();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgRectification1()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgRectification1();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgRectification2()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgRectification2();
}

extern "C" _declspec(dllexport) IMAGEPARAM* _stdcall ImgWhiteBlackBalance()
{
	OpenCvDll* opencvDll = OpenCvDll::GetInstance();
	return opencvDll->ImgWhiteBlackBalance();
}

extern "C" _declspec(dllexport) void _stdcall DestroyInstance()
{
	OpenCvDll::DestroyInstance();
}
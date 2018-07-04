#include<iostream>
#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/opencv.hpp>
#include "stdafx.h"
#include "Define.h"

using namespace cv;

class OpenCvDll
{
private:
	static OpenCvDll* me;
	string fileDataName;
	int thresholdData;
	int dataNum;
	Mat imageOriginal;
	Mat imageOriginalHist;
	Mat imageGray;
	Mat imageGauss;
	Mat imageHistGray;
	Mat imageHistGauss;
	Mat imageHistBinary;
	Mat imageBinary;
	Mat imageDenoising;
	Mat imageContours;
	Mat imageMinRect;
	Mat imageRectification1;
	Mat imageRectification2;
	Mat imageOrigWhiteBlackBalance;

public:
	static OpenCvDll* GetInstance(void);
	static BOOL DestroyInstance(void);

	uchar* ImageInitial(char* fileName, int & thres, bool isMatch, int selectedNo);
	Mat GetimageOriginalHist(Mat img);
	Mat GetImageHist(Mat imgGauss);
	Mat GetImageDenoising(Mat imgBinary);
	Mat GetImageContours(Mat imgDenoising, int height, int width, int area);
	Mat GetImageMinRect(Mat imgDenoising, int height, int width, int area);
	int ReadDataNum(char* fileName);
	Mat DataRead(char* fileName, int selectedNo);
	int GetReadDataNum();
	Mat GetRectification1(Mat imgGray);
	Mat GetRectification2(Mat imgRectification1);
	Mat WhiteBlackBalance(Mat imgOriginal);

	IMAGEPARAM* ImgOriginal();
	IMAGEPARAM* ImgOriginalHist();
	IMAGEPARAM* ImgGray();
	IMAGEPARAM* ImgHist(int selectedHist, int thresholdValue);
	IMAGEPARAM* ImgFilter();
	void ImgAmplify(int amplifyImage);
	IMAGEPARAM* ImgBinary(int thresholdValue);
	IMAGEPARAM* ImgDenoising(int opera, int sharp, int size);
	IMAGEPARAM* ImgContours(int height, int width, int area);
	IMAGEPARAM* ImgMinRect(int height, int width, int area);
	IMAGEPARAM* ImgRectification1();
	IMAGEPARAM* ImgRectification2();
	IMAGEPARAM* ImgWhiteBlackBalance();
private:
	OpenCvDll(void);
	virtual ~OpenCvDll(void);
};
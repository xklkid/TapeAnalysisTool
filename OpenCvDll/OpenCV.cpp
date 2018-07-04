#include "Struct.h"
#include "OpenCV.h"

OpenCvDll* OpenCvDll::me = NULL;

OpenCvDll::OpenCvDll(void)
{
	fileDataName = "";
	thresholdData = 0;
	dataNum = 0;
	imageOriginal = NULL;
	imageOriginalHist = NULL;
	imageGray = NULL;
	imageGauss = NULL;
	imageHistGray = NULL;
	imageHistGauss = NULL;
	imageHistBinary = NULL;
	imageBinary = NULL;
	imageDenoising = NULL;
	imageContours = NULL;
	imageMinRect = NULL;
	imageRectification1 = NULL;
	imageRectification2 = NULL;
	imageOrigWhiteBlackBalance = NULL;
	return;
}

OpenCvDll* OpenCvDll::GetInstance(void)
{
	if (OpenCvDll::me == NULL)
	{
		OpenCvDll::me = new OpenCvDll();
	}
	return me;
}

OpenCvDll::~OpenCvDll(void)
{
	try
	{
		if (!fileDataName.empty())
		{
			imageOriginal.release();
			imageOriginalHist.release();
			imageGray.release();
			imageGauss.release();
			imageHistGray.release();
			imageHistGauss.release();
			imageHistBinary.release();
			imageBinary.release();
			imageDenoising.release();
			imageContours.release();
			imageMinRect.release();
			imageRectification1.release();
			imageRectification2.release();
			imageOrigWhiteBlackBalance.release();
		}
		imageOriginal = NULL;
		imageOriginalHist = NULL;
		imageGray = NULL;
		imageGauss = NULL;
		imageHistGray = NULL;
		imageHistGauss = NULL;
		imageHistBinary = NULL;
		imageBinary = NULL;
		imageDenoising = NULL;
		imageContours = NULL;
		imageMinRect = NULL;
		imageRectification1 = NULL;
		imageRectification2 = NULL;
		imageOrigWhiteBlackBalance = NULL;
	}
	catch(...){}

}

BOOL OpenCvDll::DestroyInstance(void)
{
	BOOL ret = TRUE;
	try
	{
		if (OpenCvDll::me != NULL)
		{
			delete OpenCvDll::me;
			OpenCvDll::me = NULL;
		}
	}
	catch (...){ ret = FALSE; }
	return ret;
}

uchar* OpenCvDll::ImageInitial(char* fileName, int & thres, bool isMatch, int selectedNo)
{
	uchar* ret = SUCCESS;
	fileDataName = fileName;
	Mat tempImgGray;
	Mat tempImgGray1;

	if (isMatch)
	{
		imageOriginal = DataRead(fileName, selectedNo);
		imageOrigWhiteBlackBalance = WhiteBlackBalance(imageOriginal);
		tempImgGray = imageOrigWhiteBlackBalance;
		dataNum = ReadDataNum(fileName);
	}
	else
	{
		imageOriginal = imread(fileDataName);
		imageOriginalHist = GetimageOriginalHist(imageOriginal);
		cvtColor(imageOriginal,tempImgGray,CV_BGR2GRAY);
		tempImgGray1 = Mat(tempImgGray.rows*RESIZEPARA, tempImgGray.cols*RESIZEPARA, CV_8U);
		resize(tempImgGray, tempImgGray1, tempImgGray1.size());
	}

	imageRectification1 = GetRectification1(tempImgGray1);
	//imageRectification1 = GetRectification1(tempImgGray);

	imageRectification2 = GetRectification2(imageRectification1);

	imageGray = imageRectification2;

	imageHistGray = GetImageHist(imageGray);

	GaussianBlur(imageGray,imageGauss,Size(3,3), 4);

	imageHistGauss = GetImageHist(imageGauss);

	thres = thresholdData;

	threshold(imageGauss, imageBinary, thresholdData, 255, CV_THRESH_BINARY);

	imageDenoising = GetImageDenoising(imageBinary);

	Mat imgContours, imgMinRect;
	imageDenoising.copyTo(imgContours);
	imageDenoising.copyTo(imgMinRect);

	imageContours = GetImageContours(imgContours, 20, 20, 1600);

	imageMinRect = GetImageMinRect(imgMinRect, 20, 20, 1600);

	return ret;
}

Mat OpenCvDll::GetimageOriginalHist(Mat img)
{
	int bins = 256;
	int hist_size[] = {bins};
	float range[] = {0, 256};
	const float *ranges[] = {range};
	MatND redHist, grayHist, blueHist;

	int channels_r[] = {0};
	calcHist(&img, 1, channels_r, Mat(), redHist, 1, hist_size, ranges, true, false);

	int channels_g[] = {1};
	calcHist(&img, 1, channels_g, Mat(), grayHist, 1, hist_size, ranges, true, false);

	int channels_b[] = {2};
	calcHist(&img, 1, channels_b, Mat(), blueHist, 1, hist_size, ranges, true, false);

	double maxValue_red, maxValue_gray, maxValue_blue;
	minMaxLoc(redHist, 0, &maxValue_red, 0, 0);
	minMaxLoc(grayHist, 0, &maxValue_gray, 0, 0);
	minMaxLoc(blueHist, 0, &maxValue_blue, 0, 0);

	int scale = 1;
	int histHeight = 256;
	Mat histImage = Mat::zeros(histHeight, bins*3, CV_8UC3);

	for (int i = 0; i < bins; i++)
	{
		float binValue_red = redHist.at<float>(i);
		float binValue_gray = grayHist.at<float>(i);
		float binValue_blue = blueHist.at<float>(i);

		int intensity_red = cvRound(binValue_red*histHeight/maxValue_red);
		int intensity_gray = cvRound(binValue_gray*histHeight/maxValue_gray);
		int intensity_blue = cvRound(binValue_blue*histHeight/maxValue_blue);

		rectangle(histImage, Point(i*scale, histHeight-1), Point((i+1)*scale-1, histHeight-intensity_red), Scalar(255, 0, 0));
		rectangle(histImage, Point((i+bins)*scale, histHeight-1), Point((i+bins+1)*scale-1, histHeight-intensity_gray), Scalar(0, 255, 0));
		rectangle(histImage, Point((i+bins*2)*scale, histHeight-1), Point((i+bins*2+1)*scale-1, histHeight-intensity_blue), Scalar(0, 0, 255));
	}

	return histImage;
}

Mat OpenCvDll::GetImageHist(Mat img)
{
	MatND dstHist;
	int dims = 1;
	float hranges[] = {0, 255};
	const float *ranges[] = {hranges};
	int size = 256;
	int channels = 0;

	calcHist(&img, 1, &channels, Mat(), dstHist, dims, &size, ranges);

	int scale = 1;
	Mat imgHist(size*scale, size, CV_8U, Scalar(0));

	double minValue = 0;
	double maxValue = 0;
	Point maxValueLoc;
	Point minValueLoc;
	int maxValueX = 0;
	minMaxLoc(dstHist, &minValue, &maxValue, &minValueLoc, &maxValueLoc);
	maxValueX = maxValueLoc.x;

	int hpt = saturate_cast<int>(0.9*size);
	for (int i = 0; i < 256; i++)
	{
		float binValue = dstHist.at<float>(i);
		int realValue = saturate_cast<int>(binValue*hpt/maxValue);
		rectangle(imgHist, Point(i*scale, size-1), Point((i+1)*scale-1, size-realValue), Scalar(255));
	}

	int max = 0;
	if (maxValueX == 0)
	{
		for (int i = 1; i < 256; i++)
		{
			if (dstHist.at<float>(i) > max)
			{
				maxValueX = i;
				max = dstHist.at<float>(i);
			}
		}
	}

	//if (maxValueX > 255-30)
	//{
	//	for (int i = maxValueX; i < maxValueX - 30; i--)
	//	{
	//		float minLeft = min(dstHist.at<float>(i - 2), dstHist.at<float>(i - 1));
	//		float minRight = min(dstHist.at<float>(i + 2), dstHist.at<float>(i + 1));
	//		if (dstHist.at<float>(i) < minLeft &&
	//			dstHist.at<float>(i) < minRight)
	//		{
	//			thresholdData = i;
	//		}
	//	}
	//}
	//else
	//{
		float minValueX = dstHist.at<float>(maxValueX);
		for (int i = maxValueX ; i < maxValueX + 40; i++)
		{
			//float minLeft = min(dstHist.at<float>(i - 2), dstHist.at<float>(i - 1));
			//float minRight = min(dstHist.at<float>(i + 2), dstHist.at<float>(i + 1));
			//if (dstHist.at<float>(i) < minLeft &&
			//	dstHist.at<float>(i) < minRight)
			//{
			//	thresholdData = i;
			//}
			if (dstHist.at<float>(i) < minValueX)
			{
				minValueX = dstHist.at<float>(i);
				thresholdData = i;
			}

		}
	//}

	if (thresholdData<1 || thresholdData>255)
	{
		thresholdData = 0;
	}


	return imgHist;
}

Mat OpenCvDll::GetImageDenoising(Mat imgBinary)
{
	Mat imgDenoising;
	Mat imgDilate;
	Mat imgErode;
	Mat element;
	int structElementSize = 5;

	element = getStructuringElement(MORPH_ELLIPSE, Size(structElementSize, structElementSize));
	erode(imgBinary, imgErode, element);
	dilate(imgErode, imgDenoising,element);

	return imgDenoising;
}

Mat OpenCvDll::GetImageContours(Mat imgDenoising, int height, int width, int area)
{
	Mat imgContours;
	vector<vector<Point>> contours;

	//imgDenoising.copyTo(imgContours);
	cvtColor(imgDenoising, imgContours, CV_GRAY2BGR);
	findContours(imgDenoising, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);

	for (size_t i = 0; i < contours.size(); i++)
	{
		Rect contourRect = boundingRect(contours[i]);
		if (contourRect.height>height && contourRect.width>width && contourRect.area()>area && contourRect.area()<MINAREA)
		{
			rectangle(imgContours, contourRect, Scalar(0, 0, 255), LINEWIDTH);
		}
	}

	return imgContours;
}

Mat OpenCvDll::GetImageMinRect(Mat imgDenoising, int height, int width, int area)
{
	Mat imgMinRect;
	vector<vector<Point>> contours;
	Point2f rectPoints[4];

	//imgDenoising.copyTo(imgMinRect);
	cvtColor(imgDenoising, imgMinRect, CV_GRAY2BGR);
	findContours(imgDenoising, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);

	for (size_t i = 0; i < contours.size(); i++)
	{
		Rect contourRect = boundingRect(contours[i]);
		if (contourRect.height>height && contourRect.width>width && contourRect.area()>area && contourRect.area()<MINAREA)
		{
			RotatedRect minRect = minAreaRect(contours[i]);
			minRect.points(rectPoints);
			
			line(imgMinRect, rectPoints[0], rectPoints[1], Scalar(0, 0, 255), LINEWIDTH);
			line(imgMinRect, rectPoints[1], rectPoints[2], Scalar(0, 0, 255), LINEWIDTH);
			line(imgMinRect, rectPoints[2], rectPoints[3], Scalar(0, 0, 255), LINEWIDTH);
			line(imgMinRect, rectPoints[3], rectPoints[0], Scalar(0, 0, 255), LINEWIDTH);
		}
	}
	return imgMinRect;
}

IMAGEPARAM* OpenCvDll::ImgOriginal()
{
	IplImage* dst = &IplImage(imageOriginal);
	IplImage* iplImgOriginal = cvCreateImage(cvSize(dst->width, dst->height), 8, 3);
	cvCopy(dst, iplImgOriginal);
	Mat matImgOriginal(iplImgOriginal);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgOriginal->width*iplImgOriginal->height*3+4*3+1];
	try
	{
		paramImage->data = matImgOriginal.data;
		paramImage->width = matImgOriginal.size().width;
		paramImage->height = matImgOriginal.size().height;
		paramImage->step = matImgOriginal.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgOriginalHist()
{
	IplImage* dst = &IplImage(imageOriginalHist);
	IplImage* iplImgOriginalHist = cvCreateImage(cvSize(dst->width, dst->height), 8, 3);
	cvCopy(dst, iplImgOriginalHist);
	Mat matImgOriginalHist(iplImgOriginalHist);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgOriginalHist->width*iplImgOriginalHist->height * 3 + 4 * 3 + 1];
	try
	{
		paramImage->data = matImgOriginalHist.data;
		paramImage->width = matImgOriginalHist.size().width;
		paramImage->height = matImgOriginalHist.size().height;
		paramImage->step = matImgOriginalHist.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgGray()
{
	IplImage* dst = &IplImage(imageGray);
	IplImage* iplImgGray = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgGray);
	Mat matImgGray(iplImgGray);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgGray->width*iplImgGray->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgGray.data;
		paramImage->width = matImgGray.size().width;
		paramImage->height = matImgGray.size().height;
		paramImage->step = matImgGray.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgHist(int selectedHist, int thresholdValue)
{
	Mat imageHist;
	Mat imageHist3;
	int channel;
	IplImage* dst = NULL;

	switch (selectedHist)
	{
		case HIST_GRAY:
			imageHist = imageHistGray;
			channel = 1;
			dst = &IplImage(imageHist);
			break;
		case HIST_FILTER:
			imageHist = imageHistGauss;
			channel = 1;
			dst = &IplImage(imageHist);
			break;
		case HIST_BINARY:
			cvtColor(imageHistGauss, imageHist3, CV_GRAY2BGR);
			line(imageHist3, Point(thresholdValue,0), Point(thresholdValue,255), Scalar(0, 0, 255), 1);
			imageHistBinary = imageHist3;
			channel = 3;
			dst = &IplImage(imageHist3);
			break;
		default:
			break;
	}

	IplImage* iplImgHist = cvCreateImage(cvSize(dst->width, dst->height), 8, channel);
	cvCopy(dst, iplImgHist);
	Mat matImgHist(iplImgHist);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgHist->width*iplImgHist->height*3+4*3+1];
	try
	{		
		paramImage->data = matImgHist.data;
		paramImage->width = matImgHist.size().width;
		paramImage->height = matImgHist.size().height;
		paramImage->step = matImgHist.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgFilter()
{
	IplImage* dst = &IplImage(imageGauss);
	IplImage* iplImgGauss = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgGauss);
	Mat matImgGauss(iplImgGauss);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgGauss->width*iplImgGauss->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgGauss.data;
		paramImage->width = matImgGauss.size().width;
		paramImage->height = matImgGauss.size().height;
		paramImage->step = matImgGauss.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgBinary(int thresholdValue)
{
	threshold(imageGauss, imageBinary, thresholdValue, 255, CV_THRESH_BINARY);

	IplImage* dst = &IplImage(imageBinary);
	IplImage* iplImgBinary = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgBinary);
	Mat matImgBinary(iplImgBinary);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgBinary->width*iplImgBinary->height * 3 + 4 * 3 + 1];
	//static struct IMAGEPARAM* paramImage = (struct IMAGEPARAM*) malloc(iplImgBinary->width*iplImgBinary->height * 3 + 4 * 3 + 1);
	try
	{	
		paramImage->data = matImgBinary.data;
		paramImage->width = matImgBinary.size().width;
		paramImage->height = matImgBinary.size().height;
		paramImage->step = matImgBinary.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

void OpenCvDll::ImgAmplify(int amplifyImage)
{
	switch (amplifyImage)
	{
	case ORIGINAL:
		namedWindow("Original", CV_WINDOW_NORMAL);
		imshow("Original", imageOriginal);
		break;
	case GRAY:
		namedWindow("Gray", CV_WINDOW_NORMAL);
		imshow("Gray", imageGray);
		break;
	case HISTGRAY:
		namedWindow("GrayHist", CV_WINDOW_NORMAL);
		imshow("GrayHist", imageHistGray);
		break;
	case FILTER:
		namedWindow("Filter", CV_WINDOW_NORMAL);
		imshow("Filter", imageGauss);
		break;
	case HISTFILTER:
		namedWindow("FilterHist", CV_WINDOW_NORMAL);
		imshow("FilterHist", imageHistGauss);
		break;
	case HISTBINARY:
		namedWindow("BinaryHist", CV_WINDOW_NORMAL);
		imshow("BinaryHist", imageHistBinary);
		break;
	case BINARY:
		namedWindow("Binary", CV_WINDOW_NORMAL);
		imshow("Binary", imageBinary);
		break;
	case DENOISINGBINARY:
		namedWindow("DenoisingBinary", CV_WINDOW_NORMAL);
		imshow("DenoisingBinary", imageBinary);
		break;
	case DENOISING:
		namedWindow("Denoising", CV_WINDOW_NORMAL);
		imshow("Denoising", imageDenoising);
		break;
	case ORIGINALHIST:
		namedWindow("OriginalHist", CV_WINDOW_NORMAL);
		imshow("OriginalHist", imageOriginalHist);
		break;
	case CONTOURS:
		namedWindow("Contours", CV_WINDOW_NORMAL);
		imshow("Contours", imageContours);
		break;
	case MINRECT:
		namedWindow("MinRectangel", CV_WINDOW_NORMAL);
		imshow("MinRectangel", imageMinRect);
		break;
	case RECTIFICATION1:
		namedWindow("Rectification1", CV_WINDOW_NORMAL);
		imshow("Rectification1", imageRectification1);
		break;
	case RECTIFICATION2:
		namedWindow("Rectification2", CV_WINDOW_NORMAL);
		imshow("Rectification2", imageRectification2);
		break;
	case WHITEBLACKBALANCE:
		namedWindow("WhiteBlackBalance", CV_WINDOW_NORMAL);
		imshow("WhiteBlackBalance", imageOrigWhiteBlackBalance);
		break;
	default:
		break;
	}
}

IMAGEPARAM* OpenCvDll::ImgDenoising(int opera, int sharp, int size)
{
	Mat imgOperation;
	Mat imgDilate;
	Mat imgErode;
	Mat element;
	int elementSize;

	elementSize = size;
	switch (sharp)
	{
		case RECTANGELE:
			element = getStructuringElement(MORPH_RECT, Size(elementSize, elementSize));
			break;
		case CROSS:
			element = getStructuringElement(MORPH_CROSS, Size(elementSize, elementSize));
			break;
		case ELLIPSE:
			element = getStructuringElement(MORPH_ELLIPSE, Size(elementSize, elementSize));
			break;
		default:
			break;
	}

	switch (opera)
	{
		case DILATE:
			dilate(imageBinary, imgOperation, element);
			break;
		case ERODE:
			erode(imageBinary, imgOperation, element);
			break;
		case OPEN:
			erode(imageBinary, imgErode, element);
			dilate(imgErode, imgOperation, element);
			break;
		case CLOSE:
			dilate(imageBinary, imgDilate, element);
			erode(imgDilate, imgOperation, element);
			break;
		default:
			break;
	}

	imageDenoising = imgOperation;

	IplImage* dst = &IplImage(imageDenoising);
	IplImage* iplImgDenoising = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgDenoising);
	Mat matImgDenoising(iplImgDenoising);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgDenoising->width*iplImgDenoising->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgDenoising.data;
		paramImage->width = matImgDenoising.size().width;
		paramImage->height = matImgDenoising.size().height;
		paramImage->step = matImgDenoising.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgContours(int height, int width, int area)
{
	Mat imgContours;
	imageDenoising.copyTo(imgContours);
	imageContours = GetImageContours(imgContours, height, width, area);
	IplImage* dst = &IplImage(imageContours);
	IplImage* iplImgContours = cvCreateImage(cvSize(dst->width, dst->height), 8, 3);
	cvCopy(dst, iplImgContours);
	Mat matImgContours(iplImgContours);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgContours->width*iplImgContours->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgContours.data;
		paramImage->width = matImgContours.size().width;
		paramImage->height = matImgContours.size().height;
		paramImage->step = matImgContours.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgMinRect(int height, int width, int area)
{
	Mat imgMinRect;
	imageDenoising.copyTo(imgMinRect);
	imageMinRect = GetImageMinRect(imgMinRect, height, width, area);
	IplImage* dst = &IplImage(imageMinRect);
	IplImage* iplImgMinRect = cvCreateImage(cvSize(dst->width, dst->height), 8, 3);
	cvCopy(dst, iplImgMinRect);
	Mat matImgMinRect(iplImgMinRect);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgMinRect->width*iplImgMinRect->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgMinRect.data;
		paramImage->width = matImgMinRect.size().width;
		paramImage->height = matImgMinRect.size().height;
		paramImage->step = matImgMinRect.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

int OpenCvDll::ReadDataNum(char* fileName)
{
	int num = 0;
	FILE *fpr = NULL;
	int dataSize = sizeof(TypeStartNamaGD_A);
	TypeStartNamaGD_A* datStruct = (TypeStartNamaGD_A*)malloc(sizeof(TypeStartNamaGD_A));

	fpr = fopen(fileName, "rb");
	fseek(fpr, OFFSET, SEEK_SET);
	
	while (fread(datStruct, dataSize, 1, fpr) >= 1)
	{
		//fseek(fpr, OFFSET, SEEK_CUR);
		num++;
	}

	return num;
}

Mat OpenCvDll::DataRead(char* fileName, int selectedNo)
{
	FILE *fpr = NULL;
	int dataSize = sizeof(TypeStartNamaGD_A);
	TypeStartNamaGD_A* datStruct = (TypeStartNamaGD_A*)malloc(sizeof(TypeStartNamaGD_A));
	long offSet = OFFSET + dataSize * (selectedNo - 1);

	fpr = fopen(fileName,"rb");
	fseek(fpr, offSet, SEEK_SET);
	fread(datStruct, dataSize, 1, fpr);
	fclose(fpr);

	char*	tempData;
	tempData = new char[DefLineLnNama2*DefLineChNama2];
	for (int i = 0; i < DefLineLnNama2; i++)
	{
		memcpy(&tempData[i*DefLineChNama2], &datStruct->LineDataNamaRG_B[i*DefLineChNama2], DefLineChNama2);
	}

	//FILE *fpr = NULL;
	//MyStruct datStruct;
	//fpr = fopen(fileName,"rb");
	//fseek(fpr, 2162944, SEEK_SET);
	//fread(&datStruct, 884736, 1, fpr);
	//char*	tempData;
	//tempData = new char[DefLineLnNama2*DefLineChNama2];
	//for (int i = 0; i < DefLineLnNama2; i++)
	//{
	//	memcpy(&tempData[i*DefLineChNama2], &datStruct.LineDataNamaRG_A[i*DefLineChNama2], DefLineChNama2);
	//}

	IplImage* img = cvCreateImage(cvSize(DefLineChNama2, DefLineLnNama2), 8, 1);
	img->imageData = tempData;
	Mat readImage(img);

	free(datStruct);
	datStruct = NULL;
	return readImage;
}

Mat OpenCvDll::WhiteBlackBalance(Mat imgOriginal)
{
	CvMLData mlDataWhite, mlDataBlack;
	mlDataWhite.read_csv("white4.csv");
	mlDataBlack.read_csv("black4.csv");

	Mat csvWhite = Mat(mlDataWhite.get_values(), true);
	Mat csvBlack = Mat(mlDataBlack.get_values(), true);
	csvWhite.convertTo(csvWhite, CV_8U);
	csvBlack.convertTo(csvBlack, CV_8U);
	Mat matWhite, matBlack;
	repeat(csvWhite, 576, 1, matWhite);
	repeat(csvBlack, 576, 1, matBlack);

	Mat para1 = matWhite - matBlack;
	Mat para2;
	divide(200, para1, para2);
	Mat para3 = imgOriginal-matBlack;
	Mat imgBalance = para2.mul(para3);

	Mat imgBalanceResize = Mat(imgBalance.rows*0.5, imgBalance.cols*0.25, CV_8U);
	resize(imgBalance, imgBalanceResize, imgBalanceResize.size());

	return imgBalanceResize;
}

int OpenCvDll::GetReadDataNum()
{
	return dataNum;
}

Mat OpenCvDll::GetRectification1(Mat imgGray)
{
	Mat imgGrayTmp;
	imgGray.copyTo(imgGrayTmp);
	Mat imgBin;
	threshold(imgGray, imgBin, 50, 200, CV_THRESH_OTSU);

	vector<vector<Point>> contours;
	vector<Rect> boundRect(contours.size());
	findContours(imgBin, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);
	for (int i = 0; i < contours.size(); i++)
	{
		CvPoint2D32f rectPoint[4];
		CvBox2D rect = minAreaRect(Mat(contours[i]));
		cvBoxPoints(rect, rectPoint);

		float angle = rect.angle;

		int line1 = sqrt((rectPoint[1].y - rectPoint[0].y)*(rectPoint[1].y - rectPoint[0].y) + (rectPoint[1].x - rectPoint[0].x)*(rectPoint[1].x - rectPoint[0].x));
		int line2 = sqrt((rectPoint[3].y - rectPoint[0].y)*(rectPoint[3].y - rectPoint[0].y) + (rectPoint[3].x - rectPoint[0].x)*(rectPoint[3].x - rectPoint[0].x));	
		if (line1*line2 < 12000)
		{
			continue;
		}
		if (line1 > line2)
		{
			angle = angle + 90;
		}

		Mat RoiSrcImg(imgGrayTmp.rows, imgGrayTmp.cols, CV_8UC1);
		RoiSrcImg.setTo(0);
		
		drawContours(imgBin, contours, -1, Scalar(255), CV_FILLED);

		imgGrayTmp.copyTo(RoiSrcImg, imgBin);
		//imshow("RoiSrcImg", RoiSrcImg); //a

		Mat RatationedImg(RoiSrcImg.rows, RoiSrcImg.cols, CV_8UC1);
		RatationedImg.setTo(0);

		Point2f center = rect.center;
		Mat M2 = getRotationMatrix2D(center, angle, 1);
		warpAffine(RoiSrcImg, RatationedImg, M2, RoiSrcImg.size(), 1, 0, Scalar(0));
		//imshow("rata", RatationedImg); //b
		return RatationedImg;

	}
}

Mat OpenCvDll::GetRectification2(Mat imgRectification1)
{
	vector<vector<Point>> contours;
	Mat imgBin, imgRaw;
	imgRaw = imgRectification1;

	threshold(imgRaw, imgBin, 80, 200, CV_THRESH_BINARY);
	findContours(imgBin, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);

	for (int i = 0; i < contours.size(); i++)
	{
		Rect rect = boundingRect(Mat(contours[i]));
		if (rect.area()<12000)
		{
			continue;
		}
		Mat imgDst = imgRectification1(rect);

		return imgDst;
	}
}

IMAGEPARAM* OpenCvDll::ImgRectification1()
{
	IplImage* dst = &IplImage(imageRectification1);
	IplImage* iplImgRectification = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgRectification);
	Mat matImgRectification(iplImgRectification);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgRectification->width*iplImgRectification->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgRectification.data;
		paramImage->width = matImgRectification.size().width;
		paramImage->height = matImgRectification.size().height;
		paramImage->step = matImgRectification.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgRectification2()
{
	IplImage* dst = &IplImage(imageRectification2);
	IplImage* iplImgRectification = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgRectification);
	Mat matImgRectification(iplImgRectification);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgRectification->width*iplImgRectification->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgRectification.data;
		paramImage->width = matImgRectification.size().width;
		paramImage->height = matImgRectification.size().height;
		paramImage->step = matImgRectification.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}

IMAGEPARAM* OpenCvDll::ImgWhiteBlackBalance()
{
	IplImage* dst = &IplImage(imageOrigWhiteBlackBalance);
	IplImage* iplImgBalance = cvCreateImage(cvSize(dst->width, dst->height), 8, 1);
	cvCopy(dst, iplImgBalance);
	Mat matImgBalance(iplImgBalance);

	static struct IMAGEPARAM* paramImage = new struct IMAGEPARAM[iplImgBalance->width*iplImgBalance->height * 3 + 4 * 3 + 1];
	try
	{		
		paramImage->data = matImgBalance.data;
		paramImage->width = matImgBalance.size().width;
		paramImage->height = matImgBalance.size().height;
		paramImage->step = matImgBalance.step;
		paramImage->result = true;
	}
	catch(...)
	{
		paramImage->result = false;
	}

	return paramImage;
}
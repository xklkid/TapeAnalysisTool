#include <string>

#define SUCCESS 0
#define FAILURE 1
#define LINEWIDTH 0.5				//Base:1
#define MINAREA 2500			//Base:40000
#define RESIZEPARA 0.5		//Base:1

struct IMAGEPARAM
{
	int width;
	int height;
	int step;
	uchar* data;
	bool result;
};

enum SELECTEHIST
{
	HIST_GRAY = 0,
    HIST_FILTER = 1,
    HIST_BINARY = 2,
};

enum AMPLIFYIMAGE
{
    ORIGINAL = 0,
    GRAY = 1,
    HISTGRAY = 2,
    HISTFILTER = 3,
    HISTBINARY = 4,
    FILTER = 5,
	BINARY = 6,
	DENOISINGBINARY = 7,
	DENOISING = 8,
	ORIGINALHIST = 9,
	CONTOURS = 10,
    MINRECT = 11,
	RECTIFICATION1 = 12,
	RECTIFICATION2 = 13,
	WHITEBLACKBALANCE = 14,
};

enum OPERATION
{
	DILATE = 0,
	ERODE = 1,
	OPEN = 2,
	CLOSE = 3,
};

enum SHARP
{
	RECTANGELE = 0,
	CROSS = 1,
	ELLIPSE = 2,
};


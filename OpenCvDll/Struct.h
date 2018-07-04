typedef unsigned char Byte;
typedef unsigned short Word;
#define DefAtsuCh 12
#define	DefAtsuLn 144
#define	DefGsmRumpCh 6			
#define	DefGsmRumpLn 256
#define	DefSuperSonicLn	128
#define	DefMgCh 16			
#define	DefMgLn 576			
#define	DefMginkLn 128		
#define	DefFLCh	4			
#define	DefFLLn	128	
#define	DefLineLnNama 192	
#define	DefLineCh (1536/12)	
#define	DefLineLn (192/2)		
#define	DefLineCh4 (1536/4)
#define	DefLineCh6 (1536/6)
#define	DefLineChRaku 128			
#define	DefLineLnRaku 48			
#define	DefLineChNama2 1536
#define	DefLineLnNama2 576

#define OFFSET 655488

#pragma pack(1)
typedef		struct
{
	char		RID[64];
	char		comment[64];											// コメント	(Ascii)

	Word		BiInf[1024];											// ＢＩ情報 その他

	Word		LineBlockNorm[20][32*16];								// ラインセンサブロッキング/正規化

	union{
        struct{
			Byte		AtsuHosei     [DefAtsuCh*256];					// 厚検センサ補正後データ
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVD
			Word		AtsuUnyohosei [16];								// 厚検センサ運用補正係数  (DefAtsuCh + 予備ch)
			Word		AtsuUnyoOffset[16];								// 厚検センサ運用オフセット(DefAtsuCh + 予備ch)
			Byte		yobi1[64];										// 予備

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/リンプネスセンサデータ
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// 超音波センサデータ
			union{
        		struct{
        		    Word		FlData     [DefFLCh*DefFLLn     ];		// 蛍光センサデータ
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// 磁気インクパターン
		            Word		MgData     [DefMgCh*DefMgLn];	 		// 磁気センサ生データ
		            Byte		yobi2[6656];					 		// 予備
		        }flu15;
		        struct{
		        	Word		FlData     [DefFLCh*DefFLLn   *2];		// 蛍光センサデータ
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// 磁気インクパターン
		            Word		MgData     [DefMgCh*DefMgLn];	 		// 磁気センサ生データ
        		    Byte		yobi2[5632];					 		// 予備
		        }flu10;
			};
		}USF50X;
        struct{
			Byte		AtsuHosei     [DefAtsuCh*576];					// 厚検センサ補正後データ
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// 厚検センサ生データVD
			Word		AtsuUnyohosei [16];								// 厚検センサ運用補正係数  (DefAtsuCh + 予備ch)
			Word		AtsuUnyoOffset[16];								// 厚検センサ運用オフセット(DefAtsuCh + 予備ch)
			Byte		yobi1[192];										// 予備

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/リンプネスセンサデータ
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// 超音波センサデータ
	       	Word		FlData     [DefFLCh*DefFLLn   *2];				// 蛍光センサデータ
	        Byte		MgInkPat   [DefMgCh*DefMginkLn  ];				// 磁気インクパターン
	        Word		MgData     [DefMgCh*DefMgLn];	 				// 磁気センサ生データ
    	    Byte		yobi2[1664];					 				// 予備
		}HVDX;
	};

	Byte		LineDataBool         [32        *DefLineLnNama];		// ラインセンサ２値化データ(0.76×0.76)   ６×１画素平均 bitデータ
	Byte		LineDataTIR_50_75    [DefLineCh4*DefLineLnNama];		// ラインセンサ透過赤外    (0.58×0.76)   ４×１画素平均
	Byte		LineDataTIR_150_150  [DefLineCh *DefLineLn    ];		// ラインセンサ透過赤外    (1.52×1.52) １２×２画素平均
	Byte		LineDataTG_150_150   [DefLineCh *DefLineLn    ];		// ラインセンサ透過緑	   (1.52×1.52) １２×２画素平均
	Byte		LineDataRIR_A_150_150[DefLineCh *DefLineLn    ];		// ラインセンサ反射Ａ赤外  (1.52×1.52) １２×２画素平均
	Byte		LineDataRG_A_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ａ緑    (1.52×1.52) １２×２画素平均
	Byte		LineDataRakugaki_A   [2][DefLineChRaku* DefLineLnRaku];	// ラインセンサ反射Ａ      (1.52×3.05) 落書き判定用
	Byte		LineDataTIR_75_75	 [DefLineCh6*DefLineLnNama];		// ラインセンサ透過赤外    (0.76×0.76)   ６×１画素平均
	Byte		LineDataRIR_A_75_75  [DefLineCh6*DefLineLnNama];		// ラインセンサ反射Ａ赤外  (0.75×0.75)   ６×１画素平均
	Byte		LineDataRG_A_75_75   [DefLineCh6*DefLineLnNama];		// ラインセンサ反射Ａ緑    (0.76×0.76)   ６×１画素平均
	Byte		LineDataRR_A_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ａ赤    (1.52×1.52) １２×２画素平均
	Byte		yobi3[36864];											// 予備
	Byte		LineDataRB_A_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ａ青    (1.52×1.52) １２×２画素平均
	Byte		yobi4[36864];											// 予備

	Byte		LineDataRIR_B_150_150[DefLineCh *DefLineLn    ];		// ラインセンサ反射Ｂ赤外  (1.52×1.52) １２×２画素平均
	Byte		LineDataRG_B_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ｂ緑    (1.52×1.52) １２×２画素平均
	Byte		LineDataRakugaki_B   [2][DefLineChRaku* DefLineLnRaku];	// ラインセンサ反射Ｂ      (1.52×3.05) 落書き判定用
	Byte		LineDataRIR_B_75_75  [DefLineCh6*DefLineLnNama];		// ラインセンサ反射Ｂ赤外  (0.75×0.75)   ６×１画素平均
	Byte		LineDataRG_B_75_75   [DefLineCh6*DefLineLnNama];		// ラインセンサ反射Ｂ緑    (0.76×0.76)   ６×１画素平均
	Byte		LineDataRR_B_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ｂ赤    (1.52×0.58) １２×２画素平均
	Byte		yobi5[36864];											// 予備
	Byte		LineDataRB_B_150_150 [DefLineCh *DefLineLn    ];		// ラインセンサ反射Ｂ青    (1.52×0.58) １２×２画素平均
	Byte		yobi6[36864];											// 予備

	Byte		LineDataNamaTIR      [DefLineChNama2*DefLineLnNama ];	// ラインセンサ生透過赤外  (0.127×0.76 )
	Byte		LineDataNamaTG	     [DefLineChNama2*DefLineLn     ];	// ラインセンサ生透過緑    (0.127×1.52 )
	Byte		yobi7[81920];											// 予備
	Byte		LineDataNamaRIR_A    [DefLineChNama2*DefLineLnNama ];	// ラインセンサ生反射Ａ赤外(0.127×0.76 )
	Byte		LineDataNamaRG_A     [DefLineChNama2*DefLineLnNama2];	// ラインセンサ生反射Ａ緑  (0.127×0.254)
	Byte		LineDataNamaRIR_B    [DefLineChNama2*DefLineLnNama ];	// ラインセンサ生反射Ｂ赤外(0.127×0.76 )
	Byte		LineDataNamaRG_B     [DefLineChNama2*DefLineLnNama2];	// ラインセンサ生反射Ｂ緑  (0.127×0.254)
} TypeStartNamaGD_A;	//128Byte+672KByte+2.75MByte
#pragma pack()

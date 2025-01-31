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
	char		comment[64];											// Rg	(Ascii)

	Word		BiInf[1024];											// ahξρ »ΜΌ

	Word		LineBlockNorm[20][32*16];								// CZTubLO/³K»

	union{
        struct{
			Byte		AtsuHosei     [DefAtsuCh*256];					// ϊZTβ³γf[^
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VD
			Word		AtsuUnyohosei [16];								// ϊZT^pβ³W  (DefAtsuCh + \υch)
			Word		AtsuUnyoOffset[16];								// ϊZT^pItZbg(DefAtsuCh + \υch)
			Byte		yobi1[64];										// \υ

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/vlXZTf[^
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// ΄ΉgZTf[^
			union{
        		struct{
        		    Word		FlData     [DefFLCh*DefFLLn     ];		// uυZTf[^
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// ₯CCNp^[
		            Word		MgData     [DefMgCh*DefMgLn];	 		// ₯CZTΆf[^
		            Byte		yobi2[6656];					 		// \υ
		        }flu15;
		        struct{
		        	Word		FlData     [DefFLCh*DefFLLn   *2];		// uυZTf[^
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// ₯CCNp^[
		            Word		MgData     [DefMgCh*DefMgLn];	 		// ₯CZTΆf[^
        		    Byte		yobi2[5632];					 		// \υ
		        }flu10;
			};
		}USF50X;
        struct{
			Byte		AtsuHosei     [DefAtsuCh*576];					// ϊZTβ³γf[^
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// ϊZTΆf[^VD
			Word		AtsuUnyohosei [16];								// ϊZT^pβ³W  (DefAtsuCh + \υch)
			Word		AtsuUnyoOffset[16];								// ϊZT^pItZbg(DefAtsuCh + \υch)
			Byte		yobi1[192];										// \υ

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/vlXZTf[^
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// ΄ΉgZTf[^
	       	Word		FlData     [DefFLCh*DefFLLn   *2];				// uυZTf[^
	        Byte		MgInkPat   [DefMgCh*DefMginkLn  ];				// ₯CCNp^[
	        Word		MgData     [DefMgCh*DefMgLn];	 				// ₯CZTΆf[^
    	    Byte		yobi2[1664];					 				// \υ
		}HVDX;
	};

	Byte		LineDataBool         [32        *DefLineLnNama];		// CZTQl»f[^(0.76~0.76)   U~Pζf½Ο bitf[^
	Byte		LineDataTIR_50_75    [DefLineCh4*DefLineLnNama];		// CZT§ίΤO    (0.58~0.76)   S~Pζf½Ο
	Byte		LineDataTIR_150_150  [DefLineCh *DefLineLn    ];		// CZT§ίΤO    (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataTG_150_150   [DefLineCh *DefLineLn    ];		// CZT§ίΞ	   (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataRIR_A_150_150[DefLineCh *DefLineLn    ];		// CZT½Λ`ΤO  (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataRG_A_150_150 [DefLineCh *DefLineLn    ];		// CZT½Λ`Ξ    (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataRakugaki_A   [2][DefLineChRaku* DefLineLnRaku];	// CZT½Λ`      (1.52~3.05) «»θp
	Byte		LineDataTIR_75_75	 [DefLineCh6*DefLineLnNama];		// CZT§ίΤO    (0.76~0.76)   U~Pζf½Ο
	Byte		LineDataRIR_A_75_75  [DefLineCh6*DefLineLnNama];		// CZT½Λ`ΤO  (0.75~0.75)   U~Pζf½Ο
	Byte		LineDataRG_A_75_75   [DefLineCh6*DefLineLnNama];		// CZT½Λ`Ξ    (0.76~0.76)   U~Pζf½Ο
	Byte		LineDataRR_A_150_150 [DefLineCh *DefLineLn    ];		// CZT½Λ`Τ    (1.52~1.52) PQ~Qζf½Ο
	Byte		yobi3[36864];											// \υ
	Byte		LineDataRB_A_150_150 [DefLineCh *DefLineLn    ];		// CZT½Λ`Β    (1.52~1.52) PQ~Qζf½Ο
	Byte		yobi4[36864];											// \υ

	Byte		LineDataRIR_B_150_150[DefLineCh *DefLineLn    ];		// CZT½ΛaΤO  (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataRG_B_150_150 [DefLineCh *DefLineLn    ];		// CZT½ΛaΞ    (1.52~1.52) PQ~Qζf½Ο
	Byte		LineDataRakugaki_B   [2][DefLineChRaku* DefLineLnRaku];	// CZT½Λa      (1.52~3.05) «»θp
	Byte		LineDataRIR_B_75_75  [DefLineCh6*DefLineLnNama];		// CZT½ΛaΤO  (0.75~0.75)   U~Pζf½Ο
	Byte		LineDataRG_B_75_75   [DefLineCh6*DefLineLnNama];		// CZT½ΛaΞ    (0.76~0.76)   U~Pζf½Ο
	Byte		LineDataRR_B_150_150 [DefLineCh *DefLineLn    ];		// CZT½ΛaΤ    (1.52~0.58) PQ~Qζf½Ο
	Byte		yobi5[36864];											// \υ
	Byte		LineDataRB_B_150_150 [DefLineCh *DefLineLn    ];		// CZT½ΛaΒ    (1.52~0.58) PQ~Qζf½Ο
	Byte		yobi6[36864];											// \υ

	Byte		LineDataNamaTIR      [DefLineChNama2*DefLineLnNama ];	// CZTΆ§ίΤO  (0.127~0.76 )
	Byte		LineDataNamaTG	     [DefLineChNama2*DefLineLn     ];	// CZTΆ§ίΞ    (0.127~1.52 )
	Byte		yobi7[81920];											// \υ
	Byte		LineDataNamaRIR_A    [DefLineChNama2*DefLineLnNama ];	// CZTΆ½Λ`ΤO(0.127~0.76 )
	Byte		LineDataNamaRG_A     [DefLineChNama2*DefLineLnNama2];	// CZTΆ½Λ`Ξ  (0.127~0.254)
	Byte		LineDataNamaRIR_B    [DefLineChNama2*DefLineLnNama ];	// CZTΆ½ΛaΤO(0.127~0.76 )
	Byte		LineDataNamaRG_B     [DefLineChNama2*DefLineLnNama2];	// CZTΆ½ΛaΞ  (0.127~0.254)
} TypeStartNamaGD_A;	//128Byte+672KByte+2.75MByte
#pragma pack()

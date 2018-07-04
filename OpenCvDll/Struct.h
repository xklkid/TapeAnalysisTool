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
	char		comment[64];											// �R�����g	(Ascii)

	Word		BiInf[1024];											// �a�h��� ���̑�

	Word		LineBlockNorm[20][32*16];								// ���C���Z���T�u���b�L���O/���K��

	union{
        struct{
			Byte		AtsuHosei     [DefAtsuCh*256];					// �����Z���T�␳��f�[�^
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VD
			Word		AtsuUnyohosei [16];								// �����Z���T�^�p�␳�W��  (DefAtsuCh + �\��ch)
			Word		AtsuUnyoOffset[16];								// �����Z���T�^�p�I�t�Z�b�g(DefAtsuCh + �\��ch)
			Byte		yobi1[64];										// �\��

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/�����v�l�X�Z���T�f�[�^
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// �����g�Z���T�f�[�^
			union{
        		struct{
        		    Word		FlData     [DefFLCh*DefFLLn     ];		// �u���Z���T�f�[�^
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// ���C�C���N�p�^�[��
		            Word		MgData     [DefMgCh*DefMgLn];	 		// ���C�Z���T���f�[�^
		            Byte		yobi2[6656];					 		// �\��
		        }flu15;
		        struct{
		        	Word		FlData     [DefFLCh*DefFLLn   *2];		// �u���Z���T�f�[�^
		            Byte		MgInkPat   [DefMgCh*DefMginkLn  ];		// ���C�C���N�p�^�[��
		            Word		MgData     [DefMgCh*DefMgLn];	 		// ���C�Z���T���f�[�^
        		    Byte		yobi2[5632];					 		// �\��
		        }flu10;
			};
		}USF50X;
        struct{
			Byte		AtsuHosei     [DefAtsuCh*576];					// �����Z���T�␳��f�[�^
			Word		AtsuDataVH    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VH
			Word		AtsuDataVL    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VL
			Word		AtsuDataVD    [DefAtsuCh*DefAtsuLn];			// �����Z���T���f�[�^VD
			Word		AtsuUnyohosei [16];								// �����Z���T�^�p�␳�W��  (DefAtsuCh + �\��ch)
			Word		AtsuUnyoOffset[16];								// �����Z���T�^�p�I�t�Z�b�g(DefAtsuCh + �\��ch)
			Byte		yobi1[192];										// �\��

			Byte		GsmRumpData[2*DefGsmRumpCh*DefGsmRumpLn];		// GSM/�����v�l�X�Z���T�f�[�^
			Byte		SuperSonic [2*DefSuperSonicLn          ];		// �����g�Z���T�f�[�^
	       	Word		FlData     [DefFLCh*DefFLLn   *2];				// �u���Z���T�f�[�^
	        Byte		MgInkPat   [DefMgCh*DefMginkLn  ];				// ���C�C���N�p�^�[��
	        Word		MgData     [DefMgCh*DefMgLn];	 				// ���C�Z���T���f�[�^
    	    Byte		yobi2[1664];					 				// �\��
		}HVDX;
	};

	Byte		LineDataBool         [32        *DefLineLnNama];		// ���C���Z���T�Q�l���f�[�^(0.76�~0.76)   �U�~�P��f���� bit�f�[�^
	Byte		LineDataTIR_50_75    [DefLineCh4*DefLineLnNama];		// ���C���Z���T���ߐԊO    (0.58�~0.76)   �S�~�P��f����
	Byte		LineDataTIR_150_150  [DefLineCh *DefLineLn    ];		// ���C���Z���T���ߐԊO    (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataTG_150_150   [DefLineCh *DefLineLn    ];		// ���C���Z���T���ߗ�	   (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataRIR_A_150_150[DefLineCh *DefLineLn    ];		// ���C���Z���T���˂`�ԊO  (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataRG_A_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂`��    (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataRakugaki_A   [2][DefLineChRaku* DefLineLnRaku];	// ���C���Z���T���˂`      (1.52�~3.05) ����������p
	Byte		LineDataTIR_75_75	 [DefLineCh6*DefLineLnNama];		// ���C���Z���T���ߐԊO    (0.76�~0.76)   �U�~�P��f����
	Byte		LineDataRIR_A_75_75  [DefLineCh6*DefLineLnNama];		// ���C���Z���T���˂`�ԊO  (0.75�~0.75)   �U�~�P��f����
	Byte		LineDataRG_A_75_75   [DefLineCh6*DefLineLnNama];		// ���C���Z���T���˂`��    (0.76�~0.76)   �U�~�P��f����
	Byte		LineDataRR_A_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂`��    (1.52�~1.52) �P�Q�~�Q��f����
	Byte		yobi3[36864];											// �\��
	Byte		LineDataRB_A_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂`��    (1.52�~1.52) �P�Q�~�Q��f����
	Byte		yobi4[36864];											// �\��

	Byte		LineDataRIR_B_150_150[DefLineCh *DefLineLn    ];		// ���C���Z���T���˂a�ԊO  (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataRG_B_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂a��    (1.52�~1.52) �P�Q�~�Q��f����
	Byte		LineDataRakugaki_B   [2][DefLineChRaku* DefLineLnRaku];	// ���C���Z���T���˂a      (1.52�~3.05) ����������p
	Byte		LineDataRIR_B_75_75  [DefLineCh6*DefLineLnNama];		// ���C���Z���T���˂a�ԊO  (0.75�~0.75)   �U�~�P��f����
	Byte		LineDataRG_B_75_75   [DefLineCh6*DefLineLnNama];		// ���C���Z���T���˂a��    (0.76�~0.76)   �U�~�P��f����
	Byte		LineDataRR_B_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂a��    (1.52�~0.58) �P�Q�~�Q��f����
	Byte		yobi5[36864];											// �\��
	Byte		LineDataRB_B_150_150 [DefLineCh *DefLineLn    ];		// ���C���Z���T���˂a��    (1.52�~0.58) �P�Q�~�Q��f����
	Byte		yobi6[36864];											// �\��

	Byte		LineDataNamaTIR      [DefLineChNama2*DefLineLnNama ];	// ���C���Z���T�����ߐԊO  (0.127�~0.76 )
	Byte		LineDataNamaTG	     [DefLineChNama2*DefLineLn     ];	// ���C���Z���T�����ߗ�    (0.127�~1.52 )
	Byte		yobi7[81920];											// �\��
	Byte		LineDataNamaRIR_A    [DefLineChNama2*DefLineLnNama ];	// ���C���Z���T�����˂`�ԊO(0.127�~0.76 )
	Byte		LineDataNamaRG_A     [DefLineChNama2*DefLineLnNama2];	// ���C���Z���T�����˂`��  (0.127�~0.254)
	Byte		LineDataNamaRIR_B    [DefLineChNama2*DefLineLnNama ];	// ���C���Z���T�����˂a�ԊO(0.127�~0.76 )
	Byte		LineDataNamaRG_B     [DefLineChNama2*DefLineLnNama2];	// ���C���Z���T�����˂a��  (0.127�~0.254)
} TypeStartNamaGD_A;	//128Byte+672KByte+2.75MByte
#pragma pack()

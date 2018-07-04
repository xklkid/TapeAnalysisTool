using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace TapeAnalysisTool
{
    public partial class AnalysisForm : Form
    {
        const int SUCCESS = 0;
        const int FAILURE = 1;
        const int THRESHEIGHT = 10;     //Base:20
        const int THRESWIDTH = 10;      //Base:20
        const int THRESAREA = 400;      //Base:1600
        LoadingForm loadForm = null;
        string fileDataName;
        int thresValue;
        bool isMatch = false;
        int selectedNo = 1;

        private enum SelectedHist
        {
            HIST_GRAY = 0,
            HIST_FILTER = 1,
            HIST_BINARY = 2,
        };

        private enum AmplifyImage
        {
            ORIGINAL = 0,
            GRAY = 1,
            HIST_GRAY = 2,
            HIST_FILTER = 3,
            HIST_BINARY = 4,
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

        private enum Operation
        {
            DILATE = 0,
            ERODE = 1,
            OPEN = 2,
            CLOSE = 3,
        };

        private enum Sharp
        {
            RECTANGLE = 0,
            CROSS = 1,
            ELLIPSE = 2,
        };

        [DllImport("OpenCvDll.dll", EntryPoint = "ImageInitial")]
        private static extern IntPtr ImageInitial(string fileName, out int thres, bool isMatch, int selectedNo);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgAmplify")]
        private static extern void ImgAmplify(AmplifyImage amplifyImage);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgOriginal")]
        private static extern IntPtr ImgOriginal();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgOriginalHist")]
        private static extern IntPtr ImgOriginalHist();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgGray")]
        private static extern IntPtr ImgGray();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgHist")]
        private static extern IntPtr ImgHist(SelectedHist selectedHist, int thresholdValue);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgFilter")]
        private static extern IntPtr ImgFilter();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgBinary")]
        private static extern IntPtr ImgBinary(int thresholdValue);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgDenoising")]
        private static extern IntPtr ImgDenoising(Operation opera, Sharp sharp, int size);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgContours")]
        private static extern IntPtr ImgContours(int height, int width, int area);

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgMinRect")]
        private static extern IntPtr ImgMinRect(int height, int width, int area);

        [DllImport("OpenCvDll.dll", EntryPoint = "GetReadDataNum")]
        private static extern int GetReadDataNum();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgRectification1")]
        private static extern IntPtr ImgRectification1();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgRectification2")]
        private static extern IntPtr ImgRectification2();

        [DllImport("OpenCvDll.dll", EntryPoint = "ImgWhiteBlackBalance")]
        private static extern IntPtr ImgWhiteBlackBalance();

        [DllImport("OpenCvDll.dll", EntryPoint = "DestroyInstance")]
        private static extern void DestroyInstance();

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct ImageParam
        { 
            public int width;
            public int height;
            public int step;
            public IntPtr data;
            public bool result;
        }

        public AnalysisForm(string fileName)
        {
            InitializeComponent();
            fileDataName = fileName;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DestroyInstance();
            loadForm = new LoadingForm();
            this.Hide();
            loadForm.Show();
        }

        private bool InitialImage(string fileName, int selectedNo)
        {
            try
            {
                string[] content = fileName.Split('.');
                isMatch = "DAT".Equals(content[content.Length-1]);

                IntPtr result = ImageInitial(fileName, out thresValue, isMatch, selectedNo);

                
                if (thresValue == 0)
                {
                    tbarBinaryHist.Value = 1;
                    tboxBinaryHist.Text = "1".ToString();
                }
                else
                {
                    tbarBinaryHist.Value = thresValue;
                    tboxBinaryHist.Text = thresValue.ToString();
                }

                if (result.ToInt32()!= SUCCESS)
                {
                    return false;
                }

                if (isMatch)
                {
                    if (!GetDataNum())
                    {
                        return false;
                    }
                    if (!GetWhiteBlackBalanceImage())
                    {
                        return false;
                    }
                }
                else
                {
                    if (!GetOriginalImage())
                    {
                        return false;
                    }
                    if (!GetOriginalHistImage())
                    {
                        return false;
                    }
                }
                if (!GetRectification1Image())
                {
                    return false;
                }
                if (!GetRectification2Image())
                {
                    return false;
                }
                if (!GetGrayImage())
                {
                    return false;
                }
                if (!GetHistImage(SelectedHist.HIST_GRAY))
                {
                    return false;
                }
                if (!GetHistImage(SelectedHist.HIST_FILTER))
                {
                    return false;
                }
                if (!GetHistImage(SelectedHist.HIST_BINARY, thresValue))
                {
                    return false;
                }
                if (!GetFilterImage())
                {
                    return false;
                }
                if (!GetBinaryImage(thresValue))
                {
                    return false;
                }
                if (!GetDenoisingBinary())
                {
                    return false;
                }
                if (!GetDenoising(Operation.OPEN, Sharp.RECTANGLE, 5))
                {
                    return false;
                }
                if (!GetContoursImage(THRESHEIGHT, THRESWIDTH, THRESAREA))
                {
                    return false;
                }
                if (!GetMinRectImage(THRESHEIGHT, THRESWIDTH, THRESAREA))
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                
                throw e;
            }
            return true;
        }

        private bool GetOriginalImage()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgOriginal(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgOriginal = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
                pboxOriginal.Image = imgOriginal;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetOriginalHistImage()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgOriginalHist(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgOriginalHist = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
                pboxOriginalHist3.Image = imgOriginalHist;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetGrayImage()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgGray(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgGray = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgGray.Palette = CvToolBox.ScalePalette;
                pboxGray.Image = imgGray;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetHistImage(SelectedHist selectedHist, int thresholdValue = 0)
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgHist(selectedHist, thresholdValue), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgHist;
                switch (selectedHist)
                {
                    case SelectedHist.HIST_GRAY:
                        imgHist = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                        imgHist.Palette = CvToolBox.ScalePalette;
                        pboxGrayHist.Image = imgHist;
                        break;
                    case SelectedHist.HIST_FILTER:
                        imgHist = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                        imgHist.Palette = CvToolBox.ScalePalette;
                        pboxFilterHist.Image = imgHist;
                        break;
                    case SelectedHist.HIST_BINARY:
                        imgHist = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
                        pboxBinaryHist.Image = imgHist;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetFilterImage()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgFilter(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgFilter = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgFilter.Palette = CvToolBox.ScalePalette;
                pboxFilter.Image = imgFilter;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetBinaryImage(int thresholdValue)
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgBinary(thresholdValue), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgBinary = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgBinary.Palette = CvToolBox.ScalePalette;
                pboxBinary.Image = imgBinary;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetDenoisingBinary()
        {
            pboxDenoisingBinary.Image = pboxBinary.Image;
            return true;
        }

        private bool GetDenoising(Operation opera, Sharp sharp, int size)
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgDenoising(opera, sharp, size), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgDenoising = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgDenoising.Palette = CvToolBox.ScalePalette;
                pboxDenoising.Image = imgDenoising;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetContoursImage(int height, int width, int area)
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgContours(height, width, area), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgContours = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
                pboxContours.Image = imgContours;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetMinRectImage(int height, int width, int area)
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgMinRect(height, width, area), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgMinRect = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
                pboxMinRect.Image = imgMinRect;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetDataNum()
        {
            bool rel = true;
            try
            {
                int dataNum = GetReadDataNum();
                tboxNo.Text = "1" + "/" + dataNum.ToString();
            }
            catch (Exception)
            {
                rel = false;
                throw;
            }

            return rel;
        }

        private bool GetRectification1Image()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgRectification1(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgRectification1 = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgRectification1.Palette = CvToolBox.ScalePalette;
                pboxRectification1.Image = imgRectification1;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetRectification2Image()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgRectification2(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgRectification2 = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgRectification2.Palette = CvToolBox.ScalePalette;
                pboxRectification2.Image = imgRectification2;
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool GetWhiteBlackBalanceImage()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgWhiteBlackBalance(), typeof(ImageParam));
            if (imgParam.result)
            {
                Bitmap imgBalance = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
                imgBalance.Palette = CvToolBox.ScalePalette;
                pboxOriginalHist3.Image = imgBalance;
            }
            else
            {
                return false;
            }

            return true;
        }

        public static class CvToolBox
        {
            public static readonly ColorPalette ScalePalette = GenerateScalePalette();

            private static ColorPalette GenerateScalePalette()
            {
                using (Bitmap image = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
                {
                    ColorPalette palette = image.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    return palette;
                }
            }
        }

        private void pboxOriginal_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.ORIGINAL);
        }

        private void pboxOriginalHist3_Click(object sender, EventArgs e)
        {
            if (isMatch)
            {
                ImgAmplify(AmplifyImage.WHITEBLACKBALANCE);
            }
            else
            {
                ImgAmplify(AmplifyImage.ORIGINALHIST);
            }
        }

        private void pboxGray_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.GRAY);
        }

        private void pboxGrayHist_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.HIST_GRAY);
        }

        private void pboxFilter_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.FILTER);
        }

        private void pboxFilterHist_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.HIST_FILTER);
        }

        private void pboxBinaryHist_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.HIST_BINARY);
        }

        private void pboxBinary_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.BINARY);
        }

        private void pboxDenoisingBinary_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.DENOISINGBINARY);
        }

        private void pboxDenoising_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.DENOISING);
        }

        private void pboxContours_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.CONTOURS);
        }

        private void pboxMinRect_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.MINRECT);
        }

        private void pboxRectification1_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.RECTIFICATION1);
        }

        private void pboxRectification2_Click(object sender, EventArgs e)
        {
            ImgAmplify(AmplifyImage.RECTIFICATION2);
        }

        private void tbarBinaryHist_Scroll(object sender, EventArgs e)
        {
            tboxBinaryHist.Text = tbarBinaryHist.Value.ToString();
            thresValue = tbarBinaryHist.Value;

            Thread tBinary = new Thread(ThreadBinary);
            Thread tBinaryHist = new Thread(ThreadBinaryHist);
            tBinary.Start();
            tBinaryHist.Start();
        }

        private void tboxBinaryHist_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(tboxBinaryHist.Text)>0 && Convert.ToInt16(tboxBinaryHist.Text)<256)
            {
                thresValue = Convert.ToInt16(tboxBinaryHist.Text);
                tbarBinaryHist.Value = thresValue;
            }
            else
            {
                MessageBox.Show("The threshold value is overflow!", "Warning");
            }

            Thread tBinary = new Thread(ThreadBinary);
            Thread tBinaryHist = new Thread(ThreadBinaryHist);
            tBinary.Start();
            tBinaryHist.Start();
        }

        private void ThreadBinary()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgBinary(thresValue), typeof(ImageParam));
            Bitmap imgBinary = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
            imgBinary.Palette = CvToolBox.ScalePalette;
            pboxBinary.Image = imgBinary;
            pboxDenoisingBinary.Image = imgBinary;
        }

        private void ThreadBinaryHist()
        {
            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgHist(SelectedHist.HIST_BINARY, thresValue), typeof(ImageParam));
            Bitmap imgHist = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format24bppRgb, imgParam.data);
            pboxBinaryHist.Image = imgHist;
        }

        private void radiobtnDilate_Click(object sender, EventArgs e)
        {
            radiobtnDilate.Checked = true;
            radiobtnErode.Checked = false;
            radiobtnOpen.Checked = false;
            radiobtnClose.Checked = false;

            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgDenoising(Operation.DILATE, (Sharp)comboboxSharp.SelectedIndex, Convert.ToInt16(tboxSize.Text)), typeof(ImageParam));
            Bitmap imgDenoising = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
            imgDenoising.Palette = CvToolBox.ScalePalette;
            pboxDenoising.Image = imgDenoising;
        }

        private void radiobtnErode_Click(object sender, EventArgs e)
        {
            radiobtnDilate.Checked = false;
            radiobtnErode.Checked = true;
            radiobtnOpen.Checked = false;
            radiobtnClose.Checked = false;

            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgDenoising(Operation.ERODE, (Sharp)comboboxSharp.SelectedIndex, Convert.ToInt16(tboxSize.Text)), typeof(ImageParam));
            Bitmap imgDenoising = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
            imgDenoising.Palette = CvToolBox.ScalePalette;
            pboxDenoising.Image = imgDenoising;
        }

        private void radiobtnOpen_Click(object sender, EventArgs e)
        {
            radiobtnDilate.Checked = false;
            radiobtnErode.Checked = false;
            radiobtnOpen.Checked = true;
            radiobtnClose.Checked = false;

            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgDenoising(Operation.OPEN, (Sharp)comboboxSharp.SelectedIndex, Convert.ToInt16(tboxSize.Text)), typeof(ImageParam));
            Bitmap imgDenoising = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
            imgDenoising.Palette = CvToolBox.ScalePalette;
            pboxDenoising.Image = imgDenoising;
        }

        private void radiobtnClose_Click(object sender, EventArgs e)
        {
            radiobtnDilate.Checked = false;
            radiobtnErode.Checked = false;
            radiobtnOpen.Checked = false;
            radiobtnClose.Checked = true;

            ImageParam imgParam = new ImageParam();
            imgParam = (ImageParam)Marshal.PtrToStructure(ImgDenoising(Operation.CLOSE, (Sharp)comboboxSharp.SelectedIndex, Convert.ToInt16(tboxSize.Text)), typeof(ImageParam));
            Bitmap imgDenoising = new Bitmap(imgParam.width, imgParam.height, imgParam.step, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, imgParam.data);
            imgDenoising.Palette = CvToolBox.ScalePalette;
            pboxDenoising.Image = imgDenoising;
        }

        private void btnSetThreshold_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(tboxContoursHeight.Text);
            int width = Convert.ToInt32(tboxContoursWidth.Text);
            int area = Convert.ToInt32(tboxContoursArea.Text);
            bool ret = GetContoursImage(height, width, area);
        }

        private void btnSetMinRect_Click(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(tboxMinRectHeight.Text);
            int width = Convert.ToInt32(tboxMinRectWidth.Text);
            int area = Convert.ToInt32(tboxMinRectArea.Text);
            bool ret = GetMinRectImage(height, width, area);
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            bool result = InitialImage(fileDataName, this.selectedNo);
            if (!result)
            {
                loadForm = new LoadingForm();
                this.Hide();
                loadForm.Show();
                MessageBox.Show("Data Loading Failed!", "Warning");
            }

            //Binary
            radiobtnDilate.Checked = false;
            radiobtnErode.Checked = false;
            radiobtnOpen.Checked = true;
            radiobtnClose.Checked = false;
            tboxSize.Text = "5";
            comboboxSharp.SelectedIndex = 0;

            //Contours
            tboxContoursHeight.Text = THRESHEIGHT.ToString();
            tboxContoursWidth.Text = THRESWIDTH.ToString();
            tboxContoursArea.Text = THRESAREA.ToString();

            //MinRect
            tboxMinRectHeight.Text = THRESHEIGHT.ToString();
            tboxMinRectWidth.Text = THRESWIDTH.ToString();
            tboxMinRectArea.Text = THRESAREA.ToString();

            tboxNo.ReadOnly = true;
            if (this.isMatch)
            {
                pboxOriginal.Visible = false;
            }
        }

        private void AnalysisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (isMatch)
            {
                string[] content = tboxNo.Text.Split('/');
                if (this.selectedNo > 1)
                {
                    this.selectedNo--;
                    bool result = InitialImage(fileDataName, this.selectedNo);
                    if (!result)
                    {
                        MessageBox.Show("Data Loading Failed!", "Warning");
                    }
                    else
                    {
                        tboxNo.Text = this.selectedNo.ToString() + "/" + content[1];
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (isMatch)
            {
                string[] content = tboxNo.Text.Split('/');
                if (this.selectedNo < Convert.ToInt16(content[1]))
                {
                    this.selectedNo++;
                    bool result = InitialImage(fileDataName, this.selectedNo);
                    if (!result)
                    {
                        MessageBox.Show("Data Loading Failed!", "Warning");
                    }
                    else
                    {
                        tboxNo.Text = this.selectedNo.ToString() + "/" + content[1];
                    }
                }
            }
        }
    }
}

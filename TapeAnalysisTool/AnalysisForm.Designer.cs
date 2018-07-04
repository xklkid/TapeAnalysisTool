namespace TapeAnalysisTool
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpageOriginal = new System.Windows.Forms.TabPage();
            this.pboxOriginalHist3 = new System.Windows.Forms.PictureBox();
            this.pboxOriginal = new System.Windows.Forms.PictureBox();
            this.tpageRectification = new System.Windows.Forms.TabPage();
            this.pboxRectification2 = new System.Windows.Forms.PictureBox();
            this.pboxRectification1 = new System.Windows.Forms.PictureBox();
            this.tpageGray = new System.Windows.Forms.TabPage();
            this.pboxGrayHist = new System.Windows.Forms.PictureBox();
            this.pboxGray = new System.Windows.Forms.PictureBox();
            this.tpageFilter = new System.Windows.Forms.TabPage();
            this.pboxFilterHist = new System.Windows.Forms.PictureBox();
            this.pboxFilter = new System.Windows.Forms.PictureBox();
            this.tpageBinary = new System.Windows.Forms.TabPage();
            this.pboxHistColor = new System.Windows.Forms.PictureBox();
            this.tboxBinaryHist = new System.Windows.Forms.TextBox();
            this.tbarBinaryHist = new System.Windows.Forms.TrackBar();
            this.pboxBinary = new System.Windows.Forms.PictureBox();
            this.pboxBinaryHist = new System.Windows.Forms.PictureBox();
            this.tpageDenoising = new System.Windows.Forms.TabPage();
            this.labelSharp = new System.Windows.Forms.Label();
            this.comboboxSharp = new System.Windows.Forms.ComboBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.tboxSize = new System.Windows.Forms.TextBox();
            this.radiobtnClose = new System.Windows.Forms.RadioButton();
            this.radiobtnOpen = new System.Windows.Forms.RadioButton();
            this.radiobtnErode = new System.Windows.Forms.RadioButton();
            this.radiobtnDilate = new System.Windows.Forms.RadioButton();
            this.pboxDenoising = new System.Windows.Forms.PictureBox();
            this.pboxDenoisingBinary = new System.Windows.Forms.PictureBox();
            this.tpageContours = new System.Windows.Forms.TabPage();
            this.labelContoursArea = new System.Windows.Forms.Label();
            this.labelContoursWidth = new System.Windows.Forms.Label();
            this.labelContoursHeight = new System.Windows.Forms.Label();
            this.tboxContoursArea = new System.Windows.Forms.TextBox();
            this.tboxContoursWidth = new System.Windows.Forms.TextBox();
            this.tboxContoursHeight = new System.Windows.Forms.TextBox();
            this.btnSetThreshold = new System.Windows.Forms.Button();
            this.pboxContours = new System.Windows.Forms.PictureBox();
            this.tpageMinRect = new System.Windows.Forms.TabPage();
            this.tboxMinRectArea = new System.Windows.Forms.TextBox();
            this.tboxMinRectWidth = new System.Windows.Forms.TextBox();
            this.tboxMinRectHeight = new System.Windows.Forms.TextBox();
            this.btnSetMinRect = new System.Windows.Forms.Button();
            this.labelMinRectArea = new System.Windows.Forms.Label();
            this.labelMinRectWidth = new System.Windows.Forms.Label();
            this.labelMinRectHeight = new System.Windows.Forms.Label();
            this.pboxMinRect = new System.Windows.Forms.PictureBox();
            this.labelNo = new System.Windows.Forms.Label();
            this.tboxNo = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBefore = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpageOriginal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOriginalHist3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOriginal)).BeginInit();
            this.tpageRectification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRectification2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRectification1)).BeginInit();
            this.tpageGray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGrayHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGray)).BeginInit();
            this.tpageFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFilterHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFilter)).BeginInit();
            this.tpageBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHistColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarBinaryHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBinary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBinaryHist)).BeginInit();
            this.tpageDenoising.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDenoising)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDenoisingBinary)).BeginInit();
            this.tpageContours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxContours)).BeginInit();
            this.tpageMinRect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinRect)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpageOriginal);
            this.tabControl.Controls.Add(this.tpageRectification);
            this.tabControl.Controls.Add(this.tpageGray);
            this.tabControl.Controls.Add(this.tpageFilter);
            this.tabControl.Controls.Add(this.tpageBinary);
            this.tabControl.Controls.Add(this.tpageDenoising);
            this.tabControl.Controls.Add(this.tpageContours);
            this.tabControl.Controls.Add(this.tpageMinRect);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(577, 493);
            this.tabControl.TabIndex = 1;
            // 
            // tpageOriginal
            // 
            this.tpageOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.tpageOriginal.Controls.Add(this.pboxOriginalHist3);
            this.tpageOriginal.Controls.Add(this.pboxOriginal);
            this.tpageOriginal.Location = new System.Drawing.Point(4, 22);
            this.tpageOriginal.Name = "tpageOriginal";
            this.tpageOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tpageOriginal.Size = new System.Drawing.Size(569, 467);
            this.tpageOriginal.TabIndex = 0;
            this.tpageOriginal.Text = "Original";
            // 
            // pboxOriginalHist3
            // 
            this.pboxOriginalHist3.BackColor = System.Drawing.Color.DarkGray;
            this.pboxOriginalHist3.Location = new System.Drawing.Point(295, 25);
            this.pboxOriginalHist3.Name = "pboxOriginalHist3";
            this.pboxOriginalHist3.Size = new System.Drawing.Size(250, 250);
            this.pboxOriginalHist3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxOriginalHist3.TabIndex = 1;
            this.pboxOriginalHist3.TabStop = false;
            this.pboxOriginalHist3.Click += new System.EventHandler(this.pboxOriginalHist3_Click);
            // 
            // pboxOriginal
            // 
            this.pboxOriginal.BackColor = System.Drawing.Color.DarkGray;
            this.pboxOriginal.Location = new System.Drawing.Point(20, 25);
            this.pboxOriginal.Name = "pboxOriginal";
            this.pboxOriginal.Size = new System.Drawing.Size(250, 250);
            this.pboxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxOriginal.TabIndex = 0;
            this.pboxOriginal.TabStop = false;
            this.pboxOriginal.Click += new System.EventHandler(this.pboxOriginal_Click);
            // 
            // tpageRectification
            // 
            this.tpageRectification.BackColor = System.Drawing.SystemColors.Control;
            this.tpageRectification.Controls.Add(this.pboxRectification2);
            this.tpageRectification.Controls.Add(this.pboxRectification1);
            this.tpageRectification.Location = new System.Drawing.Point(4, 22);
            this.tpageRectification.Name = "tpageRectification";
            this.tpageRectification.Size = new System.Drawing.Size(569, 467);
            this.tpageRectification.TabIndex = 7;
            this.tpageRectification.Text = "Rectification";
            // 
            // pboxRectification2
            // 
            this.pboxRectification2.BackColor = System.Drawing.Color.DarkGray;
            this.pboxRectification2.Location = new System.Drawing.Point(22, 248);
            this.pboxRectification2.Name = "pboxRectification2";
            this.pboxRectification2.Size = new System.Drawing.Size(526, 185);
            this.pboxRectification2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxRectification2.TabIndex = 2;
            this.pboxRectification2.TabStop = false;
            this.pboxRectification2.Click += new System.EventHandler(this.pboxRectification2_Click);
            // 
            // pboxRectification1
            // 
            this.pboxRectification1.BackColor = System.Drawing.Color.DarkGray;
            this.pboxRectification1.Location = new System.Drawing.Point(22, 25);
            this.pboxRectification1.Name = "pboxRectification1";
            this.pboxRectification1.Size = new System.Drawing.Size(526, 185);
            this.pboxRectification1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxRectification1.TabIndex = 1;
            this.pboxRectification1.TabStop = false;
            this.pboxRectification1.Click += new System.EventHandler(this.pboxRectification1_Click);
            // 
            // tpageGray
            // 
            this.tpageGray.BackColor = System.Drawing.SystemColors.Control;
            this.tpageGray.Controls.Add(this.pboxGrayHist);
            this.tpageGray.Controls.Add(this.pboxGray);
            this.tpageGray.Location = new System.Drawing.Point(4, 22);
            this.tpageGray.Name = "tpageGray";
            this.tpageGray.Padding = new System.Windows.Forms.Padding(3);
            this.tpageGray.Size = new System.Drawing.Size(569, 467);
            this.tpageGray.TabIndex = 1;
            this.tpageGray.Text = "Gray";
            // 
            // pboxGrayHist
            // 
            this.pboxGrayHist.BackColor = System.Drawing.Color.DarkGray;
            this.pboxGrayHist.Location = new System.Drawing.Point(295, 25);
            this.pboxGrayHist.Name = "pboxGrayHist";
            this.pboxGrayHist.Size = new System.Drawing.Size(250, 250);
            this.pboxGrayHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxGrayHist.TabIndex = 1;
            this.pboxGrayHist.TabStop = false;
            this.pboxGrayHist.Click += new System.EventHandler(this.pboxGrayHist_Click);
            // 
            // pboxGray
            // 
            this.pboxGray.BackColor = System.Drawing.Color.DarkGray;
            this.pboxGray.Location = new System.Drawing.Point(20, 25);
            this.pboxGray.Name = "pboxGray";
            this.pboxGray.Size = new System.Drawing.Size(250, 250);
            this.pboxGray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxGray.TabIndex = 0;
            this.pboxGray.TabStop = false;
            this.pboxGray.Click += new System.EventHandler(this.pboxGray_Click);
            // 
            // tpageFilter
            // 
            this.tpageFilter.BackColor = System.Drawing.SystemColors.Control;
            this.tpageFilter.Controls.Add(this.pboxFilterHist);
            this.tpageFilter.Controls.Add(this.pboxFilter);
            this.tpageFilter.Location = new System.Drawing.Point(4, 22);
            this.tpageFilter.Name = "tpageFilter";
            this.tpageFilter.Size = new System.Drawing.Size(569, 467);
            this.tpageFilter.TabIndex = 2;
            this.tpageFilter.Text = "Filter";
            // 
            // pboxFilterHist
            // 
            this.pboxFilterHist.BackColor = System.Drawing.Color.DarkGray;
            this.pboxFilterHist.Location = new System.Drawing.Point(295, 25);
            this.pboxFilterHist.Name = "pboxFilterHist";
            this.pboxFilterHist.Size = new System.Drawing.Size(250, 250);
            this.pboxFilterHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxFilterHist.TabIndex = 1;
            this.pboxFilterHist.TabStop = false;
            this.pboxFilterHist.Click += new System.EventHandler(this.pboxFilterHist_Click);
            // 
            // pboxFilter
            // 
            this.pboxFilter.BackColor = System.Drawing.Color.DarkGray;
            this.pboxFilter.Location = new System.Drawing.Point(20, 25);
            this.pboxFilter.Name = "pboxFilter";
            this.pboxFilter.Size = new System.Drawing.Size(250, 250);
            this.pboxFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxFilter.TabIndex = 0;
            this.pboxFilter.TabStop = false;
            this.pboxFilter.Click += new System.EventHandler(this.pboxFilter_Click);
            // 
            // tpageBinary
            // 
            this.tpageBinary.BackColor = System.Drawing.SystemColors.Control;
            this.tpageBinary.Controls.Add(this.pboxHistColor);
            this.tpageBinary.Controls.Add(this.tboxBinaryHist);
            this.tpageBinary.Controls.Add(this.tbarBinaryHist);
            this.tpageBinary.Controls.Add(this.pboxBinary);
            this.tpageBinary.Controls.Add(this.pboxBinaryHist);
            this.tpageBinary.Location = new System.Drawing.Point(4, 22);
            this.tpageBinary.Name = "tpageBinary";
            this.tpageBinary.Size = new System.Drawing.Size(569, 467);
            this.tpageBinary.TabIndex = 3;
            this.tpageBinary.Text = "Binary";
            // 
            // pboxHistColor
            // 
            this.pboxHistColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pboxHistColor.BackgroundImage")));
            this.pboxHistColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pboxHistColor.Location = new System.Drawing.Point(20, 275);
            this.pboxHistColor.Name = "pboxHistColor";
            this.pboxHistColor.Size = new System.Drawing.Size(250, 17);
            this.pboxHistColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxHistColor.TabIndex = 4;
            this.pboxHistColor.TabStop = false;
            // 
            // tboxBinaryHist
            // 
            this.tboxBinaryHist.Location = new System.Drawing.Point(233, 294);
            this.tboxBinaryHist.Name = "tboxBinaryHist";
            this.tboxBinaryHist.Size = new System.Drawing.Size(37, 21);
            this.tboxBinaryHist.TabIndex = 3;
            this.tboxBinaryHist.TextChanged += new System.EventHandler(this.tboxBinaryHist_TextChanged);
            // 
            // tbarBinaryHist
            // 
            this.tbarBinaryHist.AutoSize = false;
            this.tbarBinaryHist.Location = new System.Drawing.Point(20, 294);
            this.tbarBinaryHist.Maximum = 255;
            this.tbarBinaryHist.Name = "tbarBinaryHist";
            this.tbarBinaryHist.Size = new System.Drawing.Size(207, 21);
            this.tbarBinaryHist.TabIndex = 2;
            this.tbarBinaryHist.Scroll += new System.EventHandler(this.tbarBinaryHist_Scroll);
            // 
            // pboxBinary
            // 
            this.pboxBinary.BackColor = System.Drawing.Color.DarkGray;
            this.pboxBinary.Location = new System.Drawing.Point(295, 25);
            this.pboxBinary.Name = "pboxBinary";
            this.pboxBinary.Size = new System.Drawing.Size(250, 250);
            this.pboxBinary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxBinary.TabIndex = 1;
            this.pboxBinary.TabStop = false;
            this.pboxBinary.Click += new System.EventHandler(this.pboxBinary_Click);
            // 
            // pboxBinaryHist
            // 
            this.pboxBinaryHist.BackColor = System.Drawing.Color.DarkGray;
            this.pboxBinaryHist.Location = new System.Drawing.Point(20, 25);
            this.pboxBinaryHist.Name = "pboxBinaryHist";
            this.pboxBinaryHist.Size = new System.Drawing.Size(250, 250);
            this.pboxBinaryHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxBinaryHist.TabIndex = 0;
            this.pboxBinaryHist.TabStop = false;
            this.pboxBinaryHist.Click += new System.EventHandler(this.pboxBinaryHist_Click);
            // 
            // tpageDenoising
            // 
            this.tpageDenoising.BackColor = System.Drawing.SystemColors.Control;
            this.tpageDenoising.Controls.Add(this.labelSharp);
            this.tpageDenoising.Controls.Add(this.comboboxSharp);
            this.tpageDenoising.Controls.Add(this.labelSize);
            this.tpageDenoising.Controls.Add(this.tboxSize);
            this.tpageDenoising.Controls.Add(this.radiobtnClose);
            this.tpageDenoising.Controls.Add(this.radiobtnOpen);
            this.tpageDenoising.Controls.Add(this.radiobtnErode);
            this.tpageDenoising.Controls.Add(this.radiobtnDilate);
            this.tpageDenoising.Controls.Add(this.pboxDenoising);
            this.tpageDenoising.Controls.Add(this.pboxDenoisingBinary);
            this.tpageDenoising.Location = new System.Drawing.Point(4, 22);
            this.tpageDenoising.Name = "tpageDenoising";
            this.tpageDenoising.Size = new System.Drawing.Size(569, 467);
            this.tpageDenoising.TabIndex = 4;
            this.tpageDenoising.Text = "Denoising";
            // 
            // labelSharp
            // 
            this.labelSharp.AutoSize = true;
            this.labelSharp.Location = new System.Drawing.Point(293, 339);
            this.labelSharp.Name = "labelSharp";
            this.labelSharp.Size = new System.Drawing.Size(35, 12);
            this.labelSharp.TabIndex = 9;
            this.labelSharp.Text = "Sharp";
            // 
            // comboboxSharp
            // 
            this.comboboxSharp.FormattingEnabled = true;
            this.comboboxSharp.Items.AddRange(new object[] {
            "Rectangle",
            "Cross",
            "Ellipse"});
            this.comboboxSharp.Location = new System.Drawing.Point(334, 337);
            this.comboboxSharp.Name = "comboboxSharp";
            this.comboboxSharp.Size = new System.Drawing.Size(78, 20);
            this.comboboxSharp.TabIndex = 8;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(447, 339);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(29, 12);
            this.labelSize.TabIndex = 7;
            this.labelSize.Text = "Size";
            // 
            // tboxSize
            // 
            this.tboxSize.Location = new System.Drawing.Point(483, 336);
            this.tboxSize.Name = "tboxSize";
            this.tboxSize.Size = new System.Drawing.Size(62, 21);
            this.tboxSize.TabIndex = 6;
            // 
            // radiobtnClose
            // 
            this.radiobtnClose.AutoSize = true;
            this.radiobtnClose.Location = new System.Drawing.Point(449, 303);
            this.radiobtnClose.Name = "radiobtnClose";
            this.radiobtnClose.Size = new System.Drawing.Size(119, 16);
            this.radiobtnClose.TabIndex = 5;
            this.radiobtnClose.Text = "Closed Operation";
            this.radiobtnClose.UseVisualStyleBackColor = true;
            this.radiobtnClose.Click += new System.EventHandler(this.radiobtnClose_Click);
            // 
            // radiobtnOpen
            // 
            this.radiobtnOpen.AutoSize = true;
            this.radiobtnOpen.Location = new System.Drawing.Point(295, 303);
            this.radiobtnOpen.Name = "radiobtnOpen";
            this.radiobtnOpen.Size = new System.Drawing.Size(107, 16);
            this.radiobtnOpen.TabIndex = 4;
            this.radiobtnOpen.Text = "Open Operation";
            this.radiobtnOpen.UseVisualStyleBackColor = true;
            this.radiobtnOpen.Click += new System.EventHandler(this.radiobtnOpen_Click);
            // 
            // radiobtnErode
            // 
            this.radiobtnErode.AutoSize = true;
            this.radiobtnErode.Location = new System.Drawing.Point(449, 281);
            this.radiobtnErode.Name = "radiobtnErode";
            this.radiobtnErode.Size = new System.Drawing.Size(53, 16);
            this.radiobtnErode.TabIndex = 3;
            this.radiobtnErode.Text = "Erode";
            this.radiobtnErode.UseVisualStyleBackColor = true;
            this.radiobtnErode.Click += new System.EventHandler(this.radiobtnErode_Click);
            // 
            // radiobtnDilate
            // 
            this.radiobtnDilate.AutoSize = true;
            this.radiobtnDilate.Location = new System.Drawing.Point(295, 281);
            this.radiobtnDilate.Name = "radiobtnDilate";
            this.radiobtnDilate.Size = new System.Drawing.Size(59, 16);
            this.radiobtnDilate.TabIndex = 2;
            this.radiobtnDilate.Text = "Dilate";
            this.radiobtnDilate.UseVisualStyleBackColor = true;
            this.radiobtnDilate.Click += new System.EventHandler(this.radiobtnDilate_Click);
            // 
            // pboxDenoising
            // 
            this.pboxDenoising.BackColor = System.Drawing.Color.DarkGray;
            this.pboxDenoising.Location = new System.Drawing.Point(295, 25);
            this.pboxDenoising.Name = "pboxDenoising";
            this.pboxDenoising.Size = new System.Drawing.Size(250, 250);
            this.pboxDenoising.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxDenoising.TabIndex = 1;
            this.pboxDenoising.TabStop = false;
            this.pboxDenoising.Click += new System.EventHandler(this.pboxDenoising_Click);
            // 
            // pboxDenoisingBinary
            // 
            this.pboxDenoisingBinary.BackColor = System.Drawing.Color.DarkGray;
            this.pboxDenoisingBinary.Location = new System.Drawing.Point(20, 25);
            this.pboxDenoisingBinary.Name = "pboxDenoisingBinary";
            this.pboxDenoisingBinary.Size = new System.Drawing.Size(250, 250);
            this.pboxDenoisingBinary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxDenoisingBinary.TabIndex = 0;
            this.pboxDenoisingBinary.TabStop = false;
            this.pboxDenoisingBinary.Click += new System.EventHandler(this.pboxDenoisingBinary_Click);
            // 
            // tpageContours
            // 
            this.tpageContours.BackColor = System.Drawing.SystemColors.Control;
            this.tpageContours.Controls.Add(this.labelContoursArea);
            this.tpageContours.Controls.Add(this.labelContoursWidth);
            this.tpageContours.Controls.Add(this.labelContoursHeight);
            this.tpageContours.Controls.Add(this.tboxContoursArea);
            this.tpageContours.Controls.Add(this.tboxContoursWidth);
            this.tpageContours.Controls.Add(this.tboxContoursHeight);
            this.tpageContours.Controls.Add(this.btnSetThreshold);
            this.tpageContours.Controls.Add(this.pboxContours);
            this.tpageContours.Location = new System.Drawing.Point(4, 22);
            this.tpageContours.Name = "tpageContours";
            this.tpageContours.Size = new System.Drawing.Size(569, 467);
            this.tpageContours.TabIndex = 5;
            this.tpageContours.Text = "Contours";
            // 
            // labelContoursArea
            // 
            this.labelContoursArea.AutoSize = true;
            this.labelContoursArea.Location = new System.Drawing.Point(288, 218);
            this.labelContoursArea.Name = "labelContoursArea";
            this.labelContoursArea.Size = new System.Drawing.Size(29, 12);
            this.labelContoursArea.TabIndex = 10;
            this.labelContoursArea.Text = "Area";
            // 
            // labelContoursWidth
            // 
            this.labelContoursWidth.AutoSize = true;
            this.labelContoursWidth.Location = new System.Drawing.Point(288, 177);
            this.labelContoursWidth.Name = "labelContoursWidth";
            this.labelContoursWidth.Size = new System.Drawing.Size(35, 12);
            this.labelContoursWidth.TabIndex = 9;
            this.labelContoursWidth.Text = "Width";
            // 
            // labelContoursHeight
            // 
            this.labelContoursHeight.AutoSize = true;
            this.labelContoursHeight.Location = new System.Drawing.Point(288, 139);
            this.labelContoursHeight.Name = "labelContoursHeight";
            this.labelContoursHeight.Size = new System.Drawing.Size(41, 12);
            this.labelContoursHeight.TabIndex = 8;
            this.labelContoursHeight.Text = "Height";
            // 
            // tboxContoursArea
            // 
            this.tboxContoursArea.Location = new System.Drawing.Point(335, 215);
            this.tboxContoursArea.Name = "tboxContoursArea";
            this.tboxContoursArea.Size = new System.Drawing.Size(61, 21);
            this.tboxContoursArea.TabIndex = 7;
            // 
            // tboxContoursWidth
            // 
            this.tboxContoursWidth.Location = new System.Drawing.Point(335, 174);
            this.tboxContoursWidth.Name = "tboxContoursWidth";
            this.tboxContoursWidth.Size = new System.Drawing.Size(61, 21);
            this.tboxContoursWidth.TabIndex = 6;
            // 
            // tboxContoursHeight
            // 
            this.tboxContoursHeight.Location = new System.Drawing.Point(335, 136);
            this.tboxContoursHeight.Name = "tboxContoursHeight";
            this.tboxContoursHeight.Size = new System.Drawing.Size(61, 21);
            this.tboxContoursHeight.TabIndex = 5;
            // 
            // btnSetThreshold
            // 
            this.btnSetThreshold.Location = new System.Drawing.Point(290, 252);
            this.btnSetThreshold.Name = "btnSetThreshold";
            this.btnSetThreshold.Size = new System.Drawing.Size(75, 23);
            this.btnSetThreshold.TabIndex = 4;
            this.btnSetThreshold.Text = "SET";
            this.btnSetThreshold.UseVisualStyleBackColor = true;
            this.btnSetThreshold.Click += new System.EventHandler(this.btnSetThreshold_Click);
            // 
            // pboxContours
            // 
            this.pboxContours.BackColor = System.Drawing.Color.DarkGray;
            this.pboxContours.Location = new System.Drawing.Point(20, 25);
            this.pboxContours.Name = "pboxContours";
            this.pboxContours.Size = new System.Drawing.Size(250, 250);
            this.pboxContours.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxContours.TabIndex = 0;
            this.pboxContours.TabStop = false;
            this.pboxContours.Click += new System.EventHandler(this.pboxContours_Click);
            // 
            // tpageMinRect
            // 
            this.tpageMinRect.BackColor = System.Drawing.SystemColors.Control;
            this.tpageMinRect.Controls.Add(this.tboxMinRectArea);
            this.tpageMinRect.Controls.Add(this.tboxMinRectWidth);
            this.tpageMinRect.Controls.Add(this.tboxMinRectHeight);
            this.tpageMinRect.Controls.Add(this.btnSetMinRect);
            this.tpageMinRect.Controls.Add(this.labelMinRectArea);
            this.tpageMinRect.Controls.Add(this.labelMinRectWidth);
            this.tpageMinRect.Controls.Add(this.labelMinRectHeight);
            this.tpageMinRect.Controls.Add(this.pboxMinRect);
            this.tpageMinRect.Location = new System.Drawing.Point(4, 22);
            this.tpageMinRect.Name = "tpageMinRect";
            this.tpageMinRect.Size = new System.Drawing.Size(569, 467);
            this.tpageMinRect.TabIndex = 6;
            this.tpageMinRect.Text = "MinRect";
            // 
            // tboxMinRectArea
            // 
            this.tboxMinRectArea.Location = new System.Drawing.Point(335, 215);
            this.tboxMinRectArea.Name = "tboxMinRectArea";
            this.tboxMinRectArea.Size = new System.Drawing.Size(61, 21);
            this.tboxMinRectArea.TabIndex = 7;
            // 
            // tboxMinRectWidth
            // 
            this.tboxMinRectWidth.Location = new System.Drawing.Point(335, 174);
            this.tboxMinRectWidth.Name = "tboxMinRectWidth";
            this.tboxMinRectWidth.Size = new System.Drawing.Size(61, 21);
            this.tboxMinRectWidth.TabIndex = 6;
            // 
            // tboxMinRectHeight
            // 
            this.tboxMinRectHeight.Location = new System.Drawing.Point(335, 136);
            this.tboxMinRectHeight.Name = "tboxMinRectHeight";
            this.tboxMinRectHeight.Size = new System.Drawing.Size(61, 21);
            this.tboxMinRectHeight.TabIndex = 5;
            // 
            // btnSetMinRect
            // 
            this.btnSetMinRect.Location = new System.Drawing.Point(290, 252);
            this.btnSetMinRect.Name = "btnSetMinRect";
            this.btnSetMinRect.Size = new System.Drawing.Size(75, 23);
            this.btnSetMinRect.TabIndex = 4;
            this.btnSetMinRect.Text = "SET";
            this.btnSetMinRect.UseVisualStyleBackColor = true;
            this.btnSetMinRect.Click += new System.EventHandler(this.btnSetMinRect_Click);
            // 
            // labelMinRectArea
            // 
            this.labelMinRectArea.AutoSize = true;
            this.labelMinRectArea.Location = new System.Drawing.Point(288, 218);
            this.labelMinRectArea.Name = "labelMinRectArea";
            this.labelMinRectArea.Size = new System.Drawing.Size(29, 12);
            this.labelMinRectArea.TabIndex = 3;
            this.labelMinRectArea.Text = "Area";
            // 
            // labelMinRectWidth
            // 
            this.labelMinRectWidth.AutoSize = true;
            this.labelMinRectWidth.Location = new System.Drawing.Point(288, 177);
            this.labelMinRectWidth.Name = "labelMinRectWidth";
            this.labelMinRectWidth.Size = new System.Drawing.Size(35, 12);
            this.labelMinRectWidth.TabIndex = 2;
            this.labelMinRectWidth.Text = "Width";
            // 
            // labelMinRectHeight
            // 
            this.labelMinRectHeight.AutoSize = true;
            this.labelMinRectHeight.Location = new System.Drawing.Point(288, 139);
            this.labelMinRectHeight.Name = "labelMinRectHeight";
            this.labelMinRectHeight.Size = new System.Drawing.Size(41, 12);
            this.labelMinRectHeight.TabIndex = 1;
            this.labelMinRectHeight.Text = "Height";
            // 
            // pboxMinRect
            // 
            this.pboxMinRect.BackColor = System.Drawing.Color.DarkGray;
            this.pboxMinRect.Location = new System.Drawing.Point(20, 25);
            this.pboxMinRect.Name = "pboxMinRect";
            this.pboxMinRect.Size = new System.Drawing.Size(250, 250);
            this.pboxMinRect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxMinRect.TabIndex = 0;
            this.pboxMinRect.TabStop = false;
            this.pboxMinRect.Click += new System.EventHandler(this.pboxMinRect_Click);
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Location = new System.Drawing.Point(592, 36);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(23, 12);
            this.labelNo.TabIndex = 2;
            this.labelNo.Text = "No.";
            // 
            // tboxNo
            // 
            this.tboxNo.Location = new System.Drawing.Point(618, 32);
            this.tboxNo.Name = "tboxNo";
            this.tboxNo.Size = new System.Drawing.Size(48, 21);
            this.tboxNo.TabIndex = 3;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(591, 484);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBefore
            // 
            this.btnBefore.Location = new System.Drawing.Point(591, 75);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.Size = new System.Drawing.Size(75, 23);
            this.btnBefore.TabIndex = 5;
            this.btnBefore.Text = "Before";
            this.btnBefore.UseVisualStyleBackColor = true;
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(591, 104);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 519);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBefore);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.tboxNo);
            this.Controls.Add(this.labelNo);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalysisForm_FormClosed);
            this.Load += new System.EventHandler(this.AnalysisForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tpageOriginal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxOriginalHist3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxOriginal)).EndInit();
            this.tpageRectification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxRectification2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRectification1)).EndInit();
            this.tpageGray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxGrayHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGray)).EndInit();
            this.tpageFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxFilterHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFilter)).EndInit();
            this.tpageBinary.ResumeLayout(false);
            this.tpageBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHistColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarBinaryHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBinary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBinaryHist)).EndInit();
            this.tpageDenoising.ResumeLayout(false);
            this.tpageDenoising.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDenoising)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxDenoisingBinary)).EndInit();
            this.tpageContours.ResumeLayout(false);
            this.tpageContours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxContours)).EndInit();
            this.tpageMinRect.ResumeLayout(false);
            this.tpageMinRect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinRect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpageOriginal;
        private System.Windows.Forms.TabPage tpageGray;
        private System.Windows.Forms.TabPage tpageFilter;
        private System.Windows.Forms.TabPage tpageBinary;
        private System.Windows.Forms.TabPage tpageDenoising;
        private System.Windows.Forms.TabPage tpageContours;
        private System.Windows.Forms.TabPage tpageMinRect;
        private System.Windows.Forms.Label labelNo;
        private System.Windows.Forms.TextBox tboxNo;
        private System.Windows.Forms.PictureBox pboxOriginal;
        private System.Windows.Forms.PictureBox pboxGrayHist;
        private System.Windows.Forms.PictureBox pboxGray;
        private System.Windows.Forms.PictureBox pboxFilterHist;
        private System.Windows.Forms.PictureBox pboxFilter;
        private System.Windows.Forms.PictureBox pboxBinary;
        private System.Windows.Forms.PictureBox pboxBinaryHist;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TrackBar tbarBinaryHist;
        private System.Windows.Forms.TextBox tboxBinaryHist;
        private System.Windows.Forms.PictureBox pboxHistColor;
        private System.Windows.Forms.PictureBox pboxDenoising;
        private System.Windows.Forms.PictureBox pboxDenoisingBinary;
        private System.Windows.Forms.Label labelSharp;
        private System.Windows.Forms.ComboBox comboboxSharp;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox tboxSize;
        private System.Windows.Forms.RadioButton radiobtnClose;
        private System.Windows.Forms.RadioButton radiobtnOpen;
        private System.Windows.Forms.RadioButton radiobtnErode;
        private System.Windows.Forms.RadioButton radiobtnDilate;
        private System.Windows.Forms.PictureBox pboxOriginalHist3;
        private System.Windows.Forms.PictureBox pboxContours;
        private System.Windows.Forms.PictureBox pboxMinRect;
        private System.Windows.Forms.Button btnSetThreshold;
        private System.Windows.Forms.Label labelContoursArea;
        private System.Windows.Forms.Label labelContoursWidth;
        private System.Windows.Forms.Label labelContoursHeight;
        private System.Windows.Forms.TextBox tboxContoursArea;
        private System.Windows.Forms.TextBox tboxContoursWidth;
        private System.Windows.Forms.TextBox tboxContoursHeight;
        private System.Windows.Forms.TextBox tboxMinRectArea;
        private System.Windows.Forms.TextBox tboxMinRectWidth;
        private System.Windows.Forms.TextBox tboxMinRectHeight;
        private System.Windows.Forms.Button btnSetMinRect;
        private System.Windows.Forms.Label labelMinRectArea;
        private System.Windows.Forms.Label labelMinRectWidth;
        private System.Windows.Forms.Label labelMinRectHeight;
        private System.Windows.Forms.Button btnBefore;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpageRectification;
        private System.Windows.Forms.PictureBox pboxRectification2;
        private System.Windows.Forms.PictureBox pboxRectification1;
    }
}
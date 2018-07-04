namespace TapeAnalysisTool
{
    partial class LoadingForm
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
            this.gboxDataPath = new System.Windows.Forms.GroupBox();
            this.tboxDataPath = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.labelTape = new System.Windows.Forms.Label();
            this.gboxDataPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxDataPath
            // 
            this.gboxDataPath.Controls.Add(this.tboxDataPath);
            this.gboxDataPath.Controls.Add(this.btnLoad);
            this.gboxDataPath.Location = new System.Drawing.Point(12, 49);
            this.gboxDataPath.Name = "gboxDataPath";
            this.gboxDataPath.Size = new System.Drawing.Size(597, 57);
            this.gboxDataPath.TabIndex = 0;
            this.gboxDataPath.TabStop = false;
            this.gboxDataPath.Text = "Data Path";
            // 
            // tboxDataPath
            // 
            this.tboxDataPath.Location = new System.Drawing.Point(6, 21);
            this.tboxDataPath.Name = "tboxDataPath";
            this.tboxDataPath.Size = new System.Drawing.Size(510, 21);
            this.tboxDataPath.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(522, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(69, 34);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(436, 225);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(534, 225);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // labelTape
            // 
            this.labelTape.AutoSize = true;
            this.labelTape.Font = new System.Drawing.Font("SimSun", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTape.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTape.Location = new System.Drawing.Point(173, 11);
            this.labelTape.Name = "labelTape";
            this.labelTape.Size = new System.Drawing.Size(283, 29);
            this.labelTape.TabIndex = 3;
            this.labelTape.Text = "Tape Analysis Tool";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 262);
            this.Controls.Add(this.labelTape);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.gboxDataPath);
            this.Name = "LoadingForm";
            this.Text = "LoadingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoadingForm_FormClosed);
            this.gboxDataPath.ResumeLayout(false);
            this.gboxDataPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxDataPath;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tboxDataPath;
        private System.Windows.Forms.Label labelTape;
    }
}
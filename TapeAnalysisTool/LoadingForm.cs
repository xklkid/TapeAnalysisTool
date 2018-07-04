using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TapeAnalysisTool
{
    public partial class LoadingForm : Form
    {
        OpenFileDialog LoadDataFilePath = null;
        AnalysisForm anaForm = null;

        public LoadingForm()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataFilePath = new OpenFileDialog();
            LoadDataFilePath.Filter = "All files (*.*)|*.*";
            if (LoadDataFilePath.ShowDialog() == DialogResult.OK)
            {
                tboxDataPath.Text = LoadDataFilePath.FileName.ToString();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //string[] content = tboxDataPath.Text.Split('\\');
            //string fileName = content[content.Length-1];
            if (tboxDataPath.Text.Trim().Equals(""))
            {
                MessageBox.Show("Data is empty!","Warning");
            }
            else
            {
                anaForm = new AnalysisForm(tboxDataPath.Text);
                this.Hide();
                anaForm.Show();
            }
        }

        private void LoadingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}

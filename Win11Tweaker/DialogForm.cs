using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinBlur;

namespace Win11Tweaker
{
    public partial class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            UI.SetBlurStyle(cntrl: this, blurType: UI.BlurType.Mica, designMode: UI.Mode.DarkMode);
            desc.Text = Properties.Settings.Default.dialogdesc;
            positiveBtn.Text = Properties.Settings.Default.dialogPos;
        }

        private void negativeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void positiveBtn_Click(object sender, EventArgs e)
        {
          
                switch (Properties.Settings.Default.val)
                {
                case 0:
                    Process[] explorerProcesses = Process.GetProcessesByName("explorer");
                    foreach (Process process in explorerProcesses)
                    {
                        process.Kill();
                    }
                    break;
                case 1:
                    Process.Start("shutdown", "-l");
                    break;
            }
               

             
                this.Close();
            
        }
    }
}

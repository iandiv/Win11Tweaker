using System;
using System.Management.Automation;
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
            using (PowerShell ps = PowerShell.Create())
            {
                switch (Properties.Settings.Default.val)
                {
                    case 0:
                        ps.AddScript(@"
Stop-Process -name explorer

                            ");
                        break;
                    case 1:
                        ps.AddScript(@"

Shutdown -l
                            ");
                        break;
                }
               

             
                var output = ps.Invoke();
                this.Close();
            }
        }
    }
}

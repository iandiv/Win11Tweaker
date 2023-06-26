using Microsoft.Win32;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Win11Tweaker.Properties;
using WinBlur;

using Label = System.Windows.Forms.Label;

namespace Win11Tweaker
{
    public partial class Form1 : Form
    {
        private DialogForm dialog;
        private bool appLoaded = false;

        public Form1()
        {

            InitializeComponent();
            dialog = new DialogForm();

            getPref(Settings.Default.contextMenuChecked, contextMenuSwitch);
            getPref(Settings.Default.webSearchChecked, webSearchSwitch);
            getPref(Settings.Default.lockScreennChecked, lockScreenSwitch);
            getPref(Settings.Default.compactViewChecked, compactViewSwitch);
            getPref(Settings.Default.previewPaneChecked, previewPaneSwitch);
            getPref(Settings.Default.printScrChecked, printScrSwitch);

            Console.WriteLine(appLoaded);


        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            Label label = (Label)sender;


            SolidBrush drawBrush = new SolidBrush(SystemColors.ControlLight);
            StringFormat sf = new StringFormat
            {
                //Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center

            };

            // Set custom font and size
            Font customFont = new System.Drawing.Font("Segoe UI Variable Display Semibold", 10.19F, FontStyle.Bold);
            RectangleF drawRectangle = e.ClipRectangle;
            drawRectangle.Offset(1, 0);

            // Enable double-buffering for the control
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(label, true, null);
            e.Graphics.DrawString(label.Text, customFont, drawBrush, drawRectangle, sf);
            label.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);


            drawBrush.Dispose();
            sf.Dispose();
            customFont.Dispose();


        }
        private void setPreview(Point location, Size size, Bitmap image, string Title, string Desc)
        {
            preview.Image = image;
            preview.Location = location;
            preview.Size = size;
            previewTitle.Text = Title;
            previewDesc.Text = Desc;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UI.SetBlurStyle(cntrl: this, blurType: UI.BlurType.Mica, designMode: UI.Mode.DarkMode);
            UI.SetBlurStyle(cntrl: panel1, blurType: UI.BlurType.Mica, designMode: UI.Mode.DarkMode);
            appLoaded = true;
            Console.WriteLine(appLoaded);
            UI.SetBlurStyle(cntrl: panel2, blurType: UI.BlurType.Mica, designMode: UI.Mode.DarkMode);

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            SplashPane.Visible = false;

            // Stop the timer
            timer1.Stop();
        }


        private void setPref(String propertyName, bool updatedValue)
        {

            // Set the updated value for the specified setting name
            typeof(Settings).GetProperty(propertyName).SetValue(Settings.Default, updatedValue);

            // Save the settings
            Settings.Default.Save();



        }

        private void getPref(bool settings, CheckBox component)
        {
            if (settings)
            {
                component.Checked = true;
            }
            else
            {
                component.Checked = false;
            }
        }
        private void contextMenuSwitch_CheckedChanged(object sender, EventArgs e)
        {

            if (contextMenuSwitch.Checked)
            {
                setPref(nameof(Settings.Default.contextMenuChecked), true);
                runReg(nameof(Settings.Default.contextMenuChecked), true);

            }
            else
            {

                setPref(nameof(Settings.Default.contextMenuChecked), false);
                runReg(nameof(Settings.Default.contextMenuChecked), false);

            }


        }

        private void webSearchSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (webSearchSwitch.Checked)
            {
                setPref(nameof(Settings.Default.webSearchChecked), true);
                runReg(nameof(Settings.Default.webSearchChecked), true);

            }
            else
            {
                setPref(nameof(Settings.Default.webSearchChecked), false);
                runReg(nameof(Settings.Default.webSearchChecked), false);

            }

        }

        private void lockScreenSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (lockScreenSwitch.Checked)
            {
                setPref(nameof(Settings.Default.lockScreennChecked), true);
                runReg(nameof(Settings.Default.lockScreennChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.lockScreennChecked), false);
                runReg(nameof(Settings.Default.lockScreennChecked), false);
            }

        }

        private void compactViewSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (compactViewSwitch.Checked)
            {
                setPref(nameof(Settings.Default.compactViewChecked), true);
                runReg(nameof(Settings.Default.compactViewChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.compactViewChecked), false);
                runReg(nameof(Settings.Default.compactViewChecked), false);
            }

        }

        private void previewPaneSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (previewPaneSwitch.Checked)
            {
                setPref(nameof(Settings.Default.previewPaneChecked), true);
                runReg(nameof(Settings.Default.previewPaneChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.previewPaneChecked), false);
                runReg(nameof(Settings.Default.previewPaneChecked), false);

            }

        }

        private void printScrSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (printScrSwitch.Checked)
            {
                setPref(nameof(Settings.Default.printScrChecked), true); runReg(nameof(Settings.Default.previewPaneChecked), false);
                runReg(nameof(Settings.Default.printScrChecked), true);

            }
            else
            {
                setPref(nameof(Settings.Default.printScrChecked), false);
                runReg(nameof(Settings.Default.printScrChecked), false);

            }

        }



        // Method to set a registry value
        private static void SetHKLMRegistryValue(string keyPath, string valueName, object value)
        {


            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
                else
                {
                    // Key not found, create it
                    using (RegistryKey newKey = Registry.LocalMachine.CreateSubKey(keyPath))
                    {
                        if (newKey != null)
                        {
                            newKey.SetValue(valueName, value);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Failed to create key - " + keyPath);
                        }
                    }
                }
            }
        }
        // Method to set a registry value
        private static void SetROOTRegistryValue(string keyPath, string valueName, object value)
        {


            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
                else
                {
                    // Key not found, create it
                    using (RegistryKey newKey = Registry.ClassesRoot.CreateSubKey(keyPath))
                    {
                        if (newKey != null)
                        {
                            newKey.SetValue(valueName, value);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Failed to create key - " + keyPath);
                        }
                    }
                }
            }
        }
        private static void SetHKCURegistryValue(string keyPath, string valueName, object value)
        {


            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
            {
                if (key != null)
                {
                    key.SetValue(valueName, value);
                }
                else
                {
                    // Key not found, create it
                    using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey(keyPath))
                    {
                        if (newKey != null)
                        {
                            newKey.SetValue(valueName, value);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Failed to create key - " + keyPath);
                        }
                    }
                }
            }
        }

        // Method to delete a registry key
        private static void DeleteHKCURegistryKey(string keyPath)
        {
            Registry.CurrentUser.DeleteSubKeyTree(keyPath, false);
        }
        private static void DeleteHKLMRegistryKey(string keyPath)
        {
            Registry.LocalMachine.DeleteSubKeyTree(keyPath, false);
        }
        private static void DeleteROOTRegistryKey(string keyPath)
        {
            Registry.ClassesRoot.DeleteSubKeyTree(keyPath, false);
        }

        private void runReg(string key, bool isChecked)
        {
            if (appLoaded)
            {
                string keyPath;
                switch (key)
                {
                    case nameof(Settings.Default.contextMenuChecked):
                        keyPath = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";
                        if (isChecked)
                        {
                            SetHKCURegistryValue(keyPath, "", "");
                        }
                        else
                        {
                            DeleteHKCURegistryKey(keyPath);
                        }
                        onRestartExplorer();
                        break;
                    case nameof(Settings.Default.webSearchChecked):
                        keyPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
                        if (isChecked)
                        {
                            SetHKCURegistryValue(keyPath, "DisableSearchBoxSuggestions", 1);
                        }
                        else
                        {
                            Registry.CurrentUser.OpenSubKey(keyPath, true)?.DeleteValue("DisableSearchBoxSuggestions", false);
                        }
                        break;
                    case nameof(Settings.Default.lockScreennChecked):
                        keyPath = @"SOFTWARE\Policies\Microsoft\Windows\Personalization";
                        if (isChecked)
                        {
                            SetHKLMRegistryValue(keyPath, "NoLockScreen", 1);
                        }
                        else
                        {
                            SetHKLMRegistryValue(keyPath, "NoLockScreen", 0);
                        }
                        break;
                    case nameof(Settings.Default.compactViewChecked):
                        keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                        if (isChecked)
                        {
                            SetHKCURegistryValue(keyPath, "UseCompactMode", 1);
                        }
                        else
                        {
                            SetHKCURegistryValue(keyPath, "UseCompactMode", 0);
                        }
                        break;
                    case nameof(Settings.Default.previewPaneChecked):
                        keyPath = @"AllFilesystemObjects\shell\Windows.previewpane";
                        if (isChecked)
                        {
                            SetROOTRegistryValue(keyPath, "CanonicalName", "{1380d028-a77f-4c12-96c7-ea276333f982}");
                            SetROOTRegistryValue(keyPath, "Description", "@shell32.dll,-31416");
                            SetROOTRegistryValue(keyPath, "Icon", "shell32.dll,-16814");
                            SetROOTRegistryValue(keyPath, "MUIVerb", "@shell32.dll,-31415");
                            SetROOTRegistryValue(keyPath, "PaneID", "{43abf98b-89b8-472d-b9ce-e69b8229f019}");
                            SetROOTRegistryValue(keyPath, "PaneVisibleProperty", "PreviewPaneSizer_Visible");
                            SetROOTRegistryValue(keyPath, "PolicyID", "{17067f8d-981b-42c5-98f8-5bc016d4b073}");

                            keyPath = @"Directory\Background\shell\Windows.previewpane";
                            SetROOTRegistryValue(keyPath, "CanonicalName", "{1380d028-a77f-4c12-96c7-ea276333f982}");
                            SetROOTRegistryValue(keyPath, "Description", "@shell32.dll,-31416");
                            SetROOTRegistryValue(keyPath, "Icon", "shell32.dll,-16814");
                            SetROOTRegistryValue(keyPath, "MUIVerb", "@shell32.dll,-31415");
                            SetROOTRegistryValue(keyPath, "PaneID", "{43abf98b-89b8-472d-b9ce-e69b8229f019}");
                            SetROOTRegistryValue(keyPath, "PaneVisibleProperty", "PreviewPaneSizer_Visible");
                            SetROOTRegistryValue(keyPath, "PolicyID", "{17067f8d-981b-42c5-98f8-5bc016d4b073}");

                            keyPath = @"Drive\shell\Windows.previewpane";
                            SetROOTRegistryValue(keyPath, "CanonicalName", "{1380d028-a77f-4c12-96c7-ea276333f982}");
                            SetROOTRegistryValue(keyPath, "Description", "@shell32.dll,-31416");
                            SetROOTRegistryValue(keyPath, "Icon", "shell32.dll,-16814");
                            SetROOTRegistryValue(keyPath, "MUIVerb", "@shell32.dll,-31415");
                            SetROOTRegistryValue(keyPath, "PaneID", "{43abf98b-89b8-472d-b9ce-e69b8229f019}");
                            SetROOTRegistryValue(keyPath, "PaneVisibleProperty", "PreviewPaneSizer_Visible");
                            SetROOTRegistryValue(keyPath, "PolicyID", "{17067f8d-981b-42c5-98f8-5bc016d4b073}");

                            keyPath = @"LibraryFolder\background\shell\Windows.previewpane";
                            SetROOTRegistryValue(keyPath, "CanonicalName", "{1380d028-a77f-4c12-96c7-ea276333f982}");
                            SetROOTRegistryValue(keyPath, "Description", "@shell32.dll,-31416");
                            SetROOTRegistryValue(keyPath, "Icon", "shell32.dll,-16814");
                            SetROOTRegistryValue(keyPath, "MUIVerb", "@shell32.dll,-31415");
                            SetROOTRegistryValue(keyPath, "PaneID", "{43abf98b-89b8-472d-b9ce-e69b8229f019}");
                            SetROOTRegistryValue(keyPath, "PaneVisibleProperty", "PreviewPaneSizer_Visible");
                            SetROOTRegistryValue(keyPath, "PolicyID", "{17067f8d-981b-42c5-98f8-5bc016d4b073}");
                        }
                        else
                        {
                            keyPath = @"AllFilesystemObjects\shell\Windows.previewpane";
                            DeleteROOTRegistryKey(keyPath);

                            keyPath = @"Directory\Background\shell\Windows.previewpane";
                            DeleteROOTRegistryKey(keyPath);

                            keyPath = @"Drive\shell\Windows.previewpane";
                            DeleteROOTRegistryKey(keyPath);

                            keyPath = @"LibraryFolder\background\shell\Windows.previewpane";
                            DeleteROOTRegistryKey(keyPath);
                        }
                        break;

                    case nameof(Settings.Default.printScrChecked):
                        keyPath = @"AppEvents\Schemes\Apps\.Default\SnapShot";
                        if (isChecked)
                        {
                            SetHKCURegistryValue(keyPath, "(Default)", "");

                            var currentFolderPath = $"{keyPath}\\.Current";
                            SetHKCURegistryValue(currentFolderPath, "(Default)", @"C:\Windows\media\Windows Notify System Generic.wav");

                            var defaultFolderPath = $"{keyPath}\\.Default";
                            SetHKCURegistryValue(defaultFolderPath, "(Default)", @"C:\Windows\media\Windows Notify System Generic.wav");
                        }
                        else
                        {
                            DeleteHKCURegistryKey(keyPath);
                        }
                        break;

                }
               

            }
        }



        private void previewDesc_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void negativeBtn_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(3, 14), new System.Drawing.Size(146, 61), Resources.win11tweaker_icon, "IanDiv", "Powerful Tool for Personalizing and Enhancing Windows 11");

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            appName.ForeColor = Color.DimGray;
        }

        private void appName_MouseUp(object sender, MouseEventArgs e)
        {
            appName.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void appName_MouseHover(object sender, EventArgs e)
        {
            appName.ForeColor = Color.Gray;
        }

        private void appName_MouseLeave(object sender, EventArgs e)
        {
            appName.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void appName_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(3, 14), new System.Drawing.Size(146, 61), Resources.win11splash, "IanDiv", "Powerful Tool for Personalizing and Enhancing Windows 11");

        }

        private void lockScreenPanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3),
                new System.Drawing.Size(166, 95),
                Resources.lockScreenImage,
                "Lock Screen",
                "Disable the Windows 11 lock screen, directly access the login screen");


        }

        private void contextMenuPanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3), new System.Drawing.Size(166, 95), Resources.contextMenuImage, "Classic Context Menu", "Enable the classic context menu to bring back the familiar right-click options");


        }

        private void negativeBtn_Click_1(object sender, EventArgs e)
        {
            label2.Enabled = false;
        }
        private void setDialogView(string desc, string btntext, int val)
        {
            Properties.Settings.Default.dialogdesc = desc;
            Properties.Settings.Default.dialogPos = btntext;
            Properties.Settings.Default.val = val;
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            label2.Enabled = true;
        }
        private void onSignOut()
        {
            setDialogView("Sign out for the changes to take the effect", "Sign Out", 1);
            dialog.ShowDialog();
        }
        private void onRestartExplorer()
        {
            setDialogView("Restart Explorer for the changes to take the effect", "Restart Explorer", 0);
            dialog.ShowDialog();
        }

        private void webSearchPanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3), new System.Drawing.Size(166, 95), Resources.webSearchImage, "Web Search", "Disable web search results in the Start menu for a more focused search experience.");

        }

        private void compactViewPanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3), new System.Drawing.Size(166, 95), Resources.compactViewImage, "Compact View", "Enable a more streamlined and efficient view in the Windows 11 File Explorer.");

        }

        private void detailsPanePanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3), new System.Drawing.Size(166, 95), Resources.detialPaneImage, "Details Pane", "Add a details pane to the context menu for quick access to file details");

        }

        private void printSCRPanel_Click(object sender, EventArgs e)
        {
            setPreview(new System.Drawing.Point(-5, -3), new System.Drawing.Size(166, 95), Resources.printSCRImage, "Print Screen Sound", " Enable a sound notification when pressing the Print Screen key");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}

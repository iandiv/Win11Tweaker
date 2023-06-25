using System;
using System.Drawing;
using System.Management.Automation;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using Win11Tweaker.Properties;
using WinBlur;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Label = System.Windows.Forms.Label;

namespace Win11Tweaker
{
    public partial class Form1 : Form
    {
        private DialogForm dialog;
        private bool appLoaded = false;
        private VScrollBar vScrollBar1;
        private string temp = "";
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
        private void setPreview(Point location,Size size,Bitmap image,string Title,string Desc)
        {
            preview.Image = image;
            preview.Location = location;
            preview.Size = size;
            previewTitle.Text = Title;
            previewDesc.Text =Desc;

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
                RunScript(nameof(Settings.Default.contextMenuChecked), true);

            }
            else
            {

                setPref(nameof(Settings.Default.contextMenuChecked), false);
                RunScript(nameof(Settings.Default.contextMenuChecked), false);

            }

           
        }

        private void webSearchSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (webSearchSwitch.Checked)
            {
                setPref(nameof(Settings.Default.webSearchChecked), true);
                RunScript(nameof(Settings.Default.webSearchChecked), true);

            }
            else
            {
                setPref(nameof(Settings.Default.webSearchChecked), false);
                RunScript(nameof(Settings.Default.webSearchChecked), false);

            }

        }

        private void lockScreenSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (lockScreenSwitch.Checked)
            {
                setPref(nameof(Settings.Default.lockScreennChecked), true);
                RunScript(nameof(Settings.Default.lockScreennChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.lockScreennChecked), false);
                RunScript(nameof(Settings.Default.lockScreennChecked), false);
            }

        }

        private void compactViewSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (compactViewSwitch.Checked)
            {
                setPref(nameof(Settings.Default.compactViewChecked), true);
                RunScript(nameof(Settings.Default.compactViewChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.compactViewChecked), false);
                RunScript(nameof(Settings.Default.compactViewChecked), false);
            }

        }

        private void previewPaneSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (previewPaneSwitch.Checked)
            {
                setPref(nameof(Settings.Default.previewPaneChecked), true);
                RunScript(nameof(Settings.Default.previewPaneChecked), true);
            }
            else
            {
                setPref(nameof(Settings.Default.previewPaneChecked), false);
                RunScript(nameof(Settings.Default.previewPaneChecked), false);

            }

        }

        private void printScrSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (printScrSwitch.Checked)
            {
                setPref(nameof(Settings.Default.printScrChecked), true); RunScript(nameof(Settings.Default.previewPaneChecked), false);
                RunScript(nameof(Settings.Default.printScrChecked), true);

            }
            else
            {
                setPref(nameof(Settings.Default.printScrChecked), false);
                RunScript(nameof(Settings.Default.printScrChecked), false);

            }

        }
        private void RunScript(string key, bool isChecked)
        {
            if (appLoaded)
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    switch (key)
                    {
                        case nameof(Settings.Default.contextMenuChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
# Enable Classic Context Menu
$regPath = ""HKCU:\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32""

# Check if the registry key exists
if (-not (Test-Path $regPath)) {
    # Create the registry key if it doesn't exist
    New-Item -Path $regPath -Force | Out-Null
}

# Set the default value
Set-ItemProperty -Path $regPath -Name ""(Default)"" -Value """"

#RESTART EXPLORER!!

                            ");

                            }
                            else
                            {
                                ps.AddScript(@"
# Disable Classic Context Menu
$regPath = ""REGISTRY::HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}""
Remove-Item -Path $regPath -Recurse -Force -ErrorAction SilentlyContinue -ErrorVariable RemoveError

if ($RemoveError) {
    Write-Host ""Error removing registry path: $regPath""
    Write-Host $RemoveError
}
else {
    Write-Host ""Registry path removed successfully: $regPath""
}


# RESTART EXPLORER!!

                            ");

                            }
                            onRestartExplorer();
                            break;
                        case nameof(Settings.Default.webSearchChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
# Disable Web Search
Set-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\Explorer"" -Name ""DisableSearchBoxSuggestions"" -Value 1

#SIGNOUT

");
                            }
                            else
                            {
                                ps.AddScript(@"
# Enable Web Search
Remove-ItemProperty -Path ""HKCU:\SOFTWARE\Policies\Microsoft\Windows\Explorer"" -Name ""DisableSearchBoxSuggestions"" -ErrorAction SilentlyContinue
#SIGNOUT

");
                            }
                            onSignOut();
                            break;
                        case nameof(Settings.Default.lockScreennChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
#Disable Lock Screen
$RegistryPath = ""HKLM:\SOFTWARE\Policies\Microsoft\Windows""
$PersonalizationKey = ""Personalization""
$NoLockScreenValueName = ""NoLockScreen""
$NoLockScreenValueData = 1

# Create or open the Personalization key
New-Item -Path $RegistryPath -Name $PersonalizationKey -Force | Out-Null

# Set the NoLockScreen value under the Personalization key
Set-ItemProperty -Path ""$RegistryPath\$PersonalizationKey"" -Name $NoLockScreenValueName -Value $NoLockScreenValueData -Type DWORD -Force

");
                            }
                            else
                            {
                                ps.AddScript(@"
#Enable Lock Screen
$RegistryPath = ""HKLM:\SOFTWARE\Policies\Microsoft\Windows""
$PersonalizationKey = ""Personalization""
$NoLockScreenValueName = ""NoLockScreen""
$NoLockScreenValueData = 0

# Create or open the Personalization key
New-Item -Path $RegistryPath -Name $PersonalizationKey -Force | Out-Null

# Set the NoLockScreen value under the Personalization key
Set-ItemProperty -Path ""$RegistryPath\$PersonalizationKey"" -Name $NoLockScreenValueName -Value $NoLockScreenValueData -Type DWORD -Force

");
                            }
                            break;
                        case nameof(Settings.Default.compactViewChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
#Enable Compact View
$RegistryPath = ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced""
$UseCompactModeValueName = ""UseCompactMode""
$UseCompactModeValueData = 1

# Check if the UseCompactMode value exists
if (!(Test-Path ""$RegistryPath\$UseCompactModeValueName"")) {
    # Create the UseCompactMode value if it doesn't exist
    New-ItemProperty -Path $RegistryPath -Name $UseCompactModeValueName -PropertyType DWORD -Value $UseCompactModeValueData -Force | Out-Null
    Write-Host ""Value '$UseCompactModeValueName' created with value '$UseCompactModeValueData'.""
} else {
    # Modify the existing UseCompactMode value
    Set-ItemProperty -Path $RegistryPath -Name $UseCompactModeValueName -Value $UseCompactModeValueData -Force
    Write-Host ""Value '$UseCompactModeValueName' modified to '$UseCompactModeValueData'.""
}
                            ");
                            }
                            else
                            {
                                ps.AddScript(@"
#Disable Compact View
$RegistryPath = ""HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced""
$UseCompactModeValueName = ""UseCompactMode""
$UseCompactModeValueData = 0

# Check if the UseCompactMode value exists
if (!(Test-Path ""$RegistryPath\$UseCompactModeValueName"")) {
    # Create the UseCompactMode value if it doesn't exist
    New-ItemProperty -Path $RegistryPath -Name $UseCompactModeValueName -PropertyType DWORD -Value $UseCompactModeValueData -Force | Out-Null
    Write-Host ""Value '$UseCompactModeValueName' created with value '$UseCompactModeValueData'.""
} else {
    # Modify the existing UseCompactMode value
    Set-ItemProperty -Path $RegistryPath -Name $UseCompactModeValueName -Value $UseCompactModeValueData -Force
    Write-Host ""Value '$UseCompactModeValueName' modified to '$UseCompactModeValueData'.""
}

                            ");
                            }
                            break;
                        case nameof(Settings.Default.previewPaneChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
# Enable Preview Pane
$registryPath = ""REGISTRY::HKEY_CLASSES_ROOT\AllFilesystemObjects\shell\Windows.previewpane""
New-Item -Path $registryPath -Force | Out-Null
Set-ItemProperty -Path $registryPath -Name ""CanonicalName"" -Value ""{1380d028-a77f-4c12-96c7-ea276333f982}""
Set-ItemProperty -Path $registryPath -Name ""Description"" -Value ""@shell32.dll,-31416""
Set-ItemProperty -Path $registryPath -Name ""Icon"" -Value ""shell32.dll,-16814""
Set-ItemProperty -Path $registryPath -Name ""MUIVerb"" -Value ""@shell32.dll,-31415""
Set-ItemProperty -Path $registryPath -Name ""PaneID"" -Value ""{43abf98b-89b8-472d-b9ce-e69b8229f019}""
Set-ItemProperty -Path $registryPath -Name ""PaneVisibleProperty"" -Value ""PreviewPaneSizer_Visible""
Set-ItemProperty -Path $registryPath -Name ""PolicyID"" -Value ""{17067f8d-981b-42c5-98f8-5bc016d4b073}""

$registryPath = ""REGISTRY::HKEY_CLASSES_ROOT\Directory\Background\shell\Windows.previewpane""
New-Item -Path $registryPath -Force | Out-Null
Set-ItemProperty -Path $registryPath -Name ""CanonicalName"" -Value ""{1380d028-a77f-4c12-96c7-ea276333f982}""
Set-ItemProperty -Path $registryPath -Name ""Description"" -Value ""@shell32.dll,-31416""
Set-ItemProperty -Path $registryPath -Name ""Icon"" -Value ""shell32.dll,-16814""
Set-ItemProperty -Path $registryPath -Name ""MUIVerb"" -Value ""@shell32.dll,-31415""
Set-ItemProperty -Path $registryPath -Name ""PaneID"" -Value ""{43abf98b-89b8-472d-b9ce-e69b8229f019}""
Set-ItemProperty -Path $registryPath -Name ""PaneVisibleProperty"" -Value ""PreviewPaneSizer_Visible""
Set-ItemProperty -Path $registryPath -Name ""PolicyID"" -Value ""{17067f8d-981b-42c5-98f8-5bc016d4b073}""

$registryPath = ""REGISTRY::HKEY_CLASSES_ROOT\Drive\shell\Windows.previewpane""
New-Item -Path $registryPath -Force | Out-Null
Set-ItemProperty -Path $registryPath -Name ""CanonicalName"" -Value ""{1380d028-a77f-4c12-96c7-ea276333f982}""
Set-ItemProperty -Path $registryPath -Name ""Description"" -Value ""@shell32.dll,-31416""
Set-ItemProperty -Path $registryPath -Name ""Icon"" -Value ""shell32.dll,-16814""
Set-ItemProperty -Path $registryPath -Name ""MUIVerb"" -Value ""@shell32.dll,-31415""
Set-ItemProperty -Path $registryPath -Name ""PaneID"" -Value ""{43abf98b-89b8-472d-b9ce-e69b8229f019}""
Set-ItemProperty -Path $registryPath -Name ""PaneVisibleProperty"" -Value ""PreviewPaneSizer_Visible""
Set-ItemProperty -Path $registryPath -Name ""PolicyID"" -Value ""{17067f8d-981b-42c5-98f8-5bc016d4b073}""

$registryPath = ""REGISTRY::HKEY_CLASSES_ROOT\LibraryFolder\background\shell\Windows.previewpane""
New-Item -Path $registryPath -Force | Out-Null
Set-ItemProperty -Path $registryPath -Name ""CanonicalName"" -Value ""{1380d028-a77f-4c12-96c7-ea276333f982}""
Set-ItemProperty -Path $registryPath -Name ""Description"" -Value ""@shell32.dll,-31416""
Set-ItemProperty -Path $registryPath -Name ""Icon"" -Value ""shell32.dll,-16814""
Set-ItemProperty -Path $registryPath -Name ""MUIVerb"" -Value ""@shell32.dll,-31415""
Set-ItemProperty -Path $registryPath -Name ""PaneID"" -Value ""{43abf98b-89b8-472d-b9ce-e69b8229f019}""
Set-ItemProperty -Path $registryPath -Name ""PaneVisibleProperty"" -Value ""PreviewPaneSizer_Visible""
Set-ItemProperty -Path $registryPath -Name ""PolicyID"" -Value ""{17067f8d-981b-42c5-98f8-5bc016d4b073}""

                            ");
                            }
                            else
                            {
                                ps.AddScript(@"
# Disable Preview Pane
Remove-Item -Path ""REGISTRY::HKEY_CLASSES_ROOT\AllFilesystemObjects\shell\Windows.previewpane"" -Force -Confirm:$false
Remove-Item -Path ""REGISTRY::HKEY_CLASSES_ROOT\Directory\Background\shell\Windows.previewpane"" -Force -Confirm:$false
Remove-Item -Path ""REGISTRY::HKEY_CLASSES_ROOT\Drive\shell\Windows.previewpane"" -Force -Confirm:$false
Remove-Item -Path ""REGISTRY::HKEY_CLASSES_ROOT\LibraryFolder\background\shell\Windows.previewpane"" -Force -Confirm:$false

                            ");
                            }
                            break;
                        case nameof(Settings.Default.printScrChecked):
                            if (isChecked)
                            {
                                ps.AddScript(@"
# Create SnapShot registry key and set its (Default) value
$registryPath = ""HKCU:\AppEvents\Schemes\Apps\.Default\SnapShot""
if (-not (Test-Path $registryPath)) {
    New-Item -Path $registryPath -Force | Out-Null
}
Set-ItemProperty -Path $registryPath -Name ""(Default)"" -Value """"

# Create .Current folder and set its (Default) key value
$currentFolderPath = ""HKCU:\AppEvents\Schemes\Apps\.Default\SnapShot\.Current""
if (-not (Test-Path $currentFolderPath)) {
    New-Item -Path $currentFolderPath -Force | Out-Null
}
Set-ItemProperty -Path $currentFolderPath -Name ""(Default)"" -Value ""C:\Windows\media\Windows Notify System Generic.wav""

# Create .Default folder and set its (Default) key value
$defaultFolderPath = ""HKCU:\AppEvents\Schemes\Apps\.Default\SnapShot\.Default""
if (-not (Test-Path $defaultFolderPath)) {
    New-Item -Path $defaultFolderPath -Force | Out-Null
}
Set-ItemProperty -Path $defaultFolderPath -Name ""(Default)"" -Value ""C:\Windows\media\Windows Notify System Generic.wav""

");
                            }
                            else
                            {
                                ps.AddScript(@"
# Delete SnapShot folder without prompt
$registryPath = ""HKCU:\AppEvents\Schemes\Apps\.Default\SnapShot""
if (Test-Path $registryPath) {
    Remove-Item -Path $registryPath -Recurse -Force -Confirm:$false
}

");
                            }
                            break;
                    }


                    var output = ps.Invoke();
                    if (ps.HadErrors)
                    {
                        Console.WriteLine("Script execution encountered errors:");
                        foreach (var error in ps.Streams.Error)
                        {
                            Console.WriteLine(error.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Script executed successfully.");
                        // Handle successful execution here
                    }
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
            appName.ForeColor = Color.FromArgb(255,255,255);
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
        private void setDialogView(string desc, string btntext,int val)
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
            setDialogView("Sign out for the changes to take the effect", "Sign Out",1);
            dialog.ShowDialog();
        }
        private void onRestartExplorer()
        {
            setDialogView("Restart Explorer for the changes to take the effect", "Restart Explorer",0);
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

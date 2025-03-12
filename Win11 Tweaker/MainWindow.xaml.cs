using System;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using Win11_Tweaker.Helpers;


namespace Win11_Tweaker
{

    public sealed partial class MainWindow : Window
    {

        private WindowHelper _windowHelper;
        private Process caseConverterProcess;
        private Process cleanDesktopProcess;

        public MainWindow()
        {
            this.InitializeComponent();
            _windowHelper = new WindowHelper(this);

            _windowHelper.MicaEnabled = true;
            _windowHelper.WindowSize = (570, 670);
            _windowHelper.MinimumSize = (570, 670);

            ToggleStateHelper.LoadToggleStates(this.Content, runReg);
            LoadHotkey();
            if (case_converter.IsOn) CaseConverterHelper.RunCaseConverter();

        }


        private async void LoadHotkey()
        {
            string savedHotkey = await CaseConverterHelper.ReadHotkeyAsync();
            hotkeyText.Text = string.IsNullOrEmpty(savedHotkey) ? "No hotkey set" : savedHotkey;
        }
        private async void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("https://github.com/iandiv"); 
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        private async void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("https://ko-fi.com/iandiv"); // Replace with your GitHub repo URL
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void OpenHotkeyDialog(object sender, RoutedEventArgs e)
        {
            var dialog = new CaseConverterHelper(this.Content.XamlRoot);
            await dialog.ShowAsync();
            LoadHotkey();
        }
        private async void runReg(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggle = sender as ToggleSwitch;
            if (toggle != null)
            {
                string keyPath;

                switch (toggle.Name)
                {
                    //DESKTOP
                    case "case_converter":
                        if (toggle.IsOn)
                        {


                            caseConverterProcess = CaseConverterHelper.RunCaseConverter();
                        }
                        else
                        {
                            CaseConverterHelper.RemoveFromStartup();
                            if (caseConverterProcess != null && !caseConverterProcess.HasExited)
                            {
                                caseConverterProcess.Kill();
                                caseConverterProcess.Dispose();
                                caseConverterProcess = null;
                            }
                            else
                            {
                                var runningProcesses = Process.GetProcessesByName(CaseConverterHelper.appName);
                                foreach (var proc in runningProcesses)
                                {
                                    proc.Kill();
                                }
                            }
                        }
                        break;
                    case "clean_desktop":
                        if (toggle.IsOn)
                        {


                            cleanDesktopProcess = CleanDesktopHelper.RunCleanDesktop();
                        }
                        else
                        {
                            CleanDesktopHelper.RemoveFromStartup();
                            if (cleanDesktopProcess != null && !cleanDesktopProcess.HasExited)
                            {
                                cleanDesktopProcess.Kill();
                                cleanDesktopProcess.Dispose();
                                cleanDesktopProcess = null;
                            }
                            else
                            {
                                var runningProcesses = Process.GetProcessesByName(CleanDesktopHelper.appName);
                                foreach (var proc in runningProcesses)
                                {
                                    proc.Kill();
                                }
                            }
                        }
                        break;
                    //FILE EXPLORER
                    case "classic_context_menu":
                        keyPath = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

                        if (toggle.IsOn)
                        {
                            RegistryHelper.SetRegistryValue(
                                Registry.CurrentUser,
                                keyPath,
                                "",  // Default value (empty string)
                                "",
                                RegistryValueKind.String
                            );
                        }
                        else
                        {
                            RegistryHelper.DeleteRegistryKey(Registry.CurrentUser, keyPath);
                        }


                        await RegistryHelper.ShowActionDialog(RegistryHelper.ActionTypes.RestartExplorer, toggle.XamlRoot);



                        break;
                    case "compact_view":
                        RegistryHelper.SetRegistryValue(
                             Registry.CurrentUser,
                             @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
                             "UseCompactMode",
                             toggle.IsOn ? 1 : 0,
                             RegistryValueKind.DWord
                         );
                        break;

                    case "details_pane":


                        if (toggle.IsOn)
                        {
                            string[] keyPaths =
                            {
                                @"AllFilesystemObjects\shell\Windows.previewpane",
                                @"Directory\Background\shell\Windows.previewpane",
                                @"Drive\shell\Windows.previewpane",
                                @"LibraryFolder\background\shell\Windows.previewpane"
                            };

                            foreach (string path in keyPaths)
                            {
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "CanonicalName", "{1380d028-a77f-4c12-96c7-ea276333f982}", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "Description", "@shell32.dll,-31416", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "Icon", "shell32.dll,-16814", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "MUIVerb", "@shell32.dll,-31415", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "PaneID", "{43abf98b-89b8-472d-b9ce-e69b8229f019}", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "PaneVisibleProperty", "PreviewPaneSizer_Visible", RegistryValueKind.String);
                                RegistryHelper.SetRegistryValue(Registry.ClassesRoot, path, "PolicyID", "{17067f8d-981b-42c5-98f8-5bc016d4b073}", RegistryValueKind.String);
                            }
                        }
                        else
                        {
                            RegistryHelper.DeleteRegistryKey(Registry.ClassesRoot, @"AllFilesystemObjects\shell\Windows.previewpane");
                            RegistryHelper.DeleteRegistryKey(Registry.ClassesRoot, @"Directory\Background\shell\Windows.previewpane");
                            RegistryHelper.DeleteRegistryKey(Registry.ClassesRoot, @"Drive\shell\Windows.previewpane");
                            RegistryHelper.DeleteRegistryKey(Registry.ClassesRoot, @"LibraryFolder\background\shell\Windows.previewpane");
                        }

                        break;
                    //START MENU
                    case "web_search":
                        keyPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";

                        if (toggle.IsOn)
                        {
                            RegistryHelper.SetRegistryValue(
                                Registry.CurrentUser,
                                keyPath,
                                "DisableSearchBoxSuggestions",
                                1,
                                RegistryValueKind.DWord
                            );
                        }
                        else
                        {
                            RegistryHelper.DeleteRegistryValue(
                                Registry.CurrentUser,
                                keyPath,
                                "DisableSearchBoxSuggestions"
                            );
                        }


                        await RegistryHelper.ShowActionDialog(RegistryHelper.ActionTypes.SignOut, toggle.XamlRoot);




                        break;
                    //LOCK SCREEN
                    case "lock_screen":

                        RegistryHelper.SetRegistryValue(
                            Registry.LocalMachine,
                             @"SOFTWARE\Policies\Microsoft\Windows\Personalization",
                            "NoLockScreen",
                            toggle.IsOn ? 1 : 0,
                            RegistryValueKind.DWord
                        );
                        break;


                    //OTHER
                    case "print_scr":
                        keyPath = @"AppEvents\Schemes\Apps\.Default\SnapShot";

                        if (toggle.IsOn)
                        {
                            RegistryHelper.SetRegistryValue(
                                Registry.CurrentUser,
                                $"{keyPath}\\.Current",
                                null,
                                @"C:\Windows\media\Windows Notify System Generic.wav",
                                RegistryValueKind.String
                            );

                            RegistryHelper.SetRegistryValue(
                                Registry.CurrentUser,
                                $"{keyPath}\\.Default",
                                null,
                                @"C:\Windows\media\Windows Notify System Generic.wav",
                                RegistryValueKind.String
                            );
                        }
                        else
                        {
                            RegistryHelper.DeleteRegistryKey(Registry.CurrentUser, keyPath);
                        }

                        break;
                    case "disable_background_apps":
                        RegistryHelper.SetRegistryValue(
                             Registry.CurrentUser,
                             @"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications",
                             "GlobalUserDisabled",
                             toggle.IsOn ? 1 : 0,
                             RegistryValueKind.DWord
                         );

                        await RegistryHelper.ShowActionDialog(RegistryHelper.ActionTypes.SignOut, toggle.XamlRoot);



                        break;
                    default:
                        Debug.WriteLine("Unknown toggle switch.");
                        break;
                }
                SettingsHelper.SaveToggleState(toggle.Name, toggle.IsOn);


            }
        }


    }
}

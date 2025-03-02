using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.Win32;
using Windows.System;

namespace Win11_Tweaker
{
    public class CaseConverterHelper : ContentDialog
    {
        private TextBox hotkeyTextBox;
        private HashSet<string> pressedKeys = new();
        private bool hasModifier = false;
        public static string appName = "Case Converter";
        private static string configPath = Path.Combine(AppContext.BaseDirectory, appName + ".ini");
        private static string exePath = Path.Combine(AppContext.BaseDirectory, appName + ".exe");
        private static string startupKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";



        private readonly Dictionary<VirtualKey, string> specialCharacterMapping = new()
        {
            { (VirtualKey)186, ";" }, { (VirtualKey)187, "=" }, { (VirtualKey)188, "," }, { (VirtualKey)189, "-" },
            { (VirtualKey)190, "." }, { (VirtualKey)191, "/" }, { (VirtualKey)192, "`" }, { (VirtualKey)219, "[" },
            { (VirtualKey)220, "\\" }, { (VirtualKey)221, "]" }, { (VirtualKey)222, "'" }
        };

        public CaseConverterHelper(XamlRoot xamlRoot)
        {

            // Register the dialog to auto-update theme
            ThemeHelper.RegisterDialog(this);
            this.Title = "Press Any Key";
            this.PrimaryButtonText = "Save";
            this.DefaultButton = ContentDialogButton.Primary;
            this.CloseButtonText = "Cancel";
            hotkeyTextBox = new TextBox
            {
                PlaceholderText = "...",
                FontSize = 24,
                FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                Background = new SolidColorBrush(ColorHelper.FromArgb(0x30, 0x90, 0x90, 0x90)),
                BorderThickness = new Microsoft.UI.Xaml.Thickness(0),
                IsReadOnly = true,
                Padding = new Microsoft.UI.Xaml.Thickness(10),
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                CornerRadius = new CornerRadius(8)
            };

            hotkeyTextBox.Style = Application.Current.Resources["NoUnderlineTextBoxStyle"] as Style;
            hotkeyTextBox.Resources["TextControlBackgroundFocused"] = new SolidColorBrush(ColorHelper.FromArgb(0x30, 0x60, 0x60, 0x60));
            hotkeyTextBox.Resources["TextControlBackgroundPointerOver"] = new SolidColorBrush(ColorHelper.FromArgb(0x30, 0x60, 0x60, 0x60));

            this.Content = hotkeyTextBox;
            this.XamlRoot = xamlRoot;

            hotkeyTextBox.KeyDown += HotkeyTextBox_KeyDown;
            hotkeyTextBox.KeyUp += HotkeyTextBox_KeyUp;

            this.PrimaryButtonClick += async (sender, args) => await SaveHotkeyAsync();
            _ = ReadHotKey();
        }
        private async Task ReadHotKey()
        {
            string savedHotkey = await ReadHotkeyAsync();
            hotkeyTextBox.Text = string.IsNullOrWhiteSpace(savedHotkey) ? "Press a hotkey..." : savedHotkey;
        }
        private void HotkeyTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            e.Handled = true;

            string keyPressed = GetKeyName(e.Key);
            if (string.IsNullOrEmpty(keyPressed)) return;

            if (keyPressed == "Ctrl" || keyPressed == "Shift" || keyPressed == "Alt")
            {
                hasModifier = true;
            }
            else
            {
                if (pressedKeys.Any(k => k != "Ctrl" && k != "Shift" && k != "Alt"))
                {
                    return;
                }
            }

            if (!pressedKeys.Contains(keyPressed))
            {
                pressedKeys.Add(keyPressed);
            }

            hotkeyTextBox.Text = string.Join("+", pressedKeys);
        }
        private void HotkeyTextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            pressedKeys.Clear();
            hasModifier = false;
        }

        private string GetKeyName(VirtualKey key)
        {
            // Handle modifier keys first
            return key switch
            {
                VirtualKey.Control => "Ctrl",
                VirtualKey.LeftControl => "Ctrl",
                VirtualKey.RightControl => "Ctrl",
                VirtualKey.Shift => "Shift",
                VirtualKey.LeftShift => "Shift",
                VirtualKey.RightShift => "Shift",
                VirtualKey.Menu => "Alt",
                VirtualKey.LeftMenu => "Alt",
                VirtualKey.RightMenu => "Alt",
                _ => specialCharacterMapping.ContainsKey(key) ? specialCharacterMapping[key] : key.ToString()
            };
        }

        public static Process? RunCaseConverter()
        {

            if (File.Exists(exePath))
            {
                RunAtStartup();
                return Process.Start(new ProcessStartInfo { FileName = exePath, UseShellExecute = true });
            }

            return null;
        }
        public static void RunAtStartup()
        {
            RegistryHelper.SetRegistryValue(Registry.CurrentUser, startupKeyPath, appName, exePath, RegistryValueKind.String);
        }

        public static void RemoveFromStartup()
        {
            RegistryHelper.DeleteRegistryValue(Registry.CurrentUser, startupKeyPath, appName);
        }
        private async Task SaveHotkeyAsync()
        {


            string convertedKey = ConvertHotkey(hotkeyTextBox.Text);

            try
            {
                await File.WriteAllTextAsync(configPath, ";" + hotkeyTextBox.Text + "\n" + convertedKey);
                Debug.WriteLine("Config saved.");

                string exePath = Path.Combine(AppContext.BaseDirectory, appName + ".exe");
                string processName = Path.GetFileNameWithoutExtension(exePath); // Get process name without .exe

                // Check if the process is already running
                if (Process.GetProcessesByName(processName).Any())
                {
                    // Start only if it is already running
                    RunCaseConverter();

                }
                else
                {
                    //await ShowErrorDialog("The application is not running.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving config: " + ex.Message);
            }
        }
        private async Task ShowErrorDialog(string message)
        {
            var errorDialog = new ContentDialog
            {
                Title = "Error",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            // Register the dialog to auto-update theme
            ThemeHelper.RegisterDialog(errorDialog);
            await errorDialog.ShowAsync();
        }


        private string ConvertHotkey(string plainText)
        {
            List<string> keys = plainText.Split('+').ToList();
            StringBuilder hotkey = new();

            foreach (string key in keys)
            {
                if (key == "Ctrl")
                    hotkey.Append("^");  // Ctrl = ^
                else if (key == "Alt")
                    hotkey.Append("!");  // Alt = !
                else if (key == "Shift")
                    hotkey.Append("+");  // Shift = +
                else
                {
                    // If Shift was pressed, append key directly (Shift+R = +R)
                    if (hotkey.Length > 0 && hotkey[^1] == '+')
                        hotkey.Append(key);
                    else
                        hotkey.Append(key);
                }
            }

            return hotkey.ToString();
        }



        public static async Task<string> ReadHotkeyAsync()
        {

            try
            {
                if (File.Exists(configPath))
                {
                    string[] lines = await File.ReadAllLinesAsync(configPath);
                    return lines.FirstOrDefault(line => line.StartsWith(";"))?.TrimStart(';') ?? "No hotkey set";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error reading config: " + ex.Message);
            }
            return "No hotkey set";
        }
    }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;

namespace Win11_Tweaker
{
    class RegistryHelper
    {
        /// <summary>
        /// Displays a confirmation dialog for system actions.
        /// </summary>
        public static class ActionTypes
        {
            public const string SignOut = "signout";
            public const string RestartExplorer = "restart_explorer";
            public const string RestartSystem = "restart_system";
        }
        public static async Task ShowActionDialog(string actionType, XamlRoot xamlRoot)
        {
            if (xamlRoot != null)
            {
                await ShowDialog(actionType, xamlRoot);
            }
            else
            {
                LoggerHelper.Log("XamlRoot is null. Dialog not shown.");
            }
        }
        public static async Task ShowDialog(string actionType, XamlRoot xamlRoot)
        {
            string title = "";
            string message = "";
            string confirmText = "Proceed";

            switch (actionType)
            {
                case ActionTypes.SignOut:
                    title = "Sign Out";
                    message = "Are you sure you want to sign out?";
                    break;
                case ActionTypes.RestartExplorer:
                    title = "Restart Explorer";
                    message = "Are you sure you want to restart Windows Explorer?";
                    break;
                case ActionTypes.RestartSystem:
                    title = "Restart System";
                    message = "Are you sure you want to restart your computer?";
                    confirmText = "Restart";
                    break;
                default:
                    LoggerHelper.Log("Unknown action.");
                    return;
            }

            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                PrimaryButtonText = confirmText,
                DefaultButton = ContentDialogButton.Primary,
                CloseButtonText = "I'll do it later",
                XamlRoot = xamlRoot // ✅ Set XamlRoot to fix the issue
            };
            ThemeHelper.RegisterDialog(dialog);


            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ExecuteAction(actionType);
            }
        }



        /// <summary>
        /// Executes system actions like sign out, restart explorer, or restart system.
        /// </summary>
        public static void ExecuteAction(string actionType)
        {
            ProcessStartInfo psi;

            switch (actionType)
            {
                case "signout":
                    psi = new ProcessStartInfo
                    {
                        FileName = "shutdown",
                        Arguments = "/l",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    Process.Start(psi);
                    break;

                case "restart_explorer":
                    psi = new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = "/F /IM explorer.exe",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = Process.Start(psi);
                    process?.WaitForExit(); // Ensure Explorer is fully terminated before restarting

                    psi = new ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                    break;

                case "restart_system":
                    psi = new ProcessStartInfo
                    {
                        FileName = "shutdown",
                        Arguments = "/r /t 0",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    Process.Start(psi);
                    break;

                default:
                    LoggerHelper.Log("Unknown action.");
                    break;
            }
        }
        public static void SetRegistryValue(RegistryKey rootKey, string keyPath, string valueName, object value, RegistryValueKind valueKind = RegistryValueKind.DWord)
        {
            try
            {
                using (RegistryKey key = rootKey.OpenSubKey(keyPath, writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, value, valueKind);
                    }
                    else
                    {
                        using (RegistryKey newKey = rootKey.CreateSubKey(keyPath, writable: true))
                        {
                            newKey?.SetValue(valueName, value, valueKind);
                        }
                    }
                }

                LoggerHelper.Log($"Successfully set {valueName} in {keyPath}");
            }
            catch (Exception ex)
            {
                LoggerHelper.Log($"Registry Error: {ex.Message} in  {keyPath}");
            }
        }
        public static void DeleteRegistryValue(RegistryKey rootKey, string keyPath, string valueName)
        {
            try
            {
                using (RegistryKey key = rootKey.OpenSubKey(keyPath, writable: true))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                        LoggerHelper.Log($"Successfully deleted {valueName} from {keyPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log($"Error deleting registry value: {ex.Message} from {keyPath}");
            }
        }
        /// <summary>
        /// Deletes a registry key and all its subkeys.
        /// </summary>
        public static void DeleteRegistryKey(RegistryKey rootKey, string keyPath)
        {
            try
            {
                rootKey.DeleteSubKeyTree(keyPath, throwOnMissingSubKey: false);
                LoggerHelper.Log($"Successfully deleted: {keyPath}");
            }
            catch (Exception ex)
            {
                LoggerHelper.Log($"Error deleting registry key: {ex.Message}from {keyPath} ");
            }
        }
    }
}

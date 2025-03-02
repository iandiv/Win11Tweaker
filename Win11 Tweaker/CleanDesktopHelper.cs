using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace Win11_Tweaker
{
    class CleanDesktopHelper
    {

        public static string appName = "Clean Desktop";
        private static string exePath = Path.Combine(AppContext.BaseDirectory, appName + ".exe");
        private static string startupKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static Process? RunCleanDesktop()
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
    }


}

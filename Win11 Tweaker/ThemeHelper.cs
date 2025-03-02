using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Win11_Tweaker
{

    public static class ThemeHelper
    {
        private static ElementTheme _currentTheme;
        private static List<ContentDialog> _dialogs = new();

        /// <summary>
        /// Applies the current theme to all registered ContentDialogs.
        /// </summary>
        public static void ApplyThemeToDialogs()
        {
            foreach (var dialog in _dialogs)
            {
                dialog.RequestedTheme = _currentTheme;
            }
        }

        /// <summary>
        /// Registers a ContentDialog to be updated when the theme changes.
        /// </summary>
        public static void RegisterDialog(ContentDialog dialog)
        {
            if (!_dialogs.Contains(dialog))
            {
                _dialogs.Add(dialog);
                dialog.RequestedTheme = _currentTheme;
            }
        }

        /// <summary>
        /// Unregisters a ContentDialog when it's closed.
        /// </summary>
        public static void UnregisterDialog(ContentDialog dialog)
        {
            _dialogs.Remove(dialog);
        }

        /// <summary>
        /// Updates the stored theme and applies it to all dialogs.
        /// </summary>
        public static void UpdateTheme(ElementTheme newTheme)
        {
            _currentTheme = newTheme;
            ApplyThemeToDialogs();
        }
    }
}


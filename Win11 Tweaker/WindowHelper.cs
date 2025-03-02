using System;
using System.Runtime.InteropServices;
using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;
using WinRT.Interop;

namespace Win11_Tweaker.Helpers
{
    public class WindowHelper
    {
        private readonly Window _window;
        private AppWindow _appWindow;
        private IntPtr _hWnd;
        private SystemBackdropConfiguration _configurationSource;
        private MicaBackdrop _micaBackdrop;
        private bool _micaEnabled;

        private int _minWidth = 710;
        private int _minHeight = 700;

        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_GETMINMAXINFO = 0x0024;

        private struct MINMAXINFO
        {
            public System.Drawing.Point ptReserved;
            public System.Drawing.Point ptMaxSize;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Point ptMinTrackSize;
            public System.Drawing.Point ptMaxTrackSize;
        }

        private readonly SUBCLASSPROC _subClassDelegate;

        public WindowHelper(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _subClassDelegate = new SUBCLASSPROC(WindowSubClass);
            InitializeWindow();

        }

        /// <summary>
        /// Gets the AppWindow associated with this helper.
        /// </summary>
        public AppWindow AppWindow => _appWindow;

        /// <summary>
        /// Gets the native window handle.
        /// </summary>
        public IntPtr WindowHandle => _hWnd;

        /// <summary>
        /// Gets or sets whether Mica is enabled.
        /// </summary>
        public bool MicaEnabled
        {
            get => _micaEnabled;
            set
            {
                _micaEnabled = value;
                TrySetMicaBackdrop();
            }
        }

        /// <summary>
        /// Gets or sets the minimum window size.
        /// </summary>
        public (int Width, int Height) MinimumSize
        {
            get => (_minWidth, _minHeight);
            set
            {
                _minWidth = value.Width;
                _minHeight = value.Height;
            }
        }

        /// <summary>
        /// Gets or sets the window size.
        /// </summary>
        public (int Width, int Height) WindowSize
        {
            get => (_appWindow.Size.Width, _appWindow.Size.Height);
            set => SetSize(value.Width, value.Height);
        }

        private void InitializeWindow()
        {
            _hWnd = WindowNative.GetWindowHandle(_window);
            var windowId = Win32Interop.GetWindowIdFromWindow(_hWnd);
            _appWindow = AppWindow.GetFromWindowId(windowId);

            SetWindowSubclass(_hWnd, _subClassDelegate, 0, 0);
            SetSize(710, 850);
            TrySetMicaBackdrop();
            CenterWindow();
            CustomizeTitleBar();
            if (_window.Content is FrameworkElement root)
            {
                root.ActualThemeChanged += (sender, args) =>
                {
                    UpdateTheme(root.ActualTheme);
                };
            }

        }

        private void UpdateTheme(ElementTheme newTheme)
        {
            if (_configurationSource != null)
            {
                _configurationSource.Theme = newTheme == ElementTheme.Dark
                    ? SystemBackdropTheme.Dark
                    : SystemBackdropTheme.Light;
            }

            TrySetMicaBackdrop();
            UpdateTitleBarColors();

            // Apply theme to all dialogs
            ThemeHelper.UpdateTheme(newTheme);
        }


        private void RefreshThemeResources()
        {
            if (_window.Content is FrameworkElement root)
            {
                root.Resources.MergedDictionaries.Clear(); // Clear old theme resources
                root.RequestedTheme = root.ActualTheme; // Force UI refresh
            }
        }
        /// <summary>
        /// Sets the window size.
        /// </summary>
        public void SetSize(int width, int height)
        {
            _appWindow.Resize(new SizeInt32(width, height));
        }

        /// <summary>
        /// Attempts to apply the Mica backdrop effect.
        /// </summary>
        private void TrySetMicaBackdrop()
        {
            if (!MicaController.IsSupported() || !_micaEnabled)
            {
                _window.SystemBackdrop = null;
                return;
            }

            if (_micaBackdrop == null)
            {
                _micaBackdrop = new MicaBackdrop();
            }

            if (_configurationSource == null)
            {
                _configurationSource = new SystemBackdropConfiguration();
            }

            _configurationSource.Theme = (_window.Content as FrameworkElement)?.ActualTheme == ElementTheme.Dark
                ? SystemBackdropTheme.Dark
                : SystemBackdropTheme.Light;

            _window.SystemBackdrop = _micaBackdrop;
        }


        /// <summary>
        /// Centers the window on the screen.
        /// </summary>
        private void CenterWindow()
        {
            var displayArea = DisplayArea.GetFromWindowId(_appWindow.Id, DisplayAreaFallback.Primary);
            var centerX = (displayArea.WorkArea.Width - _appWindow.Size.Width) / 2;
            var centerY = (displayArea.WorkArea.Height - _appWindow.Size.Height) / 2;
            _appWindow.Move(new PointInt32(centerX, centerY));
        }

        /// <summary>
        /// Customizes the title bar.
        /// </summary>
        private void CustomizeTitleBar()
        {
            if (_appWindow == null) return;

            var titleBar = _appWindow.TitleBar;
            titleBar.ExtendsContentIntoTitleBar = true;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            _window.SetTitleBar(null);
        }
        private void UpdateTitleBarColors()
        {
            var titleBar = _appWindow.TitleBar;
            var isDarkMode = (_window.Content as FrameworkElement)?.ActualTheme == ElementTheme.Dark;

            titleBar.ButtonForegroundColor = isDarkMode ? Colors.White : Colors.Black;
        }

        /// <summary>
        /// Handles setting the minimum window size.
        /// </summary>
        private int WindowSubClass(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData)
        {
            if (uMsg == WM_GETMINMAXINFO)
            {
                MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
                mmi.ptMinTrackSize.X = _minWidth;
                mmi.ptMinTrackSize.Y = _minHeight;
                Marshal.StructureToPtr(mmi, lParam, false);
                return 0;
            }
            return DefSubclassProc(hWnd, uMsg, wParam, lParam);
        }
    }
}

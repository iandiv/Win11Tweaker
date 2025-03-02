using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Win11_Tweaker
{
    class ToggleStateHelper
    {
        public static void LoadToggleStates(UIElement root, RoutedEventHandler toggleHandler)
        {
            ScrollViewer scrollViewer = FindChild<ScrollViewer>(root);
            if (scrollViewer == null)
            {
                Debug.WriteLine("Error: ScrollViewer not found.");
                return;
            }

            FrameworkElement searchRoot = scrollViewer.Content as FrameworkElement;
            if (searchRoot == null)
            {
                Debug.WriteLine("Error: Unable to find UI content inside ScrollViewer.");
                return;
            }

            Debug.WriteLine($"Searching inside {searchRoot.GetType().Name}");

            var toggles = FindChildren<ToggleSwitch>(searchRoot);
            if (toggles.Count == 0)
            {
                Debug.WriteLine("No ToggleSwitch controls found in the UI.");
                return;
            }

            foreach (var toggleSwitch in toggles)
            {
                if (!string.IsNullOrEmpty(toggleSwitch.Name))
                {
                    toggleSwitch.Toggled -= toggleHandler;
                    toggleSwitch.IsOn = SettingsHelper.LoadToggleState(toggleSwitch.Name);
                    toggleSwitch.Toggled += toggleHandler;
                    Debug.WriteLine($"Loaded Toggle: {toggleSwitch.Name} -> {toggleSwitch.IsOn}");
                }
                else
                {
                    Debug.WriteLine("Found an unnamed ToggleSwitch.");
                }
            }

            Debug.WriteLine("All toggle states loaded successfully.");
        }

        public static List<T> FindChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            List<T> children = new List<T>();
            int count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild)
                {
                    children.Add(tChild);
                }
                children.AddRange(FindChildren<T>(child));
            }

            return children;
        }

        public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild)
                    return tChild;
                T foundChild = FindChild<T>(child);
                if (foundChild != null)
                    return foundChild;
            }
            return null;
        }
    }

}

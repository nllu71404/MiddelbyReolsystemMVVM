using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Helpers
{
    public static class WindowHelper
    {
        private static readonly Dictionary<Type, Window> _cache = new();

        public static void ShowSingleton<T>(Func<T> factory = null) where T : Window, new()
        {
            var type = typeof(T);

            if (!_cache.TryGetValue(type, out var win) || win == null)
            {
                win = factory != null ? factory() : new T();

                // Owner & taskbar-setup
                if (Application.Current?.MainWindow != null && win.Owner == null)
                {
                    win.Owner = Application.Current.MainWindow;
                    win.ShowInTaskbar = false; // ingen ekstra proceslinje-ikon
                }

                // Skjul i stedet for at lukke (bevar state)
                win.Closing += (s, e) =>
                {
                    e.Cancel = true;
                    win.Hide();
                };

                _cache[type] = win;
            }

            // Vis/aktiver
            if (!win.IsVisible) win.Show();
            if (win.WindowState == WindowState.Minimized) win.WindowState = WindowState.Normal;
            win.Activate();
            win.Topmost = true;  // sikre fokus
            win.Topmost = false;
            win.Focus();
        }
    }
}
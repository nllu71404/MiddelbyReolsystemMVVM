using MiddelbyReolsystemMVVM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Helpers
{
    public class WindowService : IWindowService
    {
        public void ShowSingleton<T>() where T : Window, new()
            => WindowHelper.ShowSingleton<T>(); // bruger din eksisterende helper
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Helpers
{
    public interface IWindowService
    {
        void ShowSingleton<T>() where T : Window, new();
    }
}

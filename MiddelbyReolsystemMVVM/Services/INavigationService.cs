using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MiddelbyReolsystemMVVM.Services
{
    public interface INavigationService
    {
        void Register(string key, Func<Page> factory);
        void NavigateTo(string key);
    }
}

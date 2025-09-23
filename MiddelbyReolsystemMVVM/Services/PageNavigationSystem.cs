using MiddelbyReolsystemMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MiddelbyReolsystemMVVM.Services
{
    internal sealed class PageNavigationService : INavigationService
    {
        private readonly NavigationService _nav;
        private readonly Dictionary<string, Func<Page>> _routes = new();

        public PageNavigationService(NavigationService nav)
        {
            _nav = nav ?? throw new ArgumentNullException(nameof(nav));
        }

        public void Register(string key, Func<Page> factory)
        {
            _routes[key] = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void NavigateTo(string key)
        {
            if (!_routes.TryGetValue(key, out var factory))
                throw new InvalidOperationException($"Route '{key}' er ikke registreret.");
            _nav.Navigate(factory());
        }
    }
}
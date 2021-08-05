using Glosserie.WPF.Stores;
using Glosserie.WPF.ViewModels;
using Glosserie.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        
        public void Navigate()
        {
            _navigationStore.ActiveViewModel = _createViewModel();
        }

        public void Navigate(ViewModelBase viewModel)
        {
            _navigationStore.ActiveViewModel = viewModel;
        }
    }
}

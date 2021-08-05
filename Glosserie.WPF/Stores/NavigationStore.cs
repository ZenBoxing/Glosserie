using Glosserie.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.Stores
{
    public class NavigationStore 
    {
        private ViewModelBase _activeViewModel;

        public ViewModelBase ActiveViewModel
        {
            get { return _activeViewModel; }
            set { 
                    _activeViewModel = value;
                    OnActiveViewModelChanged();
                }
        }


        public event Action ActiveViewModelChanged;

        public NavigationStore()
        {
        }

        private void OnActiveViewModelChanged()
        {
            ActiveViewModelChanged?.Invoke();
        }
    }
}

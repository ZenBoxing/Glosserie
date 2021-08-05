using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Stores;
using Glosserie.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Glosserie.WPF.Services;

namespace Glosserie.WPF.ViewModels
{
	

    public class ShellViewModel : ViewModelBase
    {
		private readonly NavigationStore _navigationStore;

        public ViewModelBase ActiveViewModel => _navigationStore.ActiveViewModel;

        public ShellViewModel(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
            _navigationStore.ActiveViewModelChanged += OnActiveViewModelChanged;
		}

		private void OnActiveViewModelChanged()
		{
			OnPropertyChanged(nameof(ActiveViewModel));
		}


	}
}

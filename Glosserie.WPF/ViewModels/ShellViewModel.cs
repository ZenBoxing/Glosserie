using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Glosserie.WPF.Services;
using System.Windows;

namespace Glosserie.WPF.ViewModels
{
	

    public class ShellViewModel : ViewModelBase
    {
		private readonly NavigationStore _navigationStore;

        public ViewModelBase ActiveViewModel => _navigationStore.ActiveViewModel;

		private Window _mainWindow = App.Current.MainWindow;

		public Window MainWindow
		{
			get { return _mainWindow = App.Current.MainWindow; }
			set { _mainWindow = App.Current.MainWindow = value; }

		}

		public ICommand CloseCommand { get; set; }
		public ICommand MinimizeCommand { get; set; }

		public ShellViewModel(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
            _navigationStore.ActiveViewModelChanged += OnActiveViewModelChanged;
			CloseCommand = new DelegateCommand(Close);
			MinimizeCommand = new DelegateCommand(Minimize);
		}

		private void OnActiveViewModelChanged()
		{
			OnPropertyChanged(nameof(ActiveViewModel));
		}

		public void Close()
		{
			MainWindow.Close();
		}

		public void Minimize()
		{
			MainWindow.WindowState = WindowState.Minimized;
		}


	}
}

using Glosserie.WPF.Library.Services;
using Glosserie.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels
{
	

    public class ShellViewModel : ViewModelBase
    {
		private ViewModelBase _activeViewModel;

		public ViewModelBase ActiveViewModel
		{
			get { return _activeViewModel; }
			set { _activeViewModel = value; }
		}

		public ShellViewModel(IViewModelAbstractFactory factory)
		{
			ActiveViewModel = factory.CreateViewModel(ViewType.Home);
		}

	}
}

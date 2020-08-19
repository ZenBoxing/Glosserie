using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
		private ViewModelBase _activeViewModel = new LoginViewModel();

		public ViewModelBase ActiveViewModel
		{
			get { return _activeViewModel; }
			set { _activeViewModel = value; }
		}

	}
}

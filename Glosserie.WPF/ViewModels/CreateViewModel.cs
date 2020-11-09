using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
		private VocabListOptionsModel _options;

		public VocabListOptionsModel Options
		{
			get { return _options; }
			set 
			{ 
				_options = value;
				OnPropertyChanged(nameof(Options));
			}
		}

	}
}

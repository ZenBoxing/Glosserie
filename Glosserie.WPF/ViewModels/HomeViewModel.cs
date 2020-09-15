using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
		private List<VocabListModel> _vocabLists;

		public List<VocabListModel> VocabLists 
		{
			get { return _vocabLists; }
			set { _vocabLists = value; }
		}

	}
}

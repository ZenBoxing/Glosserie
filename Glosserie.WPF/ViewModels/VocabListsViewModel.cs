using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class VocabListsViewModel : ViewModelBase
    {
		public string StatusMessage;
		private BindingList<VocabListModel> _vocabLists;
		public string BindingTest { get; set; } = "Bound to vocablists";

		public BindingList<VocabListModel> VocabLists
		{
			get { return _vocabLists; }
			set
			{
				_vocabLists = value;
				OnPropertyChanged(nameof(VocabLists));
			}
		}

		private readonly IVocabListService _vocabListService;
		public ICommand LoadVocabListsCommand;

		public VocabListsViewModel(IVocabListService vocabListService)
		{
			_vocabListService = vocabListService;
			LoadVocabListsCommand = new AsyncDelegateCommand(LoadVocabListsAsync, (ex) => StatusMessage = ex.Message);
		}




		private async Task LoadVocabListsAsync()
		{
			//_vocabListService.GetVocabLists().ContinueWith(task =>
			//{
			//	if (task.Exception == null)
			//	{
			//		var records =  task.Result;
			//		VocabLists = new BindingList<VocabListModel>(records);
			//	}
			//});

			var records = await _vocabListService.GetVocabLists();
			VocabLists = new BindingList<VocabListModel>(records);

		}
	}
}

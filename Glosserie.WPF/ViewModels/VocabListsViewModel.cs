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

		public BindingList<VocabListModel> VocabLists
		{
			get { return _vocabLists; }
			set
			{
				_vocabLists = value;
				OnPropertyChanged(nameof(VocabLists));
				OnPropertyChanged(nameof(VocabListItemViewModels));
			}
		}

		private List<VocabListItemViewModel> _vocabListItemViewModels;

		public List<VocabListItemViewModel> VocabListItemViewModels
		{
			get { return _vocabListItemViewModels; }
			set 
			{
				_vocabListItemViewModels = value;
				OnPropertyChanged(nameof(VocabListItemViewModels));
			}
		}


		private readonly IVocabListService _vocabListService;
		public ICommand LoadVocabListsCommand { get; set; }

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
			VocabListItemViewModels = CreateVocabListViewModels(VocabLists);
		}

		private List<VocabListItemViewModel> CreateVocabListViewModels(ICollection<VocabListModel> vocabListModels)
		{
			List<VocabListItemViewModel> itemList = new List<VocabListItemViewModel>();
			foreach (var item in vocabListModels)
			{
				itemList.Add(new VocabListItemViewModel{ Title = item.ListName});
			}

			return itemList;
		}

		
	}
}

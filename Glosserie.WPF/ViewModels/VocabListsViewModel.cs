using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Stores;
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
		private readonly VocabListStore _vocabListStore;

		public string StatusMessage;

		public BindingList<VocabListModel> VocabLists => _vocabListStore.VocabLists;

        private VocabListModel _selectedVocabList;
					
        public VocabListModel SelectedVocabList
        {
            get { return _selectedVocabList; }
            set { 
					_selectedVocabList = value;
				    OnPropertyChanged(nameof(SelectedVocabList));
			}
        }

        private readonly IVocabListService _vocabListService;
		public ICommand LoadVocabListsCommand { get; set; }
		public ICommand DeleteSelectedVocabListCommand { get; set; }

        public VocabListsViewModel(IVocabListService vocabListService, VocabListStore vocabListStore)
        {
            _vocabListService = vocabListService;
            LoadVocabListsCommand = new AsyncDelegateCommand(LoadVocabListsAsync, (ex) => StatusMessage = ex.Message);
			DeleteSelectedVocabListCommand = new AsyncDelegateCommand(DeleteSelectedVocabListAsync,
				(ex) => StatusMessage = ex.Message);
            _vocabListStore = vocabListStore;
			_vocabListStore.VocabListsChanged += OnVocabListsChanged;
        }


		private void OnVocabListsChanged()
		{
			OnPropertyChanged(nameof(VocabLists));
		}

        private async Task LoadVocabListsAsync()
		{
			await _vocabListStore.LoadVocabListsAsync();
		}

		private async Task DeleteSelectedVocabListAsync()
		{
			await _vocabListService.DeleteVocabList(_selectedVocabList.ListId);
		}

		//private List<VocabListItemViewModel> CreateVocabListViewModels(ICollection<VocabListModel> vocabListModels)
		//{
		//	List<VocabListItemViewModel> itemList = new List<VocabListItemViewModel>();
		//	foreach (var item in vocabListModels)
		//	{
		//		itemList.Add(new VocabListItemViewModel{ Title = item.ListName});
		//	}

		//	return itemList;
		//}

		
	}
}

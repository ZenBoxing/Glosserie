using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Stores
{
    public class VocabListStore
    {
		private readonly IVocabListService _vocabListService;

		private BindingList<VocabListModel> _vocabLists;

		public BindingList<VocabListModel> VocabLists
		{
			get { return _vocabLists; }
			set
			{
				_vocabLists = value;
				OnVocabListsChanged();
			}
		}

		public event Action VocabListsChanged;

        public VocabListStore(IVocabListService vocabListService)
        {
            _vocabListService = vocabListService;
        }

        private void OnVocabListsChanged()
		{
			VocabListsChanged?.Invoke();
		}

		public async Task LoadVocabListsAsync()
		{
			var records = await _vocabListService.GetVocabLists();
			VocabLists = new BindingList<VocabListModel>(records);
		}
	}
}

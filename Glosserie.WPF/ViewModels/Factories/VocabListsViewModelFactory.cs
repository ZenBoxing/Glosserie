using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class VocabListsViewModelFactory : IViewModelFactory<VocabListsViewModel>
    {
        private readonly IVocabListService _vocabListService;

        public VocabListsViewModelFactory(IVocabListService vocabListService)
        {
            _vocabListService = vocabListService;
        }

        public VocabListsViewModel CreateViewModel()
        {
            return new VocabListsViewModel(_vocabListService);
        }
    }
}

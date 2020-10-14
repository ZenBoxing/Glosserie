using Glosserie.WPF.Library.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        
        private readonly IViewModelFactory<VocabListsViewModel> _vocablistsViewModelFactory;

        public HomeViewModelFactory(IViewModelFactory<VocabListsViewModel> vocabListsViewModelFactory)
        {
            _vocablistsViewModelFactory = vocabListsViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_vocablistsViewModelFactory.CreateViewModel());
        }
    }
}

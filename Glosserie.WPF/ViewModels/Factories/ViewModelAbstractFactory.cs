using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<VocabListsViewModel> _vocabListsViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _loginViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<VocabListsViewModel> vocabListsViewModelFactory, 
            IViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _vocabListsViewModelFactory = vocabListsViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.VocabLists:
                    return _vocabListsViewModelFactory.CreateViewModel();
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType does not have ViewModel", "ViewType");
            }
        }
    }
}

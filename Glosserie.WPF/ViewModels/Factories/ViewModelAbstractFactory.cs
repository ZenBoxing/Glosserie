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
        private readonly IViewModelFactory<RegisterViewModel> _registerViewModelFactory;

        public ViewModelAbstractFactory(IViewModelFactory<HomeViewModel> homeViewModelFactory,
            IViewModelFactory<VocabListsViewModel> vocabListsViewModelFactory,
            IViewModelFactory<LoginViewModel> loginViewModelFactory, 
            IViewModelFactory<RegisterViewModel> registerViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _vocabListsViewModelFactory = vocabListsViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
            _registerViewModelFactory = registerViewModelFactory;
        }

        public ViewModelBase CreateViewModel(TViewModel viewType)
        {
            switch (viewType)
            {
                case TViewModel.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case TViewModel.VocabLists:
                    return _vocabListsViewModelFactory.CreateViewModel();
                case TViewModel.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case TViewModel.Register:
                    return _registerViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType does not have ViewModel", "ViewType");
            }
        }
    }
}

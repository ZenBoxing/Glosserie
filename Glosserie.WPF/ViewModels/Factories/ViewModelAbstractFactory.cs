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
                case ViewType.Register:
                    return _registerViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("ViewType does not have ViewModel", "ViewType");
            }
        }
    }
}

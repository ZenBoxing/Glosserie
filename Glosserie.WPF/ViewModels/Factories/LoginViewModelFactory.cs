using Glosserie.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly NavigationStore _navigationStore;

        public LoginViewModelFactory(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_navigationStore);
        }
    }
}

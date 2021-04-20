using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : IViewModelFactory<LoginViewModel>
    {
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel();
        }
    }
}

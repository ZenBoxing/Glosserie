using System;
using System.Collections.Generic;
using System.Text;

namespace Glosserie.WPF.ViewModels.Factories
{
    public class RegisterViewModelFactory : IViewModelFactory<RegisterViewModel>
    {
        public RegisterViewModel CreateViewModel()
        {
            return new RegisterViewModel();
        }
    }
}

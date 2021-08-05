using Glosserie.WPF.Commands;
using Glosserie.WPF.Services;
using Glosserie.WPF.Stores;
using Glosserie.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand NavigateToRegisterViewCommand { get; }

        public LoginViewModel(NavigationStore navStore)
        {
            NavigateToRegisterViewCommand = new NavigateCommand
                (new NavigationService(navStore, () => new RegisterViewModel()));
        }
    }
}

using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
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
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public bool IsLoginInvalid => StatusMessage != null;

        public ICommand NavigateToRegisterViewCommand { get; }
        public ICommand LoginNavigateCommand { get; }

        private readonly IAuthenticator _authenticator;
        private readonly IVocabListService _vocabListService;

        public LoginViewModel(NavigationStore navStore, IAuthenticator authenticator,
            IVocabListService vocabListService)
        {
            NavigateToRegisterViewCommand = new NavigateCommand
                (new NavigationService(navStore, () => new RegisterViewModel()));
            _authenticator = authenticator;
            _vocabListService = vocabListService;

            LoginNavigateCommand = new LoginNavigateCommand(this, new NavigationService(navStore,
                () => new HomeViewModel(new VocabListsViewModel(_vocabListService))),
                _authenticator, (Exception ex) => StatusMessage = ex.Message);
        }
    }
}

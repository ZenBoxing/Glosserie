using Glosserie.WPF.Commands;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Services;
using Glosserie.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Glosserie.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
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
                OnPropertyChanged(nameof(IsRegistrationInvalid));
            }
        }

        public bool IsRegistrationInvalid => StatusMessage != null;

        public ICommand RegisterNavigateCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore, IAuthenticator authenticator, IVocabListService vocabListService)
        {
            RegisterNavigateCommand = new RegisterNavigateCommand
                (new NavigationService(navigationStore,
                () => new HomeViewModel(new VocabListsViewModel(vocabListService), new CreateVocabListFormViewModel(vocabListService))),
                authenticator,
                this,
                (Exception ex) => StatusMessage = ex.Message);

        }
    }
}

using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Services;
using Glosserie.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Commands
{
    public class RegisterNavigateCommand : AsyncCommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly RegisterViewModel _registerViewModel;

        public RegisterNavigateCommand(INavigationService navigationService,  
            IAuthenticator authenticator, 
            RegisterViewModel registerViewModel, Action<Exception> onException) : base (onException)
        {
            _navigationService = navigationService;
            _authenticator = authenticator;
            _registerViewModel = registerViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            bool registerSuccess = await _authenticator.Register(new RegistrationModel {
                Email = _registerViewModel.Email,
                Password = _registerViewModel.Password,
                ConfirmPassword = _registerViewModel.ConfirmPassword
            });

            if (registerSuccess)
            {
                UserModel user = await _authenticator.Login(new LoginModel(_registerViewModel.Email, _registerViewModel.Password));
                _authenticator.UpdateCurrentUser(user);

                _navigationService.Navigate();
            }
            else {
                //more specific message
                throw new Exception("Registration Failed");
            }

        }
    }
}

using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using Glosserie.WPF.Library.State.Authenticators;
using Glosserie.WPF.Services;
using Glosserie.WPF.Stores;
using Glosserie.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Commands
{
    public class LoginNavigateCommand : AsyncCommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;

        public LoginNavigateCommand(LoginViewModel loginViewModel,
             NavigationService navigationService, IAuthenticator authenticator, Action<Exception> onException) : base (onException)
        {
            _loginViewModel = loginViewModel;
            _navigationService = navigationService;
            _authenticator = authenticator;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            //attempt to login user
            UserModel user = await _authenticator.Login(new LoginModel(_loginViewModel.Email, _loginViewModel.Password));
            if (user.UserID != 0)
            {
                _authenticator.UpdateCurrentUser(user);                
                _navigationService.Navigate();
            }
            else
            {
                throw new Exception("Invalid Login");             
            }
            //if login is successful, add user to  and navigate to homepage.
            //if login unsuccessful: ???
        }
    }
}

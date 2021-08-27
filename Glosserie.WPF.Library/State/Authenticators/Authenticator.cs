using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.Services;
using System; 
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public UserModel CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public Task<UserModel> Login(LoginModel info)
        {
            return  _authenticationService.Login(info);
        }

        public void UpdateCurrentUser(UserModel userModel)
        {
            CurrentUser = new UserModel { 
                UserID = userModel.UserID,
                Email = userModel.Email,
            };
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegistrationModel info)
        {
            return _authenticationService.Register(info);
        }
    }
}

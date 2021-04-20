using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.State.Authenticators
{
    public interface IAuthenticator
    {
        UserModel CurrentUser { get; }
        bool IsLoggedIn { get; }

        Task<bool> Register(RegistrationModel info);
        Task<UserModel> Login(LoginModel info);
        void Logout(); 
        
    }
}

using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Register(RegistrationModel info);
        Task<UserModel> Login(string email, string password);
    }
}

using Glosserie.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Services
{
    public interface IAuthenticationService
    {
        bool Register(string email, string password, string confirmpassword);
        UserModel Login(string email, string password);
    }
}

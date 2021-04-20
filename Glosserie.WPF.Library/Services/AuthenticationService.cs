using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<UserModel> Login(LoginModel info)
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "user/login";
                //string uri = "user";
                var record = await client.PostAsync<UserModel, LoginModel>(uri,info);

                return record;
            }
        }

        public async Task<bool> Register(RegistrationModel info)
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "user/register";
                //try catch
                var success = await client.PostAsync<bool, RegistrationModel>(uri, info);

                return success;
            }
        }
    }
}

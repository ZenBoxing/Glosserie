using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<UserModel> Login(string email, string password)
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "user";
                var records = await client.GetAsync<UserModel>(uri);

                return records[0];
            }
        }

        public async Task<bool> Register(RegistrationModel info)
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "user";
                //try catch
                var success = await client.PostAsync<bool, dynamic>(uri, info);

                return success;
            }
        }
    }
}

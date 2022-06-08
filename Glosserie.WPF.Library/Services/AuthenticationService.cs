using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verifalia.Api;
using Verifalia.Api.EmailValidations;
using Verifalia.Api.EmailValidations.Models;

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
            var isVerifiedEmail = await VerifyEmailAddress(info.Email);
            if (isVerifiedEmail)
            {

                using (GlosserieHttpClient client = new GlosserieHttpClient())
                {
                    string uri = "user/register";
                    //try catch
                    var success = await client.PostAsync<bool, RegistrationModel>(uri, info);

                    return success;
                } 
            }
            else
            {
                return isVerifiedEmail;
            }
        }

        public async Task<bool> VerifyEmailAddress(string email)
        {
            var verfalia = new VerifaliaRestClient("jarrettlirette@gmail.com", "Zombiev1!11");

            var validation = await verfalia.EmailValidations.SubmitAsync(email, waitingStrategy: new WaitingStrategy(true));

            var validationResult = validation.Entries[0].Status;
            if (validationResult == ValidationEntryStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

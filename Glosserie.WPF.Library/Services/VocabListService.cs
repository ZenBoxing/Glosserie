using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.State.Authenticators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public class VocabListService : IVocabListService
    {
        private readonly IAuthenticator _authenticator;

        public VocabListService(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public async Task<bool> GetCreateVocabList(VocabListOptionsModel options)
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "vocablists";
                var success = await client.PostAsync<bool, VocabListOptionsModel>(uri, options);

                return success;
            }

        }

        public async Task<List<VocabListModel>> GetVocabLists()
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "vocablists/" + _authenticator.CurrentUser.UserID.ToString();
                var records = await client.GetAsync<VocabListModel>(uri);

                return records;
            }
        }

        public async Task<bool> DeleteVocabList(int listID)
        { 
            using(GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "vocablists/" + listID.ToString();
                var responseMessage = await client.DeleteAsync(uri);

                if(responseMessage.IsSuccessStatusCode)
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
}

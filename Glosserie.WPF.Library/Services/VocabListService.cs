using Glosserie.WPF.Library.Models;
using Glosserie.WPF.Library.State.Authenticators;
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

        public async Task<List<VocabListModel>> GetVocabLists()
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "vocablists/" + _authenticator.CurrentUser.UserID.ToString();
                var records = await client.GetAsync<VocabListModel>(uri);

                return records;
            }
        }
    }
}

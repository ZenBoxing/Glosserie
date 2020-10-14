using Glosserie.WPF.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Services
{
    public class VocabListService : IVocabListService
    {
        public async Task<List<VocabListModel>> GetVocabLists()
        {
            using (GlosserieHttpClient client = new GlosserieHttpClient())
            {
                string uri = "vocablists";
                var records = await client.GetAsync<VocabListModel>(uri);

                return records;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library
{
    public class GlosserieHttpClient : HttpClient
    {
        public GlosserieHttpClient()
        {
            this.BaseAddress = new Uri("http://localhost:58378/api/");
        }

        public async Task<List<T>> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var records = JsonConvert.DeserializeObject<List<T>>(jsonResponse);
            return records;
        }


    }
}

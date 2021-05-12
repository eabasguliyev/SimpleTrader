using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient:HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri(@"https://financialmodelingprep.com/api/v3/");
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync(uri);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse); ;
        }
    }
}
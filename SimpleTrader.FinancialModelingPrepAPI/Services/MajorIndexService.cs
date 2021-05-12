using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService:IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = @"https://financialmodelingprep.com/api/v3/majors-indexes/" + GetUriSuffix(indexType) +
                             "?apikey=618edc49f868d97ae7a519ed762c4bf7";
                HttpResponseMessage response = await client.GetAsync(uri);

                string jsonResponse = await response.Content.ReadAsStringAsync();

                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);

                majorIndex.Type = indexType;

                return majorIndex;
            }
        }

        private object GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    throw new ArgumentOutOfRangeException(nameof(indexType), indexType, null);
            }
        }
    }
}
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
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = @"majors-indexes/" + GetUriSuffix(indexType) +
                             "?apikey=618edc49f868d97ae7a519ed762c4bf7";

                MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
                
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
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService:IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = @"stock/real-time-price/" + symbol +
                             "?apikey=618edc49f868d97ae7a519ed762c4bf7";


                StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

                if (stockPriceResult.Price == 0)
                    throw new InvalidSymbolException(symbol);

                return stockPriceResult.Price;
            }
        }
    }
}
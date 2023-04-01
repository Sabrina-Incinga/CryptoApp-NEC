using CryptoWebApp.Data.Repositories.Interfaces;
using CryptoWebApp.Support.Entities;
using CryptoWebApp.Support.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoWebApp.Data.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly string apiKey;
        private readonly RestClient client = new RestClient("https://pro-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest");

        public CryptoRepository(IConfiguration config)
        {
            apiKey = config["ApiKey"];
        }

        public async Task<CryptoCoinResponse> GetCryptoCoins(string coinSymbols)
        {
            var request = new RestRequest();
            request.AddHeader("X-CMC_PRO_API_KEY", apiKey);
            request.AddHeader("Accepts", "application/json");
            request.AddQueryParameter("symbol", coinSymbols);

            RestResponse<CryptoCoinResponse> response = await client.ExecuteAsync<CryptoCoinResponse>(request);

            if (response.IsSuccessful) return response.Data;
            
           throw new Exception("Required currencies were unable to get");
            
        }

        public async Task<ConversionResponse> GetCryptoConversion(ConversionRequest conversionRequest)
        {
            Dictionary<string, CurrencyData> data = new Dictionary<string, CurrencyData>();
            ConversionResponse conversionResponse = new ConversionResponse() { Data = data};

            foreach (var targetSymbol in conversionRequest.ToSymbol)
            {
                var request = new RestRequest();
                request.AddHeader("X-CMC_PRO_API_KEY", apiKey);
                request.AddHeader("Accepts", "application/json");
                request.AddQueryParameter("symbol", conversionRequest.FromSymbol);
                request.AddQueryParameter("convert", targetSymbol);
                RestResponse<CryptoCoinResponse> response = await client.ExecuteAsync<CryptoCoinResponse>(request);

                if (response.IsSuccessful) {

                    conversionResponse.Status = response.Data.Status;

                    foreach (var coin in response.Data.Data.Values)
                    {
                        CurrencyData currencyData = coin[0].Quote.Values.First();
                        currencyData.Price *= conversionRequest.Amount;

                        conversionResponse.Data.Add(coin[0].Quote.Keys.First(), currencyData);
                    }

                }
            }

            if (conversionResponse.Data.Count() == 0) throw new Exception("Required currencies unable to convert");

            return conversionResponse;

        }
    }
}

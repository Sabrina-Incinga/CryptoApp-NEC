using CryptoWebApp.Business.Interfaces;
using CryptoWebApp.Data.Repositories.Interfaces;
using CryptoWebApp.Support.Entities;
using CryptoWebApp.Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoWebApp.Business
{
    public class CryptoBusiness : ICryptoBusiness
    {
        private readonly ICryptoRepository _cryptoRepository;

        public CryptoBusiness(ICryptoRepository cryptoRepository)
        {
            _cryptoRepository = cryptoRepository;
        }

        public async Task<IEnumerable<CryptoCoin>> GetCryptoCoins(string coinSymbols)
        {
            try
            {
                var coinList = await _cryptoRepository.GetCryptoCoins(coinSymbols);
                if (coinList.Data.Values.Count() == 0) return null;

                List<CryptoCoin> result = new List<CryptoCoin>();
                foreach(var coin in coinList.Data.Values)
                {
                    result.Add(coin[0]);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConversionResponse> GetCryptoCoinConversions(ConversionRequest request)
        {
            try
            {
                var coinList = await _cryptoRepository.GetCryptoConversion(request);
                if (coinList.Data.Count() == 0) return null;

                return coinList;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

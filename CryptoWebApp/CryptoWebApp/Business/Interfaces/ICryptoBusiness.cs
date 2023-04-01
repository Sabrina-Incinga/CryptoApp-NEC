using CryptoWebApp.Support.Entities;
using CryptoWebApp.Support.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWebApp.Business.Interfaces
{
    public interface ICryptoBusiness
    {
        Task<IEnumerable<CryptoCoin>> GetCryptoCoins(string coinSymbols);
        Task<ConversionResponse> GetCryptoCoinConversions(ConversionRequest request);
    }
}

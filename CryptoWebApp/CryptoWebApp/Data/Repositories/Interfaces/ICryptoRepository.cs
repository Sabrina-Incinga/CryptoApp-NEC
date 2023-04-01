using CryptoWebApp.Support.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWebApp.Data.Repositories.Interfaces
{
    public interface ICryptoRepository
    {
        Task<CryptoCoinResponse> GetCryptoCoins(string coinSymbols);
        Task<ConversionResponse> GetCryptoConversion(ConversionRequest request);
    }
}

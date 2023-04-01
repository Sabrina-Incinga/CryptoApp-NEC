using CryptoWebApp.Business.Interfaces;
using CryptoWebApp.Support.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : Controller
    {
        private readonly ICryptoBusiness _cryptoBusiness;

        public CryptoController(ICryptoBusiness cryptoBusiness)
        {
            _cryptoBusiness = cryptoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string coinSymbols)
        {
            try
            {
                var result = await _cryptoBusiness.GetCryptoCoins(coinSymbols);
                if (result == null) return Ok("Coin currencies not found");

                return Ok(result);

            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("convert")]
        public async Task<IActionResult> GetConversions(string fromSymbol, string toSymbol, double amount)
        {
            List<string> toSymbolList = toSymbol.Split(',').ToList();
            ConversionRequest request = new ConversionRequest() { FromSymbol = fromSymbol, ToSymbol = toSymbolList, Amount = amount };
            try
            {
                var result = await _cryptoBusiness.GetCryptoCoinConversions(request);
                if (result == null) return Ok("Coin currencies not found");

                return Ok(result);
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

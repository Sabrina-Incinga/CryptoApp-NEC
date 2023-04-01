using CryptoWebApp.Support.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Models
{
    public class CryptoCoinResponse
    {
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }
        public Dictionary<string, List<CryptoCoin>> Data { get; set; }
    }
}

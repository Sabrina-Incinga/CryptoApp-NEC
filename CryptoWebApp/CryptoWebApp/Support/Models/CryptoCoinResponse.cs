using CryptoWebApp.Support.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Models
{
    public class CryptoCoinResponse
    {
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        public Dictionary<string,CryptoCoin> Data { get; set; }
    }
}

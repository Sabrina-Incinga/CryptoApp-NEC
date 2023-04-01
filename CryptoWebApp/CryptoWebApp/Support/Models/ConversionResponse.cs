using CryptoWebApp.Support.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Models
{
    public class ConversionResponse
    {
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }
        public Dictionary<string, CurrencyData> Data { get; set; }
    }
}

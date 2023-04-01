using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Entities
{
    public class CryptoCoin
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Maximum of characters allowed: 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Symbol is required")]
        [StringLength(10, ErrorMessage = "Maximum of characters allowed: 10")]
        public string Symbol { get; set; }
        public Dictionary<string, CurrencyData> Quote { get; set; }
    }
}

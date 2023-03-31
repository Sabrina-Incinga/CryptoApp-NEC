using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Models
{
    public class ConversionRequest
    {
        [Required(ErrorMessage = "Origin symbol is required")]
        [StringLength(10, ErrorMessage = "Maximum of characters allowed: 10")]
        public string FromSymbol { get; set; }
        [Required(ErrorMessage = "Target symbols is required")]
        public List<string> ToSymbol { get; set; }
        public double Amount { get; set; }
    }
}

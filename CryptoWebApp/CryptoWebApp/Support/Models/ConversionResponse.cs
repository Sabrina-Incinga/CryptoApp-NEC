using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoWebApp.Support.Models
{
    public class ConversionResponse
    {
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        public Dictionary<string, double> Data { get; set; }
    }
}

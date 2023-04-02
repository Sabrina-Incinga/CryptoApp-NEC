using System;

namespace CryptoWebApp.Support.Models
{
    public class Status
    {
        public DateTime Timestamp { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Payment model for API
    /// </summary>
    public class Payment
    {
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public uint Amount { get; set; }
        public string Currency { get; set; }
        public string Cvv { get; set; }
    }
}

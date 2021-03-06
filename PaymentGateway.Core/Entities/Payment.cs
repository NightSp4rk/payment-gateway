﻿using PaymentGateway.Core.Entities;
using System;

namespace PaymentGateway.Core.Entities
{
    /// <summary>
    /// Payment model for API
    /// </summary>
    public class Payment : IPayment
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public uint ExpiryYear { get; set; }
        public uint ExpiryMonth { get; set; }
        public uint Amount { get; set; }
        public string Currency { get; set; }
        public string Cvv { get; set; }
        public bool BankSuccess { get; set; }
        public string BankTransactionId { get; set; }
    }
}

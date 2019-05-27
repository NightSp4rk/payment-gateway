using PaymentGateway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Requests
{
    public class GetPaymentResponse : IPayment
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public uint Amount { get; set; }
        public string Currency { get; set; }
        public bool BankSuccess { get; set; }

        public GetPaymentResponse(Guid id, string cardNumber, string cardHolderName, uint amount, string currency, bool bankSuccess)
        {
            Id = id;
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            Amount = amount;
            Currency = currency;
            BankSuccess = bankSuccess;
        }
    }
}

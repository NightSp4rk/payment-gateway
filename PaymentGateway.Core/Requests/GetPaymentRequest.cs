using PaymentGateway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Requests
{
    public class GetPaymentRequest : IPayment
    {
        public Guid Id { get; set; }
        public Card CardNumber { get; set; }
        public bool BankSuccess { get; set; }
    }
}

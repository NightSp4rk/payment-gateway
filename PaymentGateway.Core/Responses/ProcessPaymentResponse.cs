using PaymentGateway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Requests
{
    public class ProcessPaymentResponse : IPayment
    {
        public Guid Id { get; set; }
        public bool BankSuccess { get; set; }
    }
}

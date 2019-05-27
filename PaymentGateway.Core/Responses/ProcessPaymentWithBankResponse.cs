using PaymentGateway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Requests
{
    public class ProcessPaymentWithBankResponse : IPayment
    {
        public Guid Id { get; set; }
    }
}

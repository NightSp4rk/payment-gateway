using PaymentGateway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Requests
{
    public class ProcessPaymentRequest : IPayment
    {
        public Guid Id { get; set; }
    }
}

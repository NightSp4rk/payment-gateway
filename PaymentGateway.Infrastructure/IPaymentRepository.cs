using PaymentGateway.Core;
using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure
{
    public interface IPaymentRepository
    {
        Task<IPayment> Create(IPayment payment);
        Task<IPayment> Read(IPayment paymentrequest);
    }
}

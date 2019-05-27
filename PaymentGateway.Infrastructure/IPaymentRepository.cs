using PaymentGateway.Core;
using PaymentGateway.Core.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Create(Payment payment);
        Task<GetPaymentResponse> Read(Guid id);
    }
}

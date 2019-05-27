using PaymentGateway.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Create(Payment payment);
        Task Read(Guid id);
    }
}

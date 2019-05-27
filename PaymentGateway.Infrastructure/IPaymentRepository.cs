using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Infrastructure
{
    public interface IPaymentRepository
    {
        Task Create();
        Task Read();
    }
}

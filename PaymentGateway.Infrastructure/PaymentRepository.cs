using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Infrastructure
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _paymentDbContext;

        public PaymentRepository(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        public async Task Create()
        {

        }

        public async Task<GetPaymentResponse> Read(Guid id)
        {

        }
    }
}

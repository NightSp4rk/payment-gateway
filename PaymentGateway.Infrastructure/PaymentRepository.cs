using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Core;
using PaymentGateway.Core.Requests;

namespace PaymentGateway.Infrastructure
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _paymentDbContext;

        public PaymentRepository(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        public async Task Create(Payment payment)
        {
            _paymentDbContext.Payments.Add(payment);
            await Task.CompletedTask;
        }

        public async Task<GetPaymentResponse> Read(Guid id)
        {
            Payment payment = _paymentDbContext.Payments.Where(p => p.Id == id).SingleOrDefault();
            GetPaymentResponse getPaymentResponse = new GetPaymentResponse();
            return await Task.FromResult(getPaymentResponse);
        }
    }
}

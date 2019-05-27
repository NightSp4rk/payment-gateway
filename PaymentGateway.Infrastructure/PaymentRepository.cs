using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.Core;
using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;

namespace PaymentGateway.Infrastructure
{

    public class PaymentRepository : IPaymentRepository
    {
        public static HttpClient httpClient = new HttpClient();

        private readonly PaymentDbContext _paymentDbContext;

        public PaymentRepository(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        public async Task Create(IPayment payment)
        {
            _paymentDbContext.Payments.Add(payment);
            await Task.CompletedTask;
        }

        public async Task<GetPaymentResponse> Read(Guid id)
        {
            IPayment payment = _paymentDbContext.Payments.Where(p => p.Id == id).SingleOrDefault();
            GetPaymentResponse getPaymentResponse = new GetPaymentResponse();
            return await Task.FromResult(getPaymentResponse);
        }
    }
}

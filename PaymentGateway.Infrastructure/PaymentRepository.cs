using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<IPayment> Create(IPayment payment)
        {
            payment = await ProcessPayment(payment);
            _paymentDbContext.Payments.Add(payment);

            return payment;
        }

        public async Task<IPayment> Read(string id)
        {
            IPayment payment = _paymentDbContext.Payments.Where(p => p.Id.ToString() == id).SingleOrDefault();
            GetPaymentResponse getPaymentResponse = new GetPaymentResponse();
            return await Task.FromResult(getPaymentResponse);
        }

        private async Task<ProcessPaymentWithBankResponse> ProcessPayment(IPayment payment)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string uri = "";
            var response = await httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProcessPaymentWithBankResponse>(content);
            }

            return null;
        }
    }
}

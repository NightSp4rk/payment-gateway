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
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

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

        public async Task<Payment> Create(ProcessPaymentRequest payment)
        {
            var bankResponse = await ProcessPayment(payment);

            if(bankResponse == null)
            {
                bankResponse = new Payment
                {
                    Id = payment.Id,
                    CardHolderName = payment.CardHolderName,
                    CardNumber = payment.CardNumber,
                    ExpiryYear = payment.ExpiryYear,
                    ExpiryMonth = payment.ExpiryMonth,
                    Amount = payment.Amount,
                    Currency = payment.Currency,
                    Cvv = payment.Cvv,
                    BankSuccess = false
                };
            }

            _paymentDbContext.Payments.Add(bankResponse);
            _paymentDbContext.SaveChanges();

            return bankResponse;
        }

        public Payment Read(string id)
        {
            Payment payment = _paymentDbContext.Payments.Where(p => p.Id.ToString() == id).SingleOrDefault();
            return payment;
        }

        private async Task<Payment> ProcessPayment(ProcessPaymentRequest payment)
        {
            var server = FluentMockServer.Start();
            string apiPath = "/bank/CreateTransaction";

            server.Given(
                Request.Create().WithPath(apiPath).UsingPost().WithBody(""))
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json").WithBodyAsJson(new Payment {
                    Id = payment.Id,
                    CardNumber = payment.CardNumber,
                    CardHolderName = payment.CardHolderName,
                    ExpiryYear = payment.ExpiryYear,
                    ExpiryMonth = payment.ExpiryMonth,
                    Amount = payment.Amount,
                    Currency = payment.Currency,
                    Cvv = payment.Cvv,
                    BankSuccess = true,
                    BankTransactionId = Guid.NewGuid().ToString()
    }));

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string uri = "https://localhost:"+server.Ports.First()+apiPath;
            var response = await httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                server.Stop();
                return JsonConvert.DeserializeObject<Payment>(content);
            }

            server.Stop();
            return null;
        }
    }
}

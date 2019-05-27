using Newtonsoft.Json;
using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application
{
    public static class ProcessPaymentWithBank
    {
        public static async Task<ProcessPaymentWithBankResponse> ProcessPayment(IPayment payment)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string uri = "";
                var response = await httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json"));

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ProcessPaymentWithBankResponse>(content);
                }

                return null;
            }
        }
    }
}

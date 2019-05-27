using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using PaymentGateway.Core;
using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;

namespace PaymentGateway.Controllers
{
    public class PaymentController : ControllerBase
    {
        [SwaggerOperation(operationId: "GetPayment")]
        [HttpGet("", Name = "GetPayment")]
        [ProducesResponseType(typeof(Payment), 200)]
        public async Task<ActionResult<GetPaymentResponse>> Get(Guid id)
        {
            var getPaymentResponse = new GetPaymentResponse(); 
            //var payment = new Payment
            //{
            //    CardNumber = new Card(),
            //    ExpiryYear = 2019,
            //    ExpiryMonth = 10,
            //    Amount = 1000,
            //    Currency = "USD",
            //    Cvv = "123"
            //};

            return Ok(getPaymentResponse);
        }
    }
}
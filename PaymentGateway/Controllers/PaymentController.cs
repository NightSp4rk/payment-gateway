using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using PaymentGateway.Core;

namespace PaymentGateway.Controllers
{
    public class PaymentController : ControllerBase
    {
        [SwaggerOperation(operationId: "GetPayment")]
        [HttpGet("", Name = "GetPayment")]
        [ProducesResponseType(typeof(Payment), 200)]
        public IActionResult Get()
        {
            var payment = new Payment
            {
                CardNumber = "",
                ExpiryDate = new DateTime(),
                Amount = 1000,
                Currency = "USD",
                Cvv = "123"
            };

            return Ok(payment);
        }
    }
}
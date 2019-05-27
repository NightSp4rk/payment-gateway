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
        public async Task<ActionResult<IPayment>> Get(Guid id)
        {
            var getPaymentResponse = new GetPaymentResponse();

            return Ok(getPaymentResponse);
        }
    }
}
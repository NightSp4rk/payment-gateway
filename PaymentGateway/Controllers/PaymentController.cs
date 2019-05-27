using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using PaymentGateway.Core;
using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;
using PaymentGateway.Infrastructure;

namespace PaymentGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentDbContext _paymentDbContext;

        public PaymentController(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

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
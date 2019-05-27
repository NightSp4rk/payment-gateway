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

namespace PaymentGateway.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [SwaggerOperation(operationId: "GetPayment")]
        [HttpGet("", Name = "GetPayment")]
        [ProducesResponseType(typeof(Payment), 200)]
        public async Task<ActionResult<IPayment>> Get(string id)
        {
            var getPaymentResponse = await _paymentRepository.Read(id);

            if (getPaymentResponse == null)
            {
                return NotFound();
            }

            return Ok("hello");
            return Ok(getPaymentResponse);
        }

        [SwaggerOperation(operationId: "ProcessPayment")]
        [HttpPost("", Name = "ProcessPayment")]
        [ProducesResponseType(typeof(Payment), 200)]
        public async Task<ActionResult<IPayment>> Post([FromBody] ProcessPaymentRequest processPaymentRequest)
        {
            var processPaymentResponse = await _paymentRepository.Create(processPaymentRequest);

            return Ok(processPaymentResponse);
        }
    }
}
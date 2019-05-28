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
        public ActionResult<IPayment> Get(string id)
        {
            var payment = _paymentRepository.Read(id);

            if (payment == null)
            {
                return NotFound();
            }

            GetPaymentResponse resp = new GetPaymentResponse(payment.Id, payment.CardNumber, payment.CardHolderName, payment.Amount, payment.Currency, payment.BankSuccess);

            return Ok(resp);
        }

        [SwaggerOperation(operationId: "ProcessPayment")]
        [HttpPost("", Name = "ProcessPayment")]
        [ProducesResponseType(typeof(Payment), 201)]
        public async Task<ActionResult<IPayment>> Post([FromBody] ProcessPaymentRequest payment)
        {
            payment.BankSuccess = false;
            var response = await _paymentRepository.Create(payment);

            return Ok(response);
        }
    }
}
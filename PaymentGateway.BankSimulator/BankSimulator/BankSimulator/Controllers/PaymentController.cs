using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSimulator.Models;
using Microsoft.AspNetCore.Mvc;
using CreditCardValidator;

namespace BankSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("", Name = "Payment")]
        [ProducesResponseType(typeof(Payment), 201)]
        public ActionResult<Payment> Post([FromBody] Payment payment)
        {
            var card = new CreditCardDetector(payment.CardNumber);

            if (card.IsValid())
            {
                payment.BankSuccess = true;
                payment.BankTransactionId = Guid.NewGuid().ToString();
            }

            return Ok(payment);
        }
    }
}

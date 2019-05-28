using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankSimulator.Models;
using Microsoft.AspNetCore.Mvc;

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
            var resp = new Payment();

            return Ok(resp);
        }
    }
}

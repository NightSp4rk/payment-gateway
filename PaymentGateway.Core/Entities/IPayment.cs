using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Entities
{
    public interface IPayment
    {
        Guid Id { get; set; }
    }
}

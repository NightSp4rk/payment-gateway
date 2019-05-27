using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PaymentGateway.Core.Requests;

namespace PaymentGateway.Core.Validators
{
    public sealed class ProcessPaymentValidator : AbstractValidator<ProcessPaymentRequest>
    {
        public ProcessPaymentValidator()
        {

        }
    }
}

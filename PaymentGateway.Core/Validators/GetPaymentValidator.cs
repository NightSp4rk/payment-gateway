using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PaymentGateway.Core.Requests;

namespace PaymentGateway.Core.Validators
{
    public sealed class GetPaymentValidator : AbstractValidator<GetPaymentRequest>
    {
        public GetPaymentValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty()
                .WithMessage("Product name is required")
                .WithErrorCode("901");
        }
    }
}

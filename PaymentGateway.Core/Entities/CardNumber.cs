using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Entities
{
    public class Card
    {
        private string cardNumber;

        public string CardNumber
        {
            get => cardNumber;
            set {
                cardNumber = value;
            }
        }
    }
}

using PaymentGateway.Core.Entities;
using PaymentGateway.Core.Requests;
using PaymentGateway.Infrastructure;
using PaymentGateway.WebApi.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Core.Tests
{
    public class PaymentTest
    {
        private readonly PaymentDbContext _paymentDbContext;

        public PaymentTest(PaymentDbContext paymentDbContext)
        {
            _paymentDbContext = paymentDbContext;
        }

        [Fact]
        public void TestGetPayment()
        {
            // Arrange
            var dbContext = _paymentDbContext;
            var repository = new PaymentRepository(dbContext);
            var controller = new PaymentController(repository);

            var guid = new Guid();
            var payment = new Payment
            {
                Id = guid,
                CardNumber = "4111 1111 1111 1111",
                CardHolderName = "John Doe",
                ExpiryYear = 2020,
                ExpiryMonth = 11,
                Amount = 2000,
                Currency = "USD",
                Cvv = "123",
                BankSuccess = true,
                BankTransactionId = new Guid().ToString()
            };
            
            _paymentDbContext.Payments.Add(payment);


            // Act
            var response = controller.Get(guid.ToString());
            var value = response.Value;

            _paymentDbContext.Payments.RemoveRange(_paymentDbContext.Payments);

            // Assert
            Assert.False(value == null);
            Assert.False(value.Id == null);
            Assert.False(value.BankSuccess == false);
        }

        [Fact]
        public async Task TestProcessPaymentAsync()
        {
            // Arrange
            var dbContext = _paymentDbContext;
            var repository = new PaymentRepository(dbContext);
            var controller = new PaymentController(repository);

            var request = new ProcessPaymentRequest
            {
                Id = new Guid(),
                CardNumber = "4111 1111 1111 1111",
                CardHolderName = "John Doe",
                ExpiryYear = 2020,
                ExpiryMonth = 11,
                Amount = 2000,
                Currency = "USD",
                Cvv = "123",
                BankSuccess = false
            };

            // Act
            var response = await controller.Post(request);

            // Assert
            Assert.True(response.Value.BankSuccess == true && response.Value.BankTransactionId != null);
            Assert.True(response.Value == _paymentDbContext.Payments.Find(response.Value.Id));
        }
    }
}

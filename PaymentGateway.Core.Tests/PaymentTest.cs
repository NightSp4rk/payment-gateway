using Microsoft.AspNetCore.Mvc;
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
        public void TestGePayment()
        {
            // Arrange
            var dbContext = _paymentDbContext;
            var repository = new PaymentRepository(dbContext);
            var controller = new PaymentController(repository);

            // Act
            var response = await controller.GetStockItemsAsync() as ObjectResult;
            var value = response.Value as IPagedResponse<StockItem>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestProcessPaymentAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetWideWorldImportersDbContext(nameof(TestPostStockItemAsync));
            var controller = new WarehouseController(null, dbContext);
            var request = new PostStockItemsRequest
            {
                StockItemID = 100,
                StockItemName = "USB anime flash drive - Goku",
                SupplierID = 12,
                UnitPackageID = 7,
                OuterPackageID = 7,
                LeadTimeDays = 14,
                QuantityPerOuter = 1,
                IsChillerStock = false,
                TaxRate = 15.000m,
                UnitPrice = 32.00m,
                RecommendedRetailPrice = 47.84m,
                TypicalWeightPerUnit = 0.050m,
                CustomFields = "{ \"CountryOfManufacture\": \"Japan\", \"Tags\": [\"32GB\",\"USB Powered\"] }",
                Tags = "[\"32GB\",\"USB Powered\"]",
                SearchDetails = "USB anime flash drive - Goku",
                LastEditedBy = 1,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now.AddYears(5)
            };

            // Act
            var response = await controller.PostStockItemAsync(request) as ObjectResult;
            var value = response.Value as ISingleResponse<StockItem>;

            dbContext.Dispose();

            // Assert
            Assert.False(value.DidError);
        }
    }
}

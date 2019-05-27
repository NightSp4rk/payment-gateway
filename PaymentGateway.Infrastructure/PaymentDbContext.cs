using Microsoft.EntityFrameworkCore;
using System;
using PaymentGateway.Core;
using PaymentGateway.Core.Entities;

namespace PaymentGateway.Infrastructure
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<IPayment> Payments { get; set; }
    }
}

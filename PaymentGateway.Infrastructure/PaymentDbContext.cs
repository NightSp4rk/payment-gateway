using Microsoft.EntityFrameworkCore;
using System;
using PaymentGateway.Core;

namespace PaymentGateway.Infrastructure
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using PaymentGateway.Core;
using PaymentGateway.Core.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections;

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

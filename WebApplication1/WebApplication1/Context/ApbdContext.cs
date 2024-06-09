using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplication1.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ApbdContext : DbContext
    {
        public ApbdContext() { }

        public ApbdContext(DbContextOptions<ApbdContext> options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new DiscountConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SubscriptionConfig());
        }

    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.IdPayment);
            builder.Property(e => e.Date);
            builder.Property(e=>e.Value);

            builder.HasOne(e => e.IdClientNavigation)
            .WithMany(e => e.Payments)
            .HasForeignKey(e => e.IdClient);

            builder.HasOne(e => e.IdSubscriptionNavigation)
            .WithMany(e => e.Payments)
            .HasForeignKey(e => e.IdSubscription);
        }
    }
}

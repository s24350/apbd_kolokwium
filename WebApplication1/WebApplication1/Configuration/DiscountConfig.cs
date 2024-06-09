using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class DiscountConfig : IEntityTypeConfiguration<Discount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(e => e.IdDiscount);
            builder.Property(e => e.Value);
            builder.Property(e=> e.DateFrom);
            builder.Property(e=> e.DateTo);

            builder.HasOne(e => e.IdSubscriptionNavigation)
            .WithMany(e => e.Discounts)
            .HasForeignKey(e => e.IdSubscription);
        }
    }
}

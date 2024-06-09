using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.IdSale);
            builder.Property(e => e.CreatedAt);
            builder.Property(e => e.IdSubscription);

            builder.HasOne(e => e.IdClientNavigation)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.IdClient);

            builder.HasOne(e => e.IdSubscriptionNavigation)
            .WithMany(e => e.Sales)
            .HasForeignKey(e => e.IdSubscription);


            //HasColumnType("Money")

        }
    }
}

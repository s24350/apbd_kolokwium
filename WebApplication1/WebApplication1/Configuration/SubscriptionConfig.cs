using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(e => e.IdSubscription);
            builder.Property(e => e.Name);
            builder.Property(e => e.Renewal);
            builder.Property(e => e.EndTime);
            builder.Property(e=> e.Price);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e=> e.IdClient);
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.EMail);

 


        }
    }
}

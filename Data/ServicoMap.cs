using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class ServiceMap : IEntityTypeConfiguration<ServiceModel>
    {
        public void Configure(EntityTypeBuilder<ServiceModel> builder)
        {
            builder.HasKey(x => x.serviceId);
            builder.Property(x => x.category).IsRequired().HasMaxLength(50);
            builder.Property(x => x.serviceName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.price).IsRequired().HasMaxLength(15);
            builder.Property(x => x.serviceDescription).HasColumnType("nvarchar(max)");
            builder.Property(x => x.dateCreated).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.dateModified).IsRequired().HasColumnType("datetime");

        }
    }
}

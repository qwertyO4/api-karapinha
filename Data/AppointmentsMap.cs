using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class AppointmentsMap : IEntityTypeConfiguration<AppointmentsModel>
    {
        public void Configure(EntityTypeBuilder<AppointmentsModel> builder)
        {
            builder.HasKey(x => x.appointmentId);
            builder.Property(x => x.userId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.professionalId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.serviceId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.date).HasColumnType("DATE");
            builder.Property(x => x.time).HasColumnType("TIME");
            builder.Property(x => x.status_appointment).IsRequired().HasMaxLength(50);
            builder.Property(x => x.totalPrice).IsRequired().HasMaxLength(15);
            builder.Property(x => x.dateCreated).IsRequired().HasMaxLength(80);
            builder.Property(x => x.dateModified).HasMaxLength(255);

        }
    }
}

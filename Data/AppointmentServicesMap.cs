using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class AppointmentServicesMap : IEntityTypeConfiguration<AppointmentServicesModel>
    {
        public void Configure(EntityTypeBuilder<AppointmentServicesModel> builder)
        {
            builder.HasKey(x => x.appointmentServiceId);
            builder.Property(x => x.appointmentId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.serviceId).IsRequired().HasMaxLength(50);

        }
    }
}

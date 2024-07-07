using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class ProfessionalsMap : IEntityTypeConfiguration<ProfessionalModel>
    {
        public void Configure(EntityTypeBuilder<ProfessionalModel> builder)
        {
            builder.HasKey(x => x.professionalsId);
            builder.Property(x => x.fullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.bi).IsRequired().HasMaxLength(14);
            builder.Property(x => x.photo).HasColumnType("VARBINARY(MAX)");
            builder.Property(x => x.workingHours).HasColumnType("nvarchar(max)");
            builder.Property(x => x.dateCreated).IsRequired().HasMaxLength(80);
            builder.Property(x => x.dateModified).HasMaxLength(80);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class EmailsMap : IEntityTypeConfiguration<EmailsModel>
    {
        public void Configure(EntityTypeBuilder<EmailsModel> builder)
        {

            builder.HasKey(x => x.emailId);
            builder.Property(x => x.to).IsRequired().HasMaxLength(255);
            builder.Property(x => x.subject).HasMaxLength(255);
            builder.Property(x => x.body).HasColumnType("nvarchar(max)");
            builder.Property(x => x.dateSent).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.statusEmail).IsRequired().HasMaxLength(50);

        }
    }
}

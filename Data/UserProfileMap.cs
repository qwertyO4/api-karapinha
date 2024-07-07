using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class UserProfileMap : IEntityTypeConfiguration<UserProfileModel>
    {
        public void Configure(EntityTypeBuilder<UserProfileModel> builder)
        {
            builder.HasKey(x => x.userId);
            builder.Property(x => x.photo).HasColumnType("VARBINARY(MAX)");
            builder.Property(x => x.additionalInfo).HasColumnType("nvarchar(max)");

        }
    }
}

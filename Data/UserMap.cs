using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Data
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.userId);
            builder.Property(x => x.fullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.bi).IsRequired().HasMaxLength(14);
            builder.Property(x => x.userName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.usertype).IsRequired().HasMaxLength(50);
            builder.Property(x => x.isActive).IsRequired().HasMaxLength(5);
            builder.Property(x => x.dateCreated).IsRequired().HasMaxLength(80);
            builder.Property(x => x.dateModified).HasMaxLength(255);

        }
    }
}

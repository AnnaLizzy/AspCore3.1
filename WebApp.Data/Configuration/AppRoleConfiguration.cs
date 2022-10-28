using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Data.Entities;

namespace WebApp.Data.Configuration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRole");
            builder.Property(x => x.Decreption).HasMaxLength(200)
                .IsRequired();
        }
    }
}

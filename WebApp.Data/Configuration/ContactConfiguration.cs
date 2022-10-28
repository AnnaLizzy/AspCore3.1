using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Data.Entities;

namespace WebApp.Data.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).UseIdentityColumn();//set thuoc tinh tu tang nhu Sql

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Message).IsRequired();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using webapp.data.entities;

namespace WebApp.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers").HasNoKey();

            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Dob).IsRequired();
        }
        
    }
}

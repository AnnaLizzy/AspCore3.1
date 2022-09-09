//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using WebApp.Data.Entities;

//namespace WebApp.Data.Configuration
//{
//    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
//    {
//        public void Configure(EntityTypeBuilder<AppUser> builder)
//        {
//            builder.ToTable("AppUsers").HasNoKey();

//            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(500);
//            builder.Property(x => x.LastName).IsRequired().HasMaxLength(500);
//            builder.Property(x => x.Dob).IsRequired();
//        }
//    }
//}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.Configuration;
using WebApp.Data.Entities;
using WebApp.Data.Extensions;

namespace WebApp.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config fluant API
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            
            modelBuilder.ApplyConfiguration(new AppConfigConfiguation());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new
                {
                    x.RoleId,
                    x.UserId
                });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins")
                .HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserUserTokens")
                .HasKey(x=> x.UserId);

            //Data Seeding
            modelBuilder.Seed();


            //base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

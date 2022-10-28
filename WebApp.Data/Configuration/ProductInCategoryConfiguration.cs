using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Data.Entities;

namespace WebApp.Data.Configuration
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new { t.ProductId, t.CategoryId });

            builder.ToTable("ProductInCategories");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(pc => pc.ProductId);
            builder.HasOne(t => t.Category).WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(pc => pc.CategoryId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIIntro.Data.Entities;

namespace WebAPIIntro.Data.Configurations
{
  // Fluent API yöntemi diyoruz
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Name).HasMaxLength(200);

      // relation

      builder.HasOne<Category>(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);


    }
  }
}

using Microsoft.EntityFrameworkCore;
using WebAPIIntro.Data.Configurations;
using WebAPIIntro.Data.Entities;

namespace WebAPIIntro.Data
{
  public class ApplicationContext:DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> opts):base(opts)
    {
      // opts ile farklı konfig işlemleri uygulayabiliriz.
      // useSqlServer, useNgpl, useMySql, useInmemory, UseSqlLite
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      // modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(500);

      modelBuilder.ApplyConfiguration(new ProductConfiguration());


      base.OnModelCreating(modelBuilder);
    }
  }
}

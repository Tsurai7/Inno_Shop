namespace Inno_Shop.Services.Products.Infrastructure.Data
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

    }
}

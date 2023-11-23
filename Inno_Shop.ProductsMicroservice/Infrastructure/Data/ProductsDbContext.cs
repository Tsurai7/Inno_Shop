namespace Inno_Shop.Services.Products.Infrastructure.Data
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) 
            : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=products;Trusted_Connection=True;");
        }
    }
}

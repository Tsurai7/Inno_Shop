namespace Inno_Shop.Services.Products.Domain.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private bool _disposed = false;
        private readonly ProductsDbContext _context;

        public ProductRepository(ProductsDbContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();


        public async Task<Product> GetByIdAsync(long id) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Id == id);


        public async Task<Product> GetByTitleAsync(string title) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Title == title);


        public async Task AddAsync(Product product)
        {
            product.CreatedAt = DateTime.Now;
            await _context.Products.AddAsync(product);
        }


        public async Task UpdateAsync(Product product)
        {
            var productFromDb = await _context.Products.FindAsync(new object[] { product.Id });

            if (productFromDb == null)
                return;

            productFromDb.Title = product.Title;
            productFromDb.Description = product.Description;
            productFromDb.Price = product.Price;
            productFromDb.UpdatedAt = DateTime.Now;
        }


        public async Task DeleteAsync(long id)
        {
            var productFromDb = await _context.Products.FindAsync(new object[] { id });

            if (productFromDb == null)
                return;

            _context.Remove(productFromDb);
        }


        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

namespace Inno_Shop.Services.Products.Application.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task<Product> GetByTitleAsync(string title);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(long id);

        Task<List<Product>> GetFilteredAsync(ProductFilterDto filterParameters);
    }    
}

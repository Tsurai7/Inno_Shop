using Inno_Shop.Services.Products.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.Services.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync() => 
            await _repository.GetAllAsync();

        public async Task<Product> GetByIdAsync(long id) =>
            await _repository.GetByIdAsync(id);

        public async Task<Product> GetByTitleAsync(string title) => 
            await _repository.GetByTitleAsync(title);

        public async Task AddAsync(Product product) => 
            await _repository.AddAsync(product);

        public async Task UpdateAsync(Product product) => 
            await _repository.UpdateAsync(product);

        public async Task DeleteAsync(long id) => 
            await _repository.DeleteAsync(id);

        public async Task<List<Product>> GetFilteredAsync(ProductFilterDto filterParameters)
        {
            var allProducts = await _repository.GetAllAsync();
            var filteredProducts = ApplyFilters(allProducts, filterParameters);
            return filteredProducts;
        }

        private List<Product> ApplyFilters(List<Product> products, ProductFilterDto filterParameters)
        {
            var query = products.AsQueryable();

            if (!string.IsNullOrEmpty(filterParameters.Title))       
                query = query.Where(p => p.Title.Contains(filterParameters.Title));
            

            if (filterParameters.MinPrice.HasValue)        
                query = query.Where(p => p.Price >= filterParameters.MinPrice.Value);
            

            if (filterParameters.MaxPrice.HasValue)       
                query = query.Where(p => p.Price <= filterParameters.MaxPrice.Value);
            

            if (filterParameters.IsAvaiable.HasValue)         
                query = query.Where(p => p.IsAvaiable == filterParameters.IsAvaiable.Value);
            

            if (filterParameters.CreatedAtStart.HasValue)         
                query = query.Where(p => p.CreatedAt >= filterParameters.CreatedAtStart.Value);
            

            if (filterParameters.CreatedAtEnd.HasValue)
                query = query.Where(p => p.CreatedAt <= filterParameters.CreatedAtEnd.Value);

            return query.ToList();
        }
    }
}

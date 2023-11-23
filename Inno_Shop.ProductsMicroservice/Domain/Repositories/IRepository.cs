namespace Inno_Shop.Services.Products.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByTitleAsync(string title);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}

namespace Inno_Shop.Services.Products.Domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByTitleAsync(string title);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}

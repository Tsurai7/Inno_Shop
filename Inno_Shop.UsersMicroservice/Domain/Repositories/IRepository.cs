namespace Inno_Shop.UsersMicroservice.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
        Task SaveAsync();
    }
}
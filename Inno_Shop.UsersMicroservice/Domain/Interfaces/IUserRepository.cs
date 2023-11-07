using Inno_Shop.UsersMicroservice.Domain.Models;

namespace Inno_Shop.UsersMicroservice.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task SaveAsync();
    }
}

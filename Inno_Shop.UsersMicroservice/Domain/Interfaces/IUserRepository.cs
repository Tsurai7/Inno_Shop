using Inno_Shop.UsersMicroservice.Domain.Models;

namespace Inno_Shop.UsersMicroservice.Domain.Interfaces
{
    public interface IUserRepository
    {
        User AuthUser(string email, string password);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task SaveAsync();
    }
}

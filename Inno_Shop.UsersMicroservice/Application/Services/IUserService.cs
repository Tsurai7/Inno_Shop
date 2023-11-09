using Inno_Shop.UsersMicroservice.Domain.Models;

namespace Inno_Shop.UsersMicroservice.Application.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}

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
        Task SaveAsync();
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> VerifyPasswordAsync(User user, string password);
        Task<bool> ChangePasswordAsync(User user, string newPassword);
        Task<bool> ResetPasswordAsync(User user, string newPassword);
        Task<bool> ConfirmEmailAsync(User user, string token);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
    }
}

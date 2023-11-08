using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Inno_Shop.UsersMicroservice.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }


        Task<List<User>> GetAllUsersAsync()
        {

        }


        Task<User> GetUserAsync(int id)
        {

        }


        Task AddUserAsync(User user)
        {

        }


        Task UpdateUserAsync(User user)
        {

        }


        Task DeleteUserAsync(int id)
        {

        }


        Task SaveAsync()
        {

        }


        Task<bool> IsEmailUniqueAsync(string email)
        {

        }


        Task<bool> VerifyPasswordAsync(User user, string password)
        {

        }


        Task<bool> ChangePasswordAsync(User user, string newPassword)
        {

        }


        Task<bool> ResetPasswordAsync(User user, string newPassword)
        {

        }


        Task<bool> ConfirmEmailAsync(User user, string token)
        {

        }


        Task<bool> IsEmailConfirmedAsync(User user)
        {

        }


        Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {

        }


        Task<string> GeneratePasswordResetTokenAsync(User user)
        {

        }
    }
}

using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Domain.Models;
using Inno_Shop.UsersMicroservice.Infrastucture.Repositories;
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


        public async Task<List<User>> GetAllUsersAsync() =>
            await _userRepository.GetAllUsersAsync();



        public async Task<User> GetUserAsync(int id) =>
           await _userRepository.GetUserAsync(id);



        public async Task AddUserAsync(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveAsync();
        }


        public async Task UpdateUserAsync(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
        }


        public async Task DeleteUserAsync(int id) => 
            await _userRepository.DeleteUserAsync(id);

    }
}

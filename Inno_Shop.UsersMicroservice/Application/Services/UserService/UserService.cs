using Inno_Shop.Services.Users.Domain.Models.Entities;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;

namespace Inno_Shop.UsersMicroservice.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<List<User>> GetAllAsync() =>
            await _userRepository.GetAllAsync();


        public async Task<User> GetByIdAsync(long id) =>
           await _userRepository.GetByIdAsync(id);

        public async Task<User> GetByEmailAsync(string email) =>
            await _userRepository.GetByEmailAsync(email);

        public async Task<User> GetByTokenAsync(string token) =>
            await _userRepository.GetByTokenAsync(token);


        public async Task AddAsync(User user)
        {
            //user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }


        public async Task UpdateAsync(User user)
        {
            //user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveAsync();
        }


        public async Task DeleteAsync(long id) =>
            await _userRepository.DeleteAsync(id);

    }
}

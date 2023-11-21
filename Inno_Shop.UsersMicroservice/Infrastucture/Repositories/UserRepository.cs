using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Domain.Models;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using Inno_Shop.UsersMicroservice.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.UsersMicroservice.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private bool _disposed = false;
        private readonly UsersDb _context;

        public UserRepository(UsersDb context)
        {
            _context = context;
        }


        public async Task<List<User>> GetAllUsersAsync() =>
            await _context.Users.ToListAsync();


        public async Task<User> GetUserAsync(int id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


        public async Task<User> GetUserAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public User AuthUser(string email, string password) =>
             _context.Users.FirstOrDefault(u =>
            string.Equals(u.Email, email) &&
            string.Equals(u.Password, password)) ??
            throw new Exception();

        public async Task AddUserAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            await _context.Users.AddAsync(user);
        }
           

        public async Task UpdateUserAsync(User user)
        {
            var userFromDb = await _context.Users.FindAsync(new object[] { user.Id });

            if (userFromDb == null) 
                return;

            userFromDb.Name = user.Name;
            userFromDb.Email = user.Email;
            userFromDb.Password = user.Password;
        }



        public async Task DeleteUserAsync(int id)
        {
            var userFromDb = await _context.Users.FindAsync(new object[] { id });

            if (userFromDb == null) 
                return;

            _context.Remove(userFromDb);
        }


        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
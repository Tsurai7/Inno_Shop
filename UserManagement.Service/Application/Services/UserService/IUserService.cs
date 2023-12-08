﻿using Inno_Shop.Services.Users.Domain.Models.Entities;

namespace Inno_Shop.UsersMicroservice.Application.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(long id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByTokenAsync(string token);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(long id);
    }
}

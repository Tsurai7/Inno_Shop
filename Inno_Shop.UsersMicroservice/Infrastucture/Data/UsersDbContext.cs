using Inno_Shop.UsersMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.UsersMicroservice.Infrastucture.Data
{
    public class UsersDb : DbContext
    {
        public UsersDb(DbContextOptions<UsersDb> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
    }
}

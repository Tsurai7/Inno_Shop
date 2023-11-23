using Inno_Shop.Services.Users.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.UsersMicroservice.Infrastucture.Data
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public UsersDbContext(DbContextOptions<UsersDbContext> options) 
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=users;Trusted_Connection=True;");
        }
    }
}

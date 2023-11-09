using Inno_Shop.UsersMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.UsersMicroservice.Infrastucture.Data
{
    public class UsersDb : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UsersDb(DbContextOptions<UsersDb> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom", Email = "john.doe@example.com", Password = "secretPassword1", CreatedAt = DateTime.Now },
                    new User { Id = 2, Name = "Bob", Email = "bob@example.com", Password = "qwqweqw123123", CreatedAt = DateTime.Now },
                    new User { Id = 3, Name = "Sam", Email = "sam@example.com", Password = "gfhgf45", CreatedAt = DateTime.Now }
            );
        }
    }
}

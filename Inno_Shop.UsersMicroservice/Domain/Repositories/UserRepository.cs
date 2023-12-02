namespace Inno_Shop.Services.Users.Domain.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private bool _disposed = false;
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();


        public async Task<User> GetByIdAsync(long id) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


        public async Task<User> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);


        public async Task<User> GetByToken(string token) =>
            await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);


        public async Task AddAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            await _context.Users.AddAsync(user);
        }


        public async Task UpdateAsync(User user)
        {
            var userFromDb = await _context.Users.FindAsync(new object[] { user.Id });

            if (userFromDb == null)
                return;

            userFromDb.Name = user.Name;
            userFromDb.Email = user.Email;
            userFromDb.UpdatedAt = DateTime.Now;
        }


        public async Task DeleteAsync(long id)
        {
            var userFromDb = await _context.Users.FindAsync(new object[] { id });

            if (userFromDb == null)
                return;

            _context.Remove(userFromDb);
        }


        public async Task SaveAsync() => 
            await _context.SaveChangesAsync();


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
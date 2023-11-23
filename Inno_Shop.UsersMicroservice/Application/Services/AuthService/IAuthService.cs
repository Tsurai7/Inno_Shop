namespace Inno_Shop.Services.Users.Application.Services.AuthService
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    }
}

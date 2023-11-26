namespace Inno_Shop.UsersMicroservice.Application.Services.TokenService
{
    public interface ITokenService
    {
        public string BuildToken(string UserName);
    }
}
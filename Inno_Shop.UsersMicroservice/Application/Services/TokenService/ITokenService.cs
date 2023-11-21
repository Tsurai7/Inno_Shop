using Inno_Shop.UsersMicroservice.Domain.Models;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;

namespace Inno_Shop.UsersMicroservice.Application.Services.TokenService
{
    public interface ITokenService
    {
        public string BuildToken(string key, string issuer, User user);
    }
}

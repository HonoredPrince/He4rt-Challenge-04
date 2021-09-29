using System.Threading.Tasks;
using Api.Domain.DTOs.Token;
using Api.Domain.DTOs.User;

namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<TokenDTO> ValidateCredentials(UserLoginDTO user);
        Task<TokenDTO> ValidateCredentials(TokenDTO token);
        Task<bool> RevokeToken(string email);
    }
}

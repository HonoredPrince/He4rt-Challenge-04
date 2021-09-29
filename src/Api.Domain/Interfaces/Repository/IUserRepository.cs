using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> ValidateCredentials(UserEntity user);
        Task<UserEntity> ValidateCredentials(string email);
        Task<UserEntity> RefreshUserInfo(UserEntity user);
        Task<bool> RevokeToken(string email);
    }
}

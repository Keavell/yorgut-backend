using Yogurt.Domain.Entities.User;

namespace Yogurt.Infraestructure.Interfaces.User
{
    public interface IUserRepository : IRepositoryAsync<UserEntity>
    {
        Task<UserEntity?> GetByEmail(string email);

        Task<UserEntity?> GetByUsername(string userName);

        Task<UserEntity?> GetByToken(string token);

        void UpdateToken(string token, UserEntity entity);

        void UpdatePassword(string password, UserEntity entity);
    }
}

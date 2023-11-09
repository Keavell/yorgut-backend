using Yogurt.Domain.Entities.User;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces.User;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories.User
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(YogurtContext context) : base(context)
        {
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return YogurtContext.Set<UserEntity>().FirstOrDefault(x => x.Email == email);
        }

        public async Task<UserEntity?> GetByUsername(string userName)
        {
            return YogurtContext.Set<UserEntity>().FirstOrDefault(x => x.UserName == userName);
        }

        public async Task<UserEntity?> GetByToken(string token)
        {
            return YogurtContext.Set<UserEntity>().FirstOrDefault(x => x.Token == token);
        }

        public void UpdateToken(string token, UserEntity entity)
        {
            try
            {
                var result = YogurtContext.Usuario.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Token = token;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o token no banco de dados. /n StackTrace: {ex}");
            }
        }

        public void UpdatePassword(string password, UserEntity entity)
        {
            try
            {
                var result = YogurtContext.Usuario.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Password = password;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar a senha no banco de dados. /n StackTrace: {ex}");
            }
        }
    }
}

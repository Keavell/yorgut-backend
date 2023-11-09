using Microsoft.EntityFrameworkCore;
using Yogurt.Domain.Entities;
using Yogurt.Domain.Entities.Base;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories
{
    public class ProfileUserRepository : RepositoryBase<ProfileUserEntity>, IProfileUserRepository 
    {
        public ProfileUserRepository(YogurtContext context) : base(context)
        {          
        }

        public async Task<ProfileUserEntity> GetById(Guid id)
        {
            return (await YogurtContext.Set<ProfileUserEntity>().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<ProfileUserEntity?> GetByUserName(string userName)
        {
            return YogurtContext.Set<ProfileUserEntity>().FirstOrDefault(x => x.Nome == userName);
        }
        public async Task<ProfileUserEntity?> GetByBiography(string? biography)
        {
            return YogurtContext.Set<ProfileUserEntity>().FirstOrDefault(x => x.Biografia == biography);
        }

        //public async Task<ProfileUserEntity?> GetByCity(string city)
        //{
        //    return YogurtContext.Set<ProfileUserEntity>().Join;
        //}

        public async Task<ProfileUserEntity?> GetByProfilePhoto(byte[]? profilePhoto)
        {
            return YogurtContext.Set<ProfileUserEntity>().FirstOrDefault(x => x.FotoPerfil == profilePhoto);
        }

        public void UpdateUserName(string userName, ProfileUserEntity entity)
        {
            try
            {
                var result = YogurtContext.Perfil.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Nome = userName;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o userName.");
            }
        }

        public void UpdateBiography(string? biography, ProfileUserEntity entity)
        {
            try
            {
                var result = YogurtContext.Perfil.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Biografia = biography;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar a biografia.");
            }
        }

        public void UpdateCity(int? city, ProfileUserEntity entity)
        {
            try
            {
                var result = YogurtContext.Perfil.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.IdCidade = city;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o município.");
            }
        }

        public void UpdateProfilePhoto(byte[]? profilePhoto, ProfileUserEntity entity)
        {
            try
            {
                var result = YogurtContext.Perfil.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.FotoPerfil = profilePhoto;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar a foto de perfil.");
            }
        }
    }
}

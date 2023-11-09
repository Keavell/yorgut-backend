using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface IProfileUserRepository : IRepositoryAsync<ProfileUserEntity>
    {
        Task<ProfileUserEntity?> GetById(Guid id);

        Task<ProfileUserEntity?> GetByUserName(string userName);

        Task<ProfileUserEntity?> GetByBiography(string? biography);

        //Task<ProfileUserEntity?> GetByCity(string city);

        Task<ProfileUserEntity?> GetByProfilePhoto(byte[]? profilePhoto);        

        void UpdateUserName(string userName, ProfileUserEntity entity);

        void UpdateBiography(string? biography, ProfileUserEntity entity);

        void UpdateCity(int? city, ProfileUserEntity entity);

        void UpdateProfilePhoto(byte[]? profilePhoto, ProfileUserEntity entity);
    }
}

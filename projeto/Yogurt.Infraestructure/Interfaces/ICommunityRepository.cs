using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface ICommunityRepository : IRepositoryAsync<CommunityEntity>
    {
        Task<CommunityEntity?> GetByGuid(Guid id);

        void UpdateName(string nome, CommunityEntity entity);

        void UpdateSubtitle(string legenda, CommunityEntity entity);

        void UpdateImage(byte[] imagem, CommunityEntity entity);
    }
}

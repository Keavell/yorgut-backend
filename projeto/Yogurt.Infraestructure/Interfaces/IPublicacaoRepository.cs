using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces.Publication;

public interface IPublicacaoRepository : IRepositoryAsync<PublicacaoEntity>
{
    public Task<List<PublicacaoEntity>> GetByLegenda(string legenda);

    public Task<bool> Update(Guid id, string legenda);

    public Task<List<PublicacaoEntity>> GetAll();

    public Task<bool> Delete(Guid id);

    Task<int> IncrementarCurtidas(PublicacaoEntity publicacaoEntity);

    Task<int> DecrementarCurtidas(PublicacaoEntity publicacao);
}
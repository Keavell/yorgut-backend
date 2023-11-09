using Yogurt.Application.Dto;

namespace Yogurt.Application.Interfaces.Publication;

public interface IPublicacaoService
{
    public Task<ReturnDto> Insert(string legenda, Guid usuarioId, Guid? comunidadeId);

    public Task<ReturnDto> GetById(Guid id);

    public Task<ReturnDto> GetAll();

    public Task<ReturnDto> GetByLegenda(string legenda);

    public Task<ReturnDto> Update(Guid id, string legenda);

    Task<ReturnDto> Delete(Guid id);

    public Task<int> IncrementarCurtidas(Guid id);

    public Task<int> DecrementarCurtidas(Guid id);

    public Task<ReturnDto> SharePublication(Guid id, Guid usuarioId, string legenda);
}
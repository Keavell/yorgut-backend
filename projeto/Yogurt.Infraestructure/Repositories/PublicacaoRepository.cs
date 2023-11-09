using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces.Publication;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories;

public sealed class PublicacaoRepository : RepositoryBase<PublicacaoEntity>, IPublicacaoRepository
{
    public PublicacaoRepository(YogurtContext yogurtContext) : base(yogurtContext)
    {
    }

    public Task<List<PublicacaoEntity>> GetByLegenda(string legenda)
    {
        return Task.FromResult(YogurtContext.Set<PublicacaoEntity>().AsQueryable()
            .Where(x => x.Legenda != null && x.Legenda.Contains(legenda)).ToList());
    }

    public async Task<bool> Update(Guid id, string legenda)
    {
        var entity = YogurtContext.Set<PublicacaoEntity>().AsQueryable().FirstOrDefault(x => x.Id == id);

        if (entity == null) return false;

        entity.Legenda = legenda;
        entity.DataCriacao = DateTime.Now;
        var save = await YogurtContext.SaveChangesAsync();

        return save != 0;
    }

    public Task<List<PublicacaoEntity>> GetAll()
    {
        return Task.FromResult(YogurtContext.Set<PublicacaoEntity>().AsQueryable().ToList());
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = YogurtContext.Set<PublicacaoEntity>().AsQueryable().FirstOrDefault(x => x.Id == id);

        if (entity == null) return false;

        YogurtContext.Set<PublicacaoEntity>().Remove(entity);
        var delete = await YogurtContext.SaveChangesAsync();

        return delete != 0;
    }

    public async Task<int> IncrementarCurtidas(PublicacaoEntity publicacaoEntity)
    {
        var curtidas = publicacaoEntity.Curtidas++;
        await YogurtContext.SaveChangesAsync();

        return curtidas;
    }

    public async Task<int> DecrementarCurtidas(PublicacaoEntity publicacaoEntity)
    {
        var curtidas = publicacaoEntity.Curtidas--;

        if (curtidas < 0)
            curtidas = 0;

        await YogurtContext.SaveChangesAsync();

        return curtidas;
    }
}
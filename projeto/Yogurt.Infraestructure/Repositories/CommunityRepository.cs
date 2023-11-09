using Microsoft.EntityFrameworkCore;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories
{
    public class CommunityRepository : RepositoryBase<CommunityEntity>, ICommunityRepository
    {
        public CommunityRepository(YogurtContext context) : base(context)
        {
        }
        public async Task<CommunityEntity?> GetByGuid(Guid id)
        {
            return await YogurtContext.Set<CommunityEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateName(string nome, CommunityEntity entity)
        {
            try
            {
                var result = YogurtContext.Comunidade.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Nome = nome;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o token no banco de dados. /n StackTrace: {ex}");
            }
        }

        public void UpdateSubtitle(string legenda, CommunityEntity entity)
        {
            try
            {
                var result = YogurtContext.Comunidade.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.Legenda = legenda;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o token no banco de dados. /n StackTrace: {ex}");
            }
        }

        public void UpdateImage(byte[] imagem, CommunityEntity entity)
        {
            try
            {
                var result = YogurtContext.Comunidade.FirstOrDefault(item => item.Id == entity.Id);

                if (entity != null)
                {
                    entity.FotoComunidade = imagem;
                    YogurtContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar o token no banco de dados. /n StackTrace: {ex}");
            }
        }
    }
}

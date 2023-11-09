using Microsoft.EntityFrameworkCore;
using Yogurt.Domain.Entities.Base;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Infraestructure.Repositories.BaseRepository
{
    public abstract class RepositoryBase<T> : IRepositoryAsync<T> where T : EntityBase
    {
        private readonly YogurtContext _yogurtContext;

        public YogurtContext YogurtContext => _yogurtContext;

        public RepositoryBase(YogurtContext yogurtContext)
        {
            _yogurtContext = yogurtContext;
        }

        public async Task Insert(T entity)
        {
            await _yogurtContext.Set<T>().AddAsync(entity);
            await _yogurtContext.SaveChangesAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _yogurtContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveByEntity(T entity)
        {
            _yogurtContext.Remove(entity);
            await _yogurtContext.SaveChangesAsync();
        }
    }
}

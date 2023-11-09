namespace Yogurt.Infraestructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task Insert(T entity);

        Task<T?> GetById(Guid id);

        Task RemoveByEntity(T entity);
    }
}

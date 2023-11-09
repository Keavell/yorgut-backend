using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface ICommentRepository : IRepositoryAsync<CommentEntity>
    {
        Task<CommentEntity?> GetByGuid(Guid id);

        Task<int> UpdateLike(int like, CommentEntity entity);

    }
}

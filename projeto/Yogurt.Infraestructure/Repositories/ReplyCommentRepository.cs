using Yogurt.Domain.Entities.ReplyComment;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories
{
    public class ReplyCommentRepository : RepositoryBase<ReplyCommentEntity>, IReplyCommentRepository
    {
        public ReplyCommentRepository(YogurtContext context) : base(context)
        {
        }
    }
}

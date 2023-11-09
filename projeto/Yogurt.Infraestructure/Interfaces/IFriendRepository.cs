using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface IFriendRepository: IRepositoryAsync<ConnectEntity>
    {
        Task<FriendEntity?> CatchFriend(Guid id);

        Task<List<ConnectEntity?>> GetAllConnect(Guid id);

        Task InsertFriend(FriendEntity entity);
    }
}

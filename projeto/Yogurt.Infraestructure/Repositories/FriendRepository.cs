using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Context;
using Yogurt.Infraestructure.Interfaces;
using Yogurt.Infraestructure.Repositories.BaseRepository;

namespace Yogurt.Infraestructure.Repositories
{
    public class FriendRepository : RepositoryBase<ConnectEntity>, IFriendRepository
    {
        public FriendRepository(YogurtContext context) : base(context)
        {

        }

        public async Task<FriendEntity?> CatchFriend(Guid id)
        {
            return YogurtContext.Amizade.FirstOrDefault(x => x.IdPerfil == id);
        }

        public async Task<List<ConnectEntity?>> GetAllConnect(Guid id)
        {
            return  YogurtContext.Conectar.Where(x => x.IdPerfil == id).ToList();
        }

        public async Task InsertFriend(FriendEntity entity)
        {
            await YogurtContext.Amizade.AddAsync(entity);
            await YogurtContext.SaveChangesAsync();
        }
    }
}

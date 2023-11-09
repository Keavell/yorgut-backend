using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Dto;

namespace Yogurt.Application.Interfaces
{
    public interface IFriendService
    {
        Task<ReturnDto> DeleteFriend(Guid? idConnect);

        Task<ReturnDto> InsertFriend(Guid? idPerfil, Guid? idPerfilPretendido);

        Task<ReturnDto> GetFriend(Guid? idPerfil);

        Task<ReturnDto> InsertPointPerfil(Guid? idPerfilPretendido);
    }
}

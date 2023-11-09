using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Dto;

namespace Yogurt.Application.Interfaces
{
    public interface IConnectivityService
    {
        Task<ReturnDto> InsertConnectivity(Guid? idPerfil, Guid? idCommunity);

        Task<ReturnDto> DeleteConnectivity(Guid? idConnectivity);

        Task<ReturnDto> GetCommunityConnectivity(Guid? idCommunity);

        Task<ReturnDto> GetPerfilConnectivity(Guid? idPerfil);
    }
}

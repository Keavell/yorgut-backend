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
    public class ConnectivityRepository : RepositoryBase<ConnectivityEntity>, IConnectivityRepository
    {
        public ConnectivityRepository(YogurtContext yogurtContext) : base(yogurtContext)
        {
        }

        public async Task<List<ConnectivityEntity?>> GetByCommunity(Guid id)
        {
            return YogurtContext.Conectividade.Where(x=>x.IdComunidade== id).ToList();
        }

        public async Task<List<ConnectivityEntity?>> GetByPerfil(Guid id)
        {
            return YogurtContext.Conectividade.Where(x => x.IdPerfil == id).ToList();
        }
    }
}

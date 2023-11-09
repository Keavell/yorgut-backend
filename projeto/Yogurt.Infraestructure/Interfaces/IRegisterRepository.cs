using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities;
using Yogurt.Domain.Entities.User;

namespace Yogurt.Infraestructure.Interfaces
{
    public interface IRegisterRepository
    {
        Task<Guid> InsertUser(UserEntity entity);

        Task<Guid> InsertProfile(ProfileUserEntity entity);

        Task InsertConnect(Guid id);
    }
}

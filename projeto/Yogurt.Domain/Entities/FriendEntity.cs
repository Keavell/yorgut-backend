using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities
{
    public class FriendEntity: EntityBase
    {
        public Guid IdPerfil { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual ProfileUserEntity Perfil { get; set; }

        public virtual ICollection<ConnectEntity> Connects { get; set; }
    }
}

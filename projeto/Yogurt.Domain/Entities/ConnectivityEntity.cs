using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities
{
    public class ConnectivityEntity : EntityBase
    {
        public Guid IdPerfil { get; set; }

        public Guid IdComunidade { get; set; }

        public DateTime DataCriacao { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual ProfileUserEntity Perfil { get; set; }

        [ForeignKey("IdComunidade")]
        public virtual CommunityEntity Comunidade { get; set; }

        public ConnectivityEntity(){}

        public ConnectivityEntity(Guid idPerfil, Guid idComunidade)
        {
            IdPerfil = idPerfil;
            IdComunidade = idComunidade;
        }
    }
}

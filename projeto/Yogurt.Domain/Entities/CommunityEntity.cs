using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities
{
    public class CommunityEntity : EntityBase
    {
        public Guid IdCriador { get; set; }

        public Guid IdCategoriaComunidade { get; set; }

        public string? Nome { get; set; }

        public string? Legenda { get; set; }

        public byte[] FotoComunidade { get; set; }

        public DateTime DataCriacao { get; set; }

        public virtual ICollection<PublicacaoEntity> Publicacoes { get; set; }

        public virtual ICollection<ConnectivityEntity> Conectividades { get; set; }

        public CommunityEntity(Guid idCriador, Guid idCategoriaComunidade, string? nome, string? legenda, byte[] fotoComunidade, DateTime dataCriacao)
        {
            IdCriador = idCriador;
            IdCategoriaComunidade = idCategoriaComunidade;
            Nome = nome;
            Legenda = legenda;
            FotoComunidade = fotoComunidade;
            DataCriacao = dataCriacao;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Domain.Entities.Base;
using Yogurt.Domain.Entities.ReplyComment;

namespace Yogurt.Domain.Entities
{
    public class CommentEntity : EntityBase
    {
        public Guid IdPublicacao { get; set; }

        public string? Legenda { get; set; }

        public int Curtidas { get; set; }

        public DateTime DataCriacao { get; set; }

        [ForeignKey("IdPublicacao")]
        public virtual PublicacaoEntity PublicacaoEntity { get; set; }

        public virtual ICollection<ReplyCommentEntity> ReplyCommentEntities { get; set; }

        public CommentEntity() { }

        public CommentEntity(Guid idPublicacao, string? legenda, int curtidas, DateTime data_Criacao)
        {
            IdPublicacao = idPublicacao;
            Legenda = legenda;
            Curtidas = curtidas;
            DataCriacao = data_Criacao;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities.ReplyComment
{
    public class ReplyCommentEntity : EntityBase
    {
        public Guid IdComentario { get; set; }

        public string? Legenda { get; set; }

        public DateTime DataCriacao { get; set; }

        [ForeignKey("IdComentario")]
        public virtual CommentEntity comment { get; set; }

        public ReplyCommentEntity() { }

        public ReplyCommentEntity(Guid id_Comentarios, string? legenda, DateTime data_Criacao)
        {
            IdComentario = id_Comentarios;
            Legenda = legenda;
            DataCriacao = data_Criacao;
        }

        public ReplyCommentEntity(string? legenda, DateTime data_Criacao)
        {
            Legenda = legenda;
            DataCriacao = data_Criacao;
        }
    }
}
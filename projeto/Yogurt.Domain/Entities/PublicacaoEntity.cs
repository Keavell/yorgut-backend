using System.ComponentModel.DataAnnotations.Schema;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities;

public class PublicacaoEntity : EntityBase
{

    public Guid IdPerfil { get; set; }

    public Guid? IdComunidade { get; set; }

    public string? Legenda { get; set; }

    public int Curtidas { get; set; }

    public DateTime DataCriacao { get; set; }

    [ForeignKey("IdPerfil")]
    public virtual ProfileUserEntity Perfil { get; set; }

    [ForeignKey("IdComunidade")]
    public virtual CommunityEntity Comunidade { get; set; }

    public virtual ICollection<FileEntity> FileEntities { get; set; }

    public virtual ICollection<CommentEntity> CommentEntities { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using Yogurt.Domain.Entities.Base;
using Yogurt.Domain.Entities.User;

namespace Yogurt.Domain.Entities
{
    public class ProfileUserEntity : EntityBase
    {

        public string Nome { get; set; } 

        public DateTime? DataNascimento { get; set; }

        public byte[]? FotoPerfil { get; set; }

        public string? Biografia { get; set; }

        public string? Genero { get; set; } 

        public DateTime DataCriacao { get; set; }

        public Guid IdUsuario { get; set; }

        public int? IdCidade { get; set; }


        [ForeignKey("IdUsuario")]
        public virtual UserEntity Usuario { get; set; }

        [ForeignKey("IdCidade")]
        public virtual CityEntity Cidade { get; set; }

        public virtual ICollection<FriendEntity> Amigos { get; set; }

        public virtual ICollection<ConnectEntity> Connects { get; set; }

        public virtual ICollection<PublicacaoEntity> Publicacoes { get; set; }

        public virtual ICollection<ConnectivityEntity> Conectividades { get; set; }

        public ProfileUserEntity() { }

        public ProfileUserEntity(Guid idUsuario, int idCidade, string nome, DateTime dataNascimento, byte[]? fotoPerfil, string? biografia, string? genero)
        {
            IdUsuario = idUsuario;
            IdCidade = idCidade;
            Nome = nome;
            DataNascimento = dataNascimento;
            FotoPerfil = fotoPerfil;
            Biografia = biografia;
            Genero = genero;
        }      

    }
}

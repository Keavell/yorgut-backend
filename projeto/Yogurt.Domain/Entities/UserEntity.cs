using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yogurt.Domain.Entities.Base;

namespace Yogurt.Domain.Entities.User
{
    public class UserEntity : EntityBase
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? UserName { get; set; }

        public string? Telefone { get; set; }

        public string? Token { get; set; }

        public virtual ProfileUserEntity Perfil { get; set; }

        public UserEntity() { }

        public UserEntity(string? token)
        {
            Token = token;
        }

        public UserEntity(string? email, string? password, string? userName, string? telefone)
        {
            Email = email;
            Password = password;
            UserName = userName;
            Telefone = telefone;
        }
    }
}

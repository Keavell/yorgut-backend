namespace CadastroUsuario.Application.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UsuarioDto(Guid id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}

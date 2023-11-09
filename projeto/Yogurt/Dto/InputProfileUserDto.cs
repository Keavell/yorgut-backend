namespace Yogurt.Dto
{
    public class InputProfileUserDto
    {
        public Guid IdUsuario { get; set;}

        public int IdCidade { get; set; }

        public string? Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public byte[]? FotoPerfil { get; set; }

        public string? Biografia { get; set; }

        public string? Genero { get; set; }

    }
}

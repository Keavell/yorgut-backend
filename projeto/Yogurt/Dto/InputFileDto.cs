namespace Yogurt.Dto
{
    public class InputFileDto
    {
        public Guid Id_Publicacao { get; set; }

        public Byte[]? Conteudo { get; set; }

        public string? MimeType { get; set; }
    }
}

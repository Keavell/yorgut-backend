namespace Yogurt.Dto.Publication;

public class InputCompartilharPublicacaoDto
{
    public Guid IdPublicacaoExistente { get; set; }
    
    public string? Legenda { get; set; }

    public Guid? IdComunidade { get; set; }

    public Guid IdPerfil { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces.Publication;
using Yogurt.Dto.Publication;

namespace Yogurt.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicacaoController : ControllerBase
{
    private readonly IPublicacaoService _publicacaoService;

    public PublicacaoController(IPublicacaoService publicacaoService)
    {
        _publicacaoService = publicacaoService;
    }

    [HttpPost("GerarPublicacao")]
    public async Task<IActionResult> Post([FromBody] InputPublicacaoDto inputPublicacaoDto)
    {
        await _publicacaoService.Insert(inputPublicacaoDto.Legenda ?? string.Empty, inputPublicacaoDto.IdPerfil,
            inputPublicacaoDto.IdComunidade);

        return Ok();
    }

    [HttpPost("CompartilharPublicacaoExistente")]
    public async Task<IActionResult> PostSharePublication([FromBody] InputCompartilharPublicacaoDto inputCompartilharPublicacaoDtoPublicacaoDto)
    {
        var publication = await _publicacaoService.SharePublication(
            inputCompartilharPublicacaoDtoPublicacaoDto.IdPublicacaoExistente,
            inputCompartilharPublicacaoDtoPublicacaoDto.IdPerfil,
            inputCompartilharPublicacaoDtoPublicacaoDto.Legenda ?? string.Empty);
        return Ok(publication.Objeto);
    }

    [HttpPost("IncrementarCurtidas")]
    public async Task<IActionResult> PostIncrementarCurtidas(Guid id)
    {
        await _publicacaoService.IncrementarCurtidas(id);
        return Ok();
    }

    [HttpPost("DecrementarCurtidas")]
    public async Task<IActionResult> PostDecrementarCurtida(Guid id)
    {
        await _publicacaoService.DecrementarCurtidas(id);
        return Ok();
    }

    [HttpGet("BuscarPublicacaoById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var a = await _publicacaoService.GetById(id);

        return Ok(a.Objeto);
    }

    [HttpGet("BuscarListaPublicacao")]
    public async Task<IActionResult> GetAllPublicacoes()
    {
        var a = await _publicacaoService.GetAll();

        //return Ok(a.ListaDeObjetos);
        return StatusCode((int)a.StatusCode, a.Objeto);
    }

    [HttpGet("BuscarPublicacaoPorLegenda")]
    public async Task<IActionResult> GetPublicacaoPorLegenda([FromBody] string legenda)
    {
        if (string.IsNullOrEmpty(legenda))
            return NotFound();

        var a = await _publicacaoService.GetByLegenda(legenda);

        return Ok(a.Objeto);
    }

    [HttpPatch("AtualizarPublicacao")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] InputPublicacaoDto inputPublicacaoDto)
    {
        var a = await _publicacaoService.Update(id, inputPublicacaoDto.Legenda ?? string.Empty);

        return Ok(a.Objeto);
    }

    [HttpDelete("DeletarPublicacao")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _publicacaoService.Delete(id);

        return Ok();
    }
}
using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces.Publication;
using Yogurt.Application.Utils;
using Yogurt.Infraestructure.Interfaces.Publication;

namespace Yogurt.Application.Services;

public class PublicacaoService : IPublicacaoService
{
    private readonly IPublicacaoRepository _publicacaoRepository;

    public PublicacaoService(IPublicacaoRepository publicacaoRepository)
    {
        _publicacaoRepository = publicacaoRepository;
    }

    public async Task<ReturnDto> Insert(string? legenda, Guid usuarioId, Guid? comunidadeId)
    {
        var entity =
            InputParaPublicacaoEntity.ConverterInputParaPublicacaoEntity(legenda ?? string.Empty, usuarioId,
                comunidadeId);

        await _publicacaoRepository.Insert(entity);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
    }

    public async Task<ReturnDto> GetById(Guid id)
    {
        var publicacao = await _publicacaoRepository.GetById(id);

        if (publicacao == null)
            return new ReturnDto("Publicação não encontrada", StatusCodeEnum.Return.NotFound);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess, publicacao);
    }

    public async Task<ReturnDto> GetAll()
    {
        var listaDePublicacao = await _publicacaoRepository.GetAll();

        if (!listaDePublicacao.Any())
            return new ReturnDto("Publicações não encontradas", StatusCodeEnum.Return.NotFound);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess, listaDePublicacao);
    }

    public async Task<ReturnDto> GetByLegenda(string legenda)
    {
        var listaDePublicacoes = await _publicacaoRepository.GetByLegenda(legenda);

        if (listaDePublicacoes.Any())
            return new ReturnDto("Publicação(ões) não encontrada(as)",
                StatusCodeEnum.Return.NotFound);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess, listaDePublicacoes);
    }

    public async Task<ReturnDto> Update(Guid id, string legenda)
    {
        var atualizado = await _publicacaoRepository.Update(id, legenda);

        if (!atualizado)
            return new ReturnDto("Não foi possível atualizar, tente novamente",
                StatusCodeEnum.Return.BadRequest);

        var publicacaoAtualizada = await _publicacaoRepository.GetById(id);

        if (publicacaoAtualizada == null)
            return new ReturnDto("Algo de errado aconteceu, tente novamente",
                StatusCodeEnum.Return.BadRequest);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess, publicacaoAtualizada);
    }

    public async Task<ReturnDto> Delete(Guid id)
    {
        var deletar = await _publicacaoRepository.Delete(id);

        return deletar
            ? new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess)
            : new ReturnDto("Não foi possível deletar", StatusCodeEnum.Return.BadRequest);
    }

    public async Task<int> IncrementarCurtidas(Guid id)
    {
        var publicacao = await _publicacaoRepository.GetById(id);
        if (publicacao == null)
            throw new InvalidOperationException(
                "Não foi possível realizar essa operação, recarregue a página e tente novamente");

        return await _publicacaoRepository.IncrementarCurtidas(publicacao);
    }

    public async Task<int> DecrementarCurtidas(Guid id)
    {
        var publicacao = await _publicacaoRepository.GetById(id);
        if (publicacao == null)
            throw new InvalidOperationException(
                "Não foi possível realizar essa operação, recarregue a página e tente novamente");

        return await _publicacaoRepository.DecrementarCurtidas(publicacao);
    }

    public async Task<ReturnDto> SharePublication(Guid id, Guid usuarioId, string legenda)
    {
        var publication = await _publicacaoRepository.GetById(id);

        if (publication == null)
            return new ReturnDto("Essa publicação não existe mais", StatusCodeEnum.Return.NotFound);

        publication.Curtidas = 0;
        publication.DataCriacao = DateTime.Now;
        publication.IdPerfil = usuarioId;
        publication.Legenda = legenda;

        await _publicacaoRepository.Insert(publication);

        return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
    }
}
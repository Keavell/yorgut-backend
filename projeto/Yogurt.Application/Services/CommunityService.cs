using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly ICommunityRepository _communityRepository;

        public CommunityService(ICommunityRepository repository)
        {
            _communityRepository = repository;
        }

        public async Task<ReturnDto> InsertCommunity(Guid idCriador, Guid idCategoriaComunidade, string nome, string legenda, byte[] foto)
        {
            if (idCriador == Guid.Empty || idCategoriaComunidade == Guid.Empty)
            {
                return new ReturnDto(idCriador == Guid.Empty ? "Id do perfil não encontrado!" : "Id da categoria não encontrado!", StatusCodeEnum.Return.NotFound);
            }

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(legenda))
            {
                return new ReturnDto(string.IsNullOrEmpty(nome) ? "Você precisa informar um nome para a comunidade." : "Você precisa adicionar uma legenda para a comunidade.", StatusCodeEnum.Return.BadRequest);
            }

            if (legenda.Length > 500)
            {
                return new ReturnDto("A legenda não pode conter mais que 500 caracteres", StatusCodeEnum.Return.BadRequest);
            }

            await _communityRepository.Insert(new CommunityEntity(idCriador, idCategoriaComunidade, nome, legenda, foto, DateTime.Now));

            return new ReturnDto("Comunidade criada com sucesso!", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> UpdateCommunity(Guid idCommunity, string nome, string legenda, byte[] foto)
        {
            var result = await _communityRepository.GetByGuid(idCommunity);

            if (result == null)
            {
                return new ReturnDto("Id da comunidade não encontrado!", StatusCodeEnum.Return.NotFound);
            }

            string erroAo = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(nome))
                {
                    erroAo = "erro ao alterar o nome da comunidade";
                    _communityRepository.UpdateName(nome, result);
                }

                if (!string.IsNullOrEmpty(legenda))
                {
                    erroAo = "erro ao alterar a legenda da comunidade";
                    _communityRepository.UpdateSubtitle(legenda, result);
                }

                if (foto.Length > 0 && foto != null)
                {
                    erroAo = "erro ao alterar a imagem da comunidade";
                    _communityRepository.UpdateImage(foto, result);
                }
            }
            catch (Exception)
            {
                return new ReturnDto($"Ocorreu um {erroAo}", StatusCodeEnum.Return.BadRequest);
            }

            return new ReturnDto("Comunidade criada com sucesso!", StatusCodeEnum.Return.Sucess);
        }

        //terminar de implementar

    }
}

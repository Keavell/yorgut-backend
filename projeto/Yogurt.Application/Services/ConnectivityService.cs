using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class ConnectivityService: IConnectivityService
    {
        private readonly IConnectivityRepository _connectivityRepository;

        private readonly IProfileUserRepository _profileRepository;

        private readonly ICommunityRepository _comunityRepository;

        public ConnectivityService(IConnectivityRepository connectivityRepository, IProfileUserRepository profileRepository, ICommunityRepository communityRepository)
        {
            _connectivityRepository = connectivityRepository;

            _profileRepository = profileRepository;

            _comunityRepository = communityRepository;
        }

        public async Task<ReturnDto> InsertConnectivity(Guid? idPerfil, Guid? idCommunity)
        {
            if (idPerfil == Guid.Empty || idCommunity == Guid.Empty)
            {
                return new ReturnDto("Um dos itens requisitados se encontra nulo!", StatusCodeEnum.Return.BadRequest);
            }

            var profileResult = await _profileRepository.GetById(idPerfil.Value);

            if (profileResult == null)
            {
                return new ReturnDto("Perfil não existe!", StatusCodeEnum.Return.NotFound);
            }
            var communityResult = await _comunityRepository.GetById(idCommunity.Value);

            if (communityResult == null)
            {
                return new ReturnDto("Comunidade não existe!", StatusCodeEnum.Return.NotFound);
            }

            var connectivity = new ConnectivityEntity(idPerfil.Value, idCommunity.Value);

            try
            {
               await _connectivityRepository.Insert(connectivity);

                return new ReturnDto("Conectividade formada!", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Houve um erro ao tentar formar a conectividade", StatusCodeEnum.Return.BadRequest);
            }
        }

        public async Task<ReturnDto> DeleteConnectivity(Guid? idConnectivity)
        {
            if (idConnectivity == Guid.Empty)
            {
                return new ReturnDto("O item requisitado se encontra nulo!", StatusCodeEnum.Return.BadRequest);
            }

            var resultConnectivity = await _connectivityRepository.GetById(idConnectivity.Value);

            if(resultConnectivity == null)
            {
                return new ReturnDto("Não foi encontrada essa conectividade!", StatusCodeEnum.Return.NotFound);
            }

            try
            {
                await _connectivityRepository.RemoveByEntity(resultConnectivity);

                return new ReturnDto("Conectividade removida!", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Houve um erro ao tentar remover a conectividade", StatusCodeEnum.Return.BadRequest);
            }
        }

        public async Task<ReturnDto> GetCommunityConnectivity(Guid? idCommunity)
        {
            if (idCommunity == Guid.Empty)
            {
                return new ReturnDto("O item requisitado se encontra nulo!", StatusCodeEnum.Return.BadRequest);
            }

            var communityResult = await _comunityRepository.GetById(idCommunity.Value);

            if (communityResult == null)
            {
                return new ReturnDto("Comunidade não existe!", StatusCodeEnum.Return.NotFound);
            }

            try
            {
                var result = await _connectivityRepository.GetByCommunity(idCommunity.Value);

                return new ReturnDto("", StatusCodeEnum.Return.Sucess, result);
            }
            catch
            {
                return new ReturnDto("Houve um erro ao tentar puxar as conectividade", StatusCodeEnum.Return.BadRequest);
            }
        }

        public async Task<ReturnDto> GetPerfilConnectivity(Guid? idPerfil)
        {
            if (idPerfil == Guid.Empty)
            {
                return new ReturnDto("O item requisitado se encontra nulo!", StatusCodeEnum.Return.BadRequest);
            }

            var profileResult = await _profileRepository.GetById(idPerfil.Value);

            if (profileResult == null)
            {
                return new ReturnDto("Perfil não existe!", StatusCodeEnum.Return.NotFound);
            }

            try
            {
                var result = await _connectivityRepository.GetByPerfil(idPerfil.Value);

                return new ReturnDto("", StatusCodeEnum.Return.Sucess, result);
            }
            catch
            {
                return new ReturnDto("Houve um erro ao tentar puxar as conectividade", StatusCodeEnum.Return.BadRequest);
            }
        }
    }
}

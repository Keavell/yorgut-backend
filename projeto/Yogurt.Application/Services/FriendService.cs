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
    public class FriendService: IFriendService
    {
        private readonly IFriendRepository _friendRepository;

        private readonly IProfileUserRepository _perfilRepository;

        public FriendService(IFriendRepository repositoryFriend, IProfileUserRepository repositoryProfile)
        {
            _friendRepository = repositoryFriend;
            _perfilRepository = repositoryProfile;
        }

        public async Task<ReturnDto> InsertFriend(Guid? idPerfil, Guid? idPerfilPretendido)
        {
            if (idPerfil == Guid.Empty || idPerfilPretendido == Guid.Empty)
            {
                return new ReturnDto("Um dos itens se encontra nulo", StatusCodeEnum.Return.BadRequest);
            }

            var perfilSolicitante = _perfilRepository.GetById(idPerfil.Value);

            if (perfilSolicitante == null)
            {
                return new ReturnDto("Perfil solicitante não existe", StatusCodeEnum.Return.NotFound);
            }

            var perfilRecebidor = _perfilRepository.GetById(idPerfilPretendido.Value);

            if (perfilRecebidor == null)
            {
                return new ReturnDto("Perfil pretendido não existe", StatusCodeEnum.Return.NotFound);
            }

            var pretendido = await _friendRepository.CatchFriend(idPerfilPretendido.Value);

            if(pretendido == null)
            {
                return new ReturnDto("Item de amigo não existe", StatusCodeEnum.Return.NotFound);
            }

            var connect = new ConnectEntity() { IdPerfil = idPerfil.Value,
                                                IdAmizade = pretendido.Id};

            try
            {
                await _friendRepository.Insert(connect);

                return new ReturnDto("Perfil pretendido não existe", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Ocorreu um erro inesperado!", StatusCodeEnum.Return.BadRequest);
            }
        }


        public async Task<ReturnDto> DeleteFriend(Guid? idConnect)
        {
            if (idConnect == Guid.Empty)
            {
                return new ReturnDto("O item se encontra nulo", StatusCodeEnum.Return.BadRequest);
            }

            var pretendido = await _friendRepository.GetById(idConnect.Value);

            if (pretendido == null)
            {
                return new ReturnDto("Não existe o connect pretendido", StatusCodeEnum.Return.NotFound);
            }

            try
            {
                await _friendRepository.RemoveByEntity(pretendido);

                return new ReturnDto("Seguimento desfeito!", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Ocorreu um erro inesperado!", StatusCodeEnum.Return.BadRequest);
            }
        }


        public async Task<ReturnDto> GetFriend(Guid? idPerfil)
        {

            if (idPerfil == Guid.Empty)
            {
                return new ReturnDto("O item se encontra nulo", StatusCodeEnum.Return.BadRequest);
            }

            try
            {
                var connects = await _friendRepository.GetAllConnect(idPerfil.Value);

                return new ReturnDto("Pegos todos os seguimentos!", StatusCodeEnum.Return.Sucess, connects);
            }
            catch
            {
                return new ReturnDto("Ocorreu um erro inesperado!", StatusCodeEnum.Return.BadRequest);
            }
        }


        public async Task<ReturnDto> InsertPointPerfil(Guid? idPerfilPretendido)
        {

            if (idPerfilPretendido == Guid.Empty)
            {
                return new ReturnDto("O item se encontra nulo", StatusCodeEnum.Return.BadRequest);
            }

            var pretend = _friendRepository.CatchFriend(idPerfilPretendido.Value);

            if (pretend != null)
            {
                return new ReturnDto("Já existe um ponto de conecção com esse perfil", StatusCodeEnum.Return.BadRequest);
            }

            var friendPoint = new FriendEntity() { IdPerfil = idPerfilPretendido.Value };

            try
            {
                 await _friendRepository.InsertFriend(friendPoint);

                return new ReturnDto("Ponto de amizade concluido!", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Ocorreu um erro inesperado!", StatusCodeEnum.Return.BadRequest);
            }
        }
    }
}

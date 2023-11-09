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
    public class ProfileUserService : IProfileUserService
    {
        private readonly IProfileUserRepository _profileUserRepository;

        public ProfileUserService(IProfileUserRepository repository)
        {
            _profileUserRepository = repository;
        }
        public async Task<ReturnDto> Register(string userName, string biography, DateTime dataNascimento, string? genero, Guid idUsuario, int idCidade, byte[]? fotoPerfil)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return new ReturnDto("Preencha o UserName.", StatusCodeEnum.Return.NotFound);
            }
            
            if (userName.Length < 3)
            {
                return new ReturnDto("O Username não pode conter menos de 3 caractéres.", StatusCodeEnum.Return.BadRequest);
            }

            if (userName.Length > 50)
            {
                return new ReturnDto("O nome não pode conter mais de 50 caractéres", StatusCodeEnum.Return.BadRequest);
            }

            if (biography.Length > 4000)
            {
                return new ReturnDto("Quantidade de caractéres superior ao permitido", StatusCodeEnum.Return.BadRequest);
            }

            if (dataNascimento > DateTime.Today)
            {
                return new ReturnDto("A Data de Nascimento não pode ser superior a data atual.", StatusCodeEnum.Return.BadRequest);
            }

            if(dataNascimento < new DateTime(1899/12/31))
            {
                return new ReturnDto("A Data de Nascimento não pode ser inferior ao ano de 1900.", StatusCodeEnum.Return.BadRequest);
            }

            //if(genero != 'F' || genero != 'M')
            //{
            //    return new ReturnDto("Inicial de gênero incorreta.", StatusCodeEnum.Return.BadRequest);
            //}

            await _profileUserRepository.Insert(new ProfileUserEntity(idUsuario, idCidade, userName, dataNascimento, fotoPerfil, biography, genero));

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);

        }

        public async Task<ReturnDto> AlterUserName(string userName, Guid idPerfil)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return new ReturnDto("Você precisa ter um nome!", StatusCodeEnum.Return.BadRequest);
            }

            if (userName.Length < 3)
            {
                return new ReturnDto("O nome não pode conter menos de 3 caractéres!", StatusCodeEnum.Return.BadRequest);
            }

            if (userName.Length > 50)
            {
                return new ReturnDto("O nome não pode conter mais de 50 caractéres", StatusCodeEnum.Return.BadRequest);
            }

            if(idPerfil == Guid.Empty)
            {
                return new ReturnDto("Id do perfil Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _profileUserRepository.GetById(idPerfil);

            if(result == null)
            {
                return new ReturnDto("Registro não encontrado.", StatusCodeEnum.Return.BadRequest);
            }

            _profileUserRepository.UpdateUserName(userName, result);

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> AlterBiography(string? biography, Guid idPerfil)
        {
            if (biography.Length > 4000)
            {
                return new ReturnDto("Quantidade de caractéres superior ao permitido", StatusCodeEnum.Return.BadRequest);
            }

            if (idPerfil == Guid.Empty)
            {
                return new ReturnDto("Id do perfil Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _profileUserRepository.GetById(idPerfil);

            if (result == null)
            {
                return new ReturnDto("Registro não encontrado.", StatusCodeEnum.Return.BadRequest);
            }

            _profileUserRepository.UpdateBiography(biography, result);

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> AlterProfilePhoto(byte[]? profilePhoto, Guid idPerfil)
        {
            if (idPerfil == Guid.Empty)
            {
                return new ReturnDto("Id do perfil Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _profileUserRepository.GetById(idPerfil);

            if (result == null)
            {
                return new ReturnDto("Registro não encontrado.", StatusCodeEnum.Return.BadRequest);
            }

            _profileUserRepository.UpdateProfilePhoto(profilePhoto, result);

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> AlterCity(int? city, Guid idPerfil)
        {
            if (city == null)
            {
                return new ReturnDto("Você precisa informar uma cidade!", StatusCodeEnum.Return.BadRequest);
            }

            if (idPerfil == Guid.Empty)
            {
                return new ReturnDto("Id do perfil Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _profileUserRepository.GetById(idPerfil);

            if (result == null)
            {
                return new ReturnDto("Registro não encontrado.", StatusCodeEnum.Return.BadRequest);
            }

            _profileUserRepository.UpdateCity(city, result);

            return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
        }
    }
}

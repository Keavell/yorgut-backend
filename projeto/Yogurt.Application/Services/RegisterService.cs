using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities;
using Yogurt.Domain.Entities.User;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class RegisterService: IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository repository)
        {
            _registerRepository = repository;
        }

        public async Task<ReturnDto> Register(Guid idUser, string? nome, DateTime? dataNascimento, string? genero)
        {
       
            if (dataNascimento.HasValue)
            {
                if (dataNascimento > DateTime.Today)
                {
                    return new ReturnDto("A Data de Nascimento não pode ser superior a data atual.", StatusCodeEnum.Return.BadRequest);
                }

                if (dataNascimento < new DateTime(1899 / 12 / 31))
                {
                    return new ReturnDto("A Data de Nascimento não pode ser inferior ao ano de 1900.", StatusCodeEnum.Return.BadRequest);
                }
            }

            if (!string.IsNullOrEmpty(genero))
            {
                if (genero.ToUpper() != "F" || genero != "M")
                {
                    return new ReturnDto("Inicial de gênero incorreta.", StatusCodeEnum.Return.BadRequest);
                }
            }

            if (string.IsNullOrEmpty(nome))
            {
                return new ReturnDto("Nome está nulo!", StatusCodeEnum.Return.BadRequest);
            }
            try
            {
                var entity = new ProfileUserEntity()
                {
                    IdUsuario = idUser,
                    Nome = nome,
                    Genero = genero,
                    DataNascimento = dataNascimento
                };

                var profileId = await _registerRepository.InsertProfile(entity);

                await _registerRepository.InsertConnect(profileId);

                return new ReturnDto("Sucesso", StatusCodeEnum.Return.Sucess);
            }
            catch
            {
                return new ReturnDto("Ocorreu um erro inesperado!", StatusCodeEnum.Return.BadRequest);
            }         
        }
    }
}

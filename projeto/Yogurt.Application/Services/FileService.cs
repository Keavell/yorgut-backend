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
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository repository)
        {
            _fileRepository = repository;
        }

        public async Task<ReturnDto> InsertFile(Guid idPublicacao, Byte[] conteudo, string mimeType)
        {
            if (idPublicacao == Guid.Empty)
            {
                return new ReturnDto("Id da publicação não encontrado!", StatusCodeEnum.Return.BadRequest);
            }

            if (string.IsNullOrEmpty(conteudo.ToString()))
            {
                return new ReturnDto("Não é possível enviar um Arquivo vazio", StatusCodeEnum.Return.BadRequest);
            }

            await _fileRepository.Insert(new FileEntity(idPublicacao, conteudo, mimeType, DateTime.Now));

            return new ReturnDto("Arquivo enviado com sucesso!", StatusCodeEnum.Return.Sucess);
        }
    }
}

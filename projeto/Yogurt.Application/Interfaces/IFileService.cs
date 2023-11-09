using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yogurt.Application.Dto;
using Yogurt.Domain.Entities;

namespace Yogurt.Application.Interfaces
{
    public interface IFileService
    {
        Task<ReturnDto> InsertFile(Guid idPublicacao, Byte[] conteudo, string mimeType);
    }
}

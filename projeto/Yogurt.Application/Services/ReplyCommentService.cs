using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities.ReplyComment;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class ReplyCommentService : IReplyCommentService
    {
        private readonly IReplyCommentRepository _replyCommentRepository;

        public ReplyCommentService(IReplyCommentRepository repository)
        {
            _replyCommentRepository = repository;
        }

        public async Task<ReturnDto> InsertReplyComment(Guid idComment, string response)
        {
            if (idComment == Guid.Empty)
            {
                return new ReturnDto("Id da publicação não encontrado!", StatusCodeEnum.Return.BadRequest);
            }

            if (string.IsNullOrEmpty(response))
            {
                return new ReturnDto("Não é possível enviar um comentario vazio", StatusCodeEnum.Return.BadRequest);
            }

            if (response.Length > 255)
            {
                return new ReturnDto("O comentarío não pode conter mais que 255 caracteres", StatusCodeEnum.Return.BadRequest);
            }

            await _replyCommentRepository.Insert(new ReplyCommentEntity(response, DateTime.Now));

            return new ReturnDto("Resposta do Comentario enviado com sucesso!", StatusCodeEnum.Return.Sucess);
        }
    }
}

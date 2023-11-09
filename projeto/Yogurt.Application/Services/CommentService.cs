using Yogurt.Application.Dto;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Domain.Entities;
using Yogurt.Infraestructure.Interfaces;

namespace Yogurt.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository repository)
        {
            _commentRepository = repository;
        }

        public async Task<ReturnDto> InsertComment(Guid idPublicacao, string comment)
        {
            if (idPublicacao == Guid.Empty)
            {
                return new ReturnDto("Id da publicação não encontrado!", StatusCodeEnum.Return.BadRequest);
            }

            if (string.IsNullOrEmpty(comment))
            {
                return new ReturnDto("Não é possível enviar um comentario vazio", StatusCodeEnum.Return.BadRequest);
            }

            if (comment.Length > 255)
            {
                return new ReturnDto("O comentarío não pode conter mais que 255 caracteres", StatusCodeEnum.Return.BadRequest);
            }

            await _commentRepository.Insert(new CommentEntity(idPublicacao, comment, 0, DateTime.Now));

            return new ReturnDto("Comentario enviado com sucesso!", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> AddLike(Guid idComment)
        {
            if (idComment == Guid.Empty)
            {
                return new ReturnDto("Id do comentario Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _commentRepository.GetByGuid(idComment);

            if (result == null)
            {
                return new ReturnDto("Id do comentario não encontrado!", StatusCodeEnum.Return.NotFound);
            }

            await _commentRepository.UpdateLike(result.Curtidas + 1, result);

            return new ReturnDto("Curtida enviada com sucesso!", StatusCodeEnum.Return.Sucess);
        }

        public async Task<ReturnDto> RemoveLike(Guid idComment)
        {
            if (idComment == Guid.Empty)
            {
                return new ReturnDto("Id do comentario Inválido", StatusCodeEnum.Return.BadRequest);
            }

            var result = await _commentRepository.GetByGuid(idComment);

            if (result == null)
            {
                return new ReturnDto("Id do comentario não encontrado!", StatusCodeEnum.Return.NotFound);
            }

            await _commentRepository.UpdateLike(result.Curtidas - 1, result);

            return new ReturnDto("Curtida Removida!", StatusCodeEnum.Return.Sucess);
        }
    }
}

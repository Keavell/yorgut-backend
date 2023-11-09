using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("SendComment")]
        public async Task<IActionResult> PostComment([FromBody] InputCommentDto inputCommentDto)
        {
            var returns = await _commentService.InsertComment(inputCommentDto.Id_Publicacao, inputCommentDto.Legenda);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }

        [HttpPatch("AddLike")]
        public async Task<IActionResult> AddLike(Guid idComment)
        {
            var returns = await _commentService.AddLike(idComment);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }

        [HttpPatch("RemoveLike")]
        public async Task<IActionResult> RemoveLike(Guid idComment)
        {
            var returns = await _commentService.RemoveLike(idComment);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }
    }
}

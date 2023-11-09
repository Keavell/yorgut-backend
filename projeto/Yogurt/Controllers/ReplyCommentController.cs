using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto;
using Yogurt.Dto.ReplyComment;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReplyCommentController : ControllerBase
    {
        private readonly IReplyCommentService _replyCommentService;

        public ReplyCommentController(IReplyCommentService replycommentService)
        {
            _replyCommentService = replycommentService;
        }

        [HttpPost("SendReplyComment")]
        public async Task<IActionResult> PostReplyComment([FromBody] InputReplyCommentDto inputReplyCommentDto)
        {
            var returns = await _replyCommentService.InsertReplyComment(inputReplyCommentDto.Id_Comentarios, inputReplyCommentDto.Legenda);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }
    }
}

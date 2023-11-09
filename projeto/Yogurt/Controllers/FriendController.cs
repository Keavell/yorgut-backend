using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FriendController: ControllerBase
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service)
        {
            _service = service;
        }

        [HttpPost("InsertFriendConnect")]
        public async Task<IActionResult> InsertFriendConnect(Guid? idPerfil, Guid? idPerfilEsperado)
        {
            var result = await _service.InsertFriend(idPerfil, idPerfilEsperado);

            if (result.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(result.Message);
            }

            if (result.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpDelete("DeleteFriend")]
        public async Task<IActionResult> DeleteConnect(Guid? idConnect)
        {

            var result = await _service.DeleteFriend(idConnect);

            if (result.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(result.Message);
            }

            if (result.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }

        [HttpGet("GetFriend")]
        public async Task<IActionResult> GetAllConnect(Guid? idPerfil)
        {
            var result = await _service.GetFriend(idPerfil);

            if (result.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("InsertPointFriend")]
        public async Task<IActionResult> InsertPointFriend(Guid? idPerfilPretendido)
        {
            var result = await _service.InsertPointPerfil(idPerfilPretendido);

            if (result.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return NotFound(result.Message);
            }

            return Ok();
        }

    }
}

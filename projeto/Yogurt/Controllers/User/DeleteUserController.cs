using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto.User;

namespace Yogurt.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public DeleteUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(InputDeleteUserDto user)
        {
            var result = await _userService.DeleteUser(user.IdUser, user.Password);


            if (result.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(result.Message);
            }

            if (result.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(result.Message);
            }

            return Ok(result.Message);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post([FromBody] InputRegisterControllerDto inputRegisterControllerDto)
        {
            var returns = await _userService.Register(inputRegisterControllerDto.Email, inputRegisterControllerDto.Password, inputRegisterControllerDto.UserName, inputRegisterControllerDto.Telefone);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }
    }
}
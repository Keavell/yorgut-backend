using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterFrontController:ControllerBase
    {
        private readonly IRegisterService _registerService;

        private readonly IUserService _userService;


        public RegisterFrontController(IRegisterService registerServicee, IUserService userService)
        {
            _registerService = registerServicee;
            _userService = userService;
        }


        [HttpPost("RegisterAll")]
        public async Task<IActionResult> Post([FromBody] RegisterDto registerDto)
        {
            var resultUser = await _userService.Register(registerDto.Email,registerDto.Senha, registerDto.Username, registerDto.Telefone);

            if (resultUser.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(resultUser.Message);
            }

            var user = Guid.Parse(resultUser.Objeto.ToString());

            var resultPerfil = await _registerService.Register(user, registerDto.Nome, registerDto.DataNascimento.Value,registerDto.Genero);


            if (resultUser.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(resultPerfil.Message);
            }

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;
using Yogurt.Dto;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileUserController : ControllerBase
    {
        private readonly IProfileUserService _profileUserService;

        public ProfileUserController(IProfileUserService profileUserService)
        {
            _profileUserService = profileUserService;
        }

        [HttpPost("RegisterProfileUser")]
        public async Task<IActionResult> Post([FromBody] InputProfileUserDto inputProfileUserDto)
        {
            var returns = await _profileUserService.Register(inputProfileUserDto.Nome, inputProfileUserDto.Biografia, inputProfileUserDto.DataNascimento.Value, inputProfileUserDto.Genero, inputProfileUserDto.IdUsuario, inputProfileUserDto.IdCidade, inputProfileUserDto.FotoPerfil);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns);
            }

            return Ok(returns);
        }

        [HttpPatch("AlterNameUser")]
        public async Task<IActionResult> AlterNameUser(string nameUser, Guid idPerfil)
        {
            var returns = await _profileUserService.AlterUserName(nameUser, idPerfil);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            return Ok(returns.Message);
        }

        [HttpPatch("AlterBiography")]
        public async Task<IActionResult> AlterBiography(string? biography, Guid idPerfil)
        {
            var returns = await _profileUserService.AlterBiography(biography, idPerfil);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            return Ok(returns.Message);
        }

        [HttpPatch("AlterPhotoProfile")]
        public async Task<IActionResult> AlterProfilePhoto(byte[]? photoProfile, Guid idPerfil)
        {
            var returns = await _profileUserService.AlterProfilePhoto(photoProfile, idPerfil);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            return Ok(returns.Message);
        }

        [HttpPatch("AlterCity")]
        public async Task<IActionResult> AlterCity(int? city, Guid idPerfil)
        {
            var returns = await _profileUserService.AlterCity(city, idPerfil);

           if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            return Ok(returns.Message);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConnectivityController: ControllerBase
    {
        private readonly IConnectivityService _connectivityService;

        public ConnectivityController(IConnectivityService service)
        {
            _connectivityService = service;
        }

        [HttpPost("InsertConnectivity")]
        public async Task<IActionResult> Post(Guid? idPerfil, Guid? IdCommunity)
        {
            var returns = await _connectivityService.InsertConnectivity(idPerfil, IdCommunity);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            return Ok(returns.Message);
        }

        [HttpDelete("DeleteConnectivity")]
        public async Task<IActionResult> Delete(Guid? idConnectivity)
        {
            var returns = await _connectivityService.DeleteConnectivity(idConnectivity);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            return Ok(returns.Message);
        }

        [HttpGet("GetCommunityConnectivity")]
        public async Task<IActionResult> GetCommunity(Guid? idCommunity)
        {
            var returns = await _connectivityService.GetCommunityConnectivity(idCommunity);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            return Ok(returns.ListaDeObjetos);
        }

        [HttpGet("GetPerfilConnectivity")]
        public async Task<IActionResult> Getperfil(Guid? idPerfil)
        {
            var returns = await _connectivityService.GetPerfilConnectivity(idPerfil);

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.NotFound))
            {
                return NotFound(returns.Message);
            }

            if (returns.StatusCode.Equals(StatusCodeEnum.Return.BadRequest))
            {
                return BadRequest(returns.Message);
            }

            return Ok(returns.ListaDeObjetos);
        }
    }
}

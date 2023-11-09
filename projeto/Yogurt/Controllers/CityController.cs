using Microsoft.AspNetCore.Mvc;
using Yogurt.Application.Interfaces;
using Yogurt.Application.Utils;

namespace Yogurt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController: ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetCity")]
        public async Task<IActionResult> GetCity() => Ok(await _cityService.GetAll());
    }
}

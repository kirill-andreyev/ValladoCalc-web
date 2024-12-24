using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class RV2COEController : ControllerBase
    {
        private readonly IRV2COEService _RV2COEService;

        public RV2COEController(IRV2COEService RV2COEService)
        {
            _RV2COEService = RV2COEService;
        }

        [HttpPost]
        public async Task<IActionResult> OrbitalParameters([FromBody] RV2COEModel data)
        {
            return Ok(await _RV2COEService.CalculateOrbitalParameters(data));
        }
    }
}
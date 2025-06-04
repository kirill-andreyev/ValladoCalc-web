using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;

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
        [ProducesResponseType(typeof(RV2COEResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> OrbitalParameters([FromBody] RV2COEModel data)
        {
            return Ok(await _RV2COEService.CalculateOrbitalParameters(data));
        }
    }
}
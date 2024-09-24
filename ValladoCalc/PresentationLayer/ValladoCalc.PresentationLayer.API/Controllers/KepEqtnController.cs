using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class KepEqtnController : ControllerBase
    {
        private readonly IKepEqtnEService _kepEqtnEService;

        public KepEqtnController(IKepEqtnEService kepEqtnEService)
        {
            _kepEqtnEService = kepEqtnEService;
        }

        [HttpPost]
        public async Task<IActionResult> EccentricAnomaly([FromBody] KepEqtnEModel data)
        {
            return Ok(await _kepEqtnEService.CalculateEccenticAnomaly(data));

        }
    }
}
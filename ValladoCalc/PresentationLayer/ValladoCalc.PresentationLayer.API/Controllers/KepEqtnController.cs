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
        private readonly IKepEqtnPService _kepEqtnPService;

        public KepEqtnController(IKepEqtnEService kepEqtnEService, IKepEqtnPService kepEqtnPService)
        {
            _kepEqtnEService = kepEqtnEService;
            _kepEqtnPService = kepEqtnPService;
        }

        [HttpPost]
        public async Task<IActionResult> EccentricAnomaly([FromBody] KepEqtnEModel data)
        {
            return Ok(await _kepEqtnEService.CalculateEccenticAnomaly(data));
        }

        [HttpPost]
        public async Task<IActionResult> ParabolicAnomaly([FromBody] KepEqtnPModel data)
        {
            return Ok(await _kepEqtnPService.CalculateParabolicAnomaly(data));
        }
    }
}
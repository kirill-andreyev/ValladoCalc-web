using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class KepEqtnController : ControllerBase
    {
        private readonly IKepEqtnService _kepEqtnService;

        public KepEqtnController(IKepEqtnService kepEqtnService)
        {
            _kepEqtnService = kepEqtnService;
        }

        [HttpPost]
        public async Task<IActionResult> EccentricAnomaly([FromBody] KepEqtnEModel data)
        {
            return Ok(await _kepEqtnService.CalculateEccenticAnomaly(data));
        }

        [HttpPost]
        public async Task<IActionResult> ParabolicAnomaly([FromBody] KepEqtnPModel data)
        {
            return Ok(await _kepEqtnService.CalculateParabolicAnomaly(data));
        }
    }
}
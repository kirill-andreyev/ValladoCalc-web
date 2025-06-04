using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;

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
        [ProducesResponseType(typeof(KepEqtnEResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> EccentricAnomaly([FromBody] KepEqtnEModel data)
        {
            return Ok(await _kepEqtnService.CalculateEccenticAnomaly(data));
        }

        [HttpPost]
        [ProducesResponseType(typeof(KepEqtnPResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> ParabolicAnomaly([FromBody] KepEqtnPModel data)
        {
            return Ok(await _kepEqtnService.CalculateParabolicAnomaly(data));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(KepEqtnHResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> HyperbolicAnomaly([FromBody] KepEqtnHModel data)

        {
            return Ok(await _kepEqtnService.CalculateHyperbolicAnomaly(data));
        }
    }
}
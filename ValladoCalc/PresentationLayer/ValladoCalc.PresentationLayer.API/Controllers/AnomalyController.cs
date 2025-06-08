using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AnomalyController : ControllerBase
    {
        private readonly IAnomalyService _anomalyService;

        public AnomalyController(IAnomalyService anomalyService)
        {
            _anomalyService = anomalyService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrueAnomalyToAnomalyResultModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AnomalyFromTrueAnomaly([FromBody] TrueAnomalyToAnomalyModel data)
        {
            return Ok(await _anomalyService.TrueAnomalyToAnomaly(data));
        }

        [HttpPost]
        [ProducesResponseType(typeof(AnomalyToTrueAnomalyResultModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> TrueAnomalyFromAnomaly([FromBody] AnomalyToTrueAnomalyModel data)
        {
            if (data.Eccentricity == 1)
            {
                if (data.R == 0 || data.P == 0)
                {
                    return BadRequest("When Eccentricity is 1, P and R must be valid values");
                }
            }
            else
            {
                if (data.Anomaly == 0)
                {
                    return BadRequest("When Eccentricity isn't 1, Anomaly must be valid values");
                }
            }
            
            return Ok(await _anomalyService.AnomalyToTrueAnomaly(data));
        }
    }
}
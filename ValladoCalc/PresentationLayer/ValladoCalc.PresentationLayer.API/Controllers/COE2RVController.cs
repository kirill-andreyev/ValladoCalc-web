using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class COE2RVController : ControllerBase
    {
        private readonly ICOE2RVService _COE2RVService;

        public COE2RVController(ICOE2RVService COE2RVService)
        {
            _COE2RVService = COE2RVService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(COE2RVResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> Vectors([FromBody] COE2RVModel data)
        {
            return Ok(await _COE2RVService.CalculateVectors(data));
        }
    }
}
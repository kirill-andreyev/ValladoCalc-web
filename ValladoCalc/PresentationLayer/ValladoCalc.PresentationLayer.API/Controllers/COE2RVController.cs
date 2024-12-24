using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Vectors([FromBody] COE2RVModel data)
        {
            return Ok(await _COE2RVService.CalculateVectors(data));
        }
    }
}
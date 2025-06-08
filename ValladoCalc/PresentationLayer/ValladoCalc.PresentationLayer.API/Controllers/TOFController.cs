using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class TOFController : ControllerBase
    {
        private readonly IFindTOFService _findTOFService;

        public TOFController(IFindTOFService findTOFService)
        {
            _findTOFService = findTOFService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindTOFResultModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> TOF([FromBody] FindTOFModel model)
        {
            return Ok(await _findTOFService.FindTOF(model));
        }
    }
}

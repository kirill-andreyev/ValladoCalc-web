using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Models.ExportModels;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class PsiToController : ControllerBase
    {
        private readonly IPsiToService _psiToService;

        public PsiToController(IPsiToService psiToService)
        {
            _psiToService = psiToService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PsiToC2C3ResultModel) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> PsiToC2C3([FromBody] PsiToC2C3Model data)
        {
            return Ok(await _psiToService.CalculateC2C3(data));
        }
    }
}
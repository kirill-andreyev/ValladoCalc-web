using Microsoft.AspNetCore.Mvc;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.PresentationLayer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class DateTimeController : ControllerBase
    {
        private readonly IDateTimeService _dateTimeService;

        public DateTimeController(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        [HttpPost]
        public async Task<IActionResult> JulianDate([FromBody] DateTime date)
        {
            return Ok(await _dateTimeService.CalculateJulianDate(date));
        }
    }
}
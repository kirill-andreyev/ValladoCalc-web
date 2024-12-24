using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class DateTimeService : IDateTimeService
    {
        public async Task<decimal> CalculateJulianDate(DateTime dateTime)
        {
            return 367m * dateTime.Year - 
                        (decimal)Math.Floor(7 * (dateTime.Year + Math.Floor((dateTime.Month + 9.0) / 12.0)) * 0.25) + 
                        (decimal)Math.Floor(275 * dateTime.Month / 9.0) + 
                        dateTime.Day + 1721013.5m + (decimal)(((dateTime.Second/60.0 + dateTime.Minute) / 60.0 + dateTime.Hour) / 24);
        }
    }
}
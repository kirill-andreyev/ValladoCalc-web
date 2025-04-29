using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class DateTimeService : IDateTimeService
    {
        public async Task<double> CalculateJulianDate(DateTime dateTime)
        {
            return 367 * dateTime.Year - 
                        Math.Floor(7 * (dateTime.Year + Math.Floor((dateTime.Month + 9.0) / 12.0)) * 0.25) + 
                        Math.Floor(275 * dateTime.Month / 9.0) + 
                        dateTime.Day + 1721013.5 + ((dateTime.Second/60.0 + dateTime.Minute) / 60.0 + dateTime.Hour) / 24;
        }
    }
}
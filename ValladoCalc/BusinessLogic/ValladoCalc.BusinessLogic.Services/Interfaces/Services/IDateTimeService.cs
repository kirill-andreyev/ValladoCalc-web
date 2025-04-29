namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IDateTimeService
    {
        public Task<double> CalculateJulianDate(DateTime dateTime);
    }
}
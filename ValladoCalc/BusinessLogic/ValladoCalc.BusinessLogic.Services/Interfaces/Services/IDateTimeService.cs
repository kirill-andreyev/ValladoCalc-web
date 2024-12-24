namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IDateTimeService
    {
        public Task<decimal> CalculateJulianDate(DateTime dateTime);
    }
}
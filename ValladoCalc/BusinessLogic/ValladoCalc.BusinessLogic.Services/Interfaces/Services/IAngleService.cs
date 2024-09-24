namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IAngleService
    {
        public Task<decimal> ConvertToRadians(decimal angle);
        public Task<decimal> ConvertToDegrees(decimal angle);
    }
}
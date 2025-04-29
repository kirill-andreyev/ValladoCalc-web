namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IAngleService
    {
        public Task<double> ConvertToRadians(double angle);
        public Task<double> ConvertToDegrees(double angle);
    }
}
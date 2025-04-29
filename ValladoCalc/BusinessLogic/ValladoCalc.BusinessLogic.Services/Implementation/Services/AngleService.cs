using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class AngleService : IAngleService
    {
        public async Task<double> ConvertToDegrees(double angle)
        {
            return angle * 180 / Math.PI;
        }

        public async Task<double> ConvertToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }
    }
}
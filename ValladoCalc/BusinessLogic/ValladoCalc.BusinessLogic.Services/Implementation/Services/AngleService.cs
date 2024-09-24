using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class AngleService : IAngleService
    {
        public async Task<decimal> ConvertToDegrees(decimal angle)
        {
            return angle * 180m / (decimal)Math.PI;
        }

        public async Task<decimal> ConvertToRadians(decimal angle)
        {
            return angle * ((decimal)Math.PI / 180m);
        }
    }
}
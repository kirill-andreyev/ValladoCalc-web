using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IRV2COEService
    {
        public Task<RV2COEResultModel> CalculateOrbitalParameters(RV2COEModel data);
    }
}
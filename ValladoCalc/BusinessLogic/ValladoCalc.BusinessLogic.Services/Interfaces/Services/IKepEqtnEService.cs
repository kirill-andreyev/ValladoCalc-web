using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IKepEqtnEService
    {
        public Task<KepEqtnEResultModel> CalculateEccenticAnomaly(KepEqtnEModel data);
    }
}
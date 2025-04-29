using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IKepEqtnService
    {
        public Task<KepEqtnEResultModel> CalculateEccenticAnomaly(KepEqtnEModel data);
        public Task<KepEqtnPResultModel> CalculateParabolicAnomaly(KepEqtnPModel data);
    }
}
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface IKepEqtnPService
    {
        public Task<KepEqtnPResultModel> CalculateParabolicAnomaly(KepEqtnPModel data);
    }
}
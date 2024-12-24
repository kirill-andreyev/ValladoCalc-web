using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services
{
    public interface ICOE2RVService
    {
        public Task<COE2RVResultModel> CalculateVectors(COE2RVModel data);
    }
}
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services;

public interface IKeplerService
{
    public Task<COE2RVResultModel> CalculateVectorsInTime(KeplerCOEModel data);
}
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services;

public interface IAnomalyService
{
    public Task<TrueAnomalyToAnomalyResultModel> TrueAnomalyToAnomaly(TrueAnomalyToAnomalyModel data);
    public Task<AnomalyToTrueAnomalyResultModel> AnomalyToTrueAnomaly(AnomalyToTrueAnomalyModel data);
}
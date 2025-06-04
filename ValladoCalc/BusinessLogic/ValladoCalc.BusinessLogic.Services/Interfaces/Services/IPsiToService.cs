using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Services.Interfaces.Services;

public interface IPsiToService
{
    public Task<PsiToC2C3ResultModel> CalculateC2C3(PsiToC2C3Model data);
}
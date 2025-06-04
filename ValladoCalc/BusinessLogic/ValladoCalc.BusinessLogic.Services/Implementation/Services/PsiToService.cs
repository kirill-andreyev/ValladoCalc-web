using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementation.Services;

public class PsiToService : IPsiToService
{
    public async Task<PsiToC2C3ResultModel> CalculateC2C3(PsiToC2C3Model data)
    {
        PsiToC2C3ResultModel result = new PsiToC2C3ResultModel();
        
        if (data.Psi > Math.Pow(10, -6))
        {
            result.C2 = (1 - Math.Cos(Math.Sqrt(data.Psi))) / data.Psi;
            result.C3 = (Math.Sqrt(data.Psi) - Math.Sin(Math.Sqrt(data.Psi))) / Math.Sqrt(Math.Pow(data.Psi, 3));
        }
        else if (data.Psi < -Math.Pow(10, -6))
        {
            result.C2 = (1 - Math.Cosh(Math.Sqrt(-data.Psi))) / data.Psi;
            result.C3 = (Math.Sinh(Math.Sqrt(-data.Psi)) - Math.Sqrt(-data.Psi)) / Math.Sqrt(Math.Pow(-data.Psi, 3));
        }
        else
        {
            result.C2 = 1.0 / 2.0;
            result.C3 = 1.0 / 6.0;
        }
        
        return result;
    }
}
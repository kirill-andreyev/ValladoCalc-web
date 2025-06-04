using System.Data;
using ValladoCalc.BusinessLogic.Models;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementation.Services;

public class AnomalyService : IAnomalyService
{
    public async Task<TrueAnomalyToAnomalyResultModel> TrueAnomalyToAnomaly(TrueAnomalyToAnomalyModel data)
    {
        if (data.AngleType == AngleDimension.Degrees)
        {
            data.TrueAnomaly = data.TrueAnomaly * (Math.PI / 180);
        }
        
        TrueAnomalyToAnomalyResultModel result = new TrueAnomalyToAnomalyResultModel();
        result.Eccentricity = data.Eccentricity;
        
        if (data.Eccentricity < 1)
        {
            result.Anomaly = Math.Acos((data.Eccentricity + Math.Cos(data.TrueAnomaly)) /
                                       (1 + data.Eccentricity * Math.Cos(data.TrueAnomaly)));
        }
        else if (data.Eccentricity > 1)
        {
            result.Anomaly = Math.Acosh((data.Eccentricity + Math.Cos(data.TrueAnomaly)) /
                                        (1 + data.Eccentricity * Math.Cos(data.TrueAnomaly)));
        }
        else
        {
            result.Anomaly = Math.Tan(data.TrueAnomaly / 2);
        }

        return result;
    }

    public async Task<AnomalyToTrueAnomalyResultModel> AnomalyToTrueAnomaly(AnomalyToTrueAnomalyModel data)
    {
        if (data.AngleType == AngleDimension.Degrees)
        {
            data.Anomaly = data.Anomaly * (Math.PI / 180);
        }
        
        AnomalyToTrueAnomalyResultModel result = new AnomalyToTrueAnomalyResultModel();
        result.Eccentricity = data.Eccentricity;

        if (data.Eccentricity < 1)
        {
            result.TrueAnomaly = Math.Acos((Math.Cos(data.Anomaly) - data.Eccentricity) /
                                           (1 - data.Eccentricity * Math.Cos(data.Anomaly)));
        }
        else if (data.Eccentricity > 1)
        {
            result.TrueAnomaly = Math.Acos((Math.Cosh(data.Anomaly) - data.Eccentricity) /
                                           (1 - data.Eccentricity * Math.Cosh(data.Anomaly)));
        }
        else
        {
            result.TrueAnomaly = (data.P - data.R) / data.R;
        }
        
        return result;
    }
}
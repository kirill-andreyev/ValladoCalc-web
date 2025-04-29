using ValladoCalc.BusinessLogic.Models;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class KepEqtnService : IKepEqtnService
    {
        public async Task<KepEqtnEResultModel> CalculateEccenticAnomaly(KepEqtnEModel data)
        {
            double eccentricAnomaly;
            double eccentricAnomalyNext;

            if (data.AngleType == AngleDimension.Degrees)
            {
                data.MeanAnomality = data.MeanAnomality * (Math.PI / 180);
            }

            if (data.MeanAnomality > -Math.PI && data.MeanAnomality < 0)
            {
                eccentricAnomalyNext = data.MeanAnomality - data.Eccentricity;
            }
            else if (data.MeanAnomality > Math.PI)
            {
                eccentricAnomalyNext = data.MeanAnomality - data.Eccentricity;
            }
            else
            {
                eccentricAnomalyNext = data.MeanAnomality + data.Eccentricity;
            }

            do
            {
                eccentricAnomaly = eccentricAnomalyNext;
                eccentricAnomalyNext = eccentricAnomaly + ((data.MeanAnomality - eccentricAnomaly + data.Eccentricity * Math.Sin(eccentricAnomaly)) / (1 - data.Eccentricity * Math.Cos(eccentricAnomaly)));
            }
            while ((eccentricAnomalyNext - eccentricAnomaly) > data.Tolerance);

            return new KepEqtnEResultModel { EccentricAnomaly = eccentricAnomalyNext};
        }
        
        public async Task<KepEqtnPResultModel> CalculateParabolicAnomaly(KepEqtnPModel data)
        {
            if (data.TimeDimension == TimeDimension.Hours)
            {
                data.TimeDifference *= 3600;
            }
            else if (data.TimeDimension == TimeDimension.Minutes)
            {
                data.TimeDifference *= 60;
            }

            double meanMotion = 2 * Math.Sqrt(data.StandardGravitationalParameter / Math.Pow(data.SemiParameter, 3));

            double cotangent2s = 1.5 * meanMotion * data.TimeDifference;
            double s = Math.Atan(1 / cotangent2s) / 2;
            double tangentS = Math.Tan(s);
            double tangentLongitudeOfPeriapsis = Math.Cbrt(tangentS);
            double logitudeOfPeriasis = Math.Atan(tangentLongitudeOfPeriapsis);
            double parabolicAnomalyRadians = 2 * 1 / Math.Tan(2 * logitudeOfPeriasis);

            return new KepEqtnPResultModel { ParabolicAnomaly = parabolicAnomalyRadians };
        }
    }
}
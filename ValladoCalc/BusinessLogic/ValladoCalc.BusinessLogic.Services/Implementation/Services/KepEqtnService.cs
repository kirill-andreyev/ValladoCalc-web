using ValladoCalc.BusinessLogic.Models;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementation.Services
{
    public class KepEqtnService : IKepEqtnService
    {
        public async Task<KepEqtnEResultModel> CalculateEccenticAnomaly(KepEqtnEModel data)
        {
            if (data.Tolerance == 0)
            {
                data.Tolerance = 0.000001;
            }
            
            double eccentricAnomaly;
            double eccentricAnomalyNext;

            if (data.AngleType == AngleDimension.Degrees)
            {
                data.MeanAnomality = data.MeanAnomality * (Math.PI / 180);
            }

            if (data.MeanAnomality is > -Math.PI and < 0)
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
            if (data.StandardGravitationalParameter == 0)
            {
                data.StandardGravitationalParameter = 398600.4418;
            }
            
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

        public async Task<KepEqtnHResultModel> CalculateHyperbolicAnomaly(KepEqtnHModel data)
        {
            if (data.Tolerance == 0)
            {
                data.Tolerance = 0.000001;
            }
            
            double HyperbolicAnomaly;
            double HyperbolicAnomalyNext;
            
            if (data.AngleType == AngleDimension.Degrees)
            {
                data.MeanAnomality = data.MeanAnomality * (Math.PI / 180);
            }

            if (data.Eccentricity < 1.6)
            {
                if ((data.MeanAnomality > -Math.PI && data.MeanAnomality < 0) || data.MeanAnomality > Math.PI)
                {
                    HyperbolicAnomalyNext = data.MeanAnomality - data.Eccentricity;
                }
                else
                {
                    HyperbolicAnomalyNext = data.MeanAnomality + data.Eccentricity;
                }
            }
            else
            {
                if (data.Eccentricity < 3.6 && Math.Abs(data.MeanAnomality) > Math.PI)
                {
                    HyperbolicAnomalyNext = data.MeanAnomality - Math.Sign(data.MeanAnomality) * data.Eccentricity;
                }
                else
                {
                    HyperbolicAnomalyNext  = data.MeanAnomality / (data.Eccentricity - 1);
                }
            }

            do
            {
                HyperbolicAnomaly = HyperbolicAnomalyNext;
                HyperbolicAnomalyNext = HyperbolicAnomaly +
                                        ((data.MeanAnomality - data.Eccentricity * Math.Sinh(HyperbolicAnomaly) +
                                          HyperbolicAnomaly) / (data.Eccentricity * Math.Cosh(HyperbolicAnomaly) - 1));
            } while (HyperbolicAnomalyNext - HyperbolicAnomaly > data.Tolerance);

            return new KepEqtnHResultModel { HyperbolicAnomaly = HyperbolicAnomalyNext };
        }
    }
}
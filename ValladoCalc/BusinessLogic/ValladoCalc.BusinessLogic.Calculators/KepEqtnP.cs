using ValladoCalc.BusinessLogic.Models;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Calculators
{
    public static class KepEqtnP
    {
        public static KepEqtnPResultModel Calculate(KepEqtnPModel data)
        {
            if (data.TimeDimension == TimeDimension.Hours)
            {
                data.TimeDifference *= 3600m;
            }
            else if (data.TimeDimension == TimeDimension.Minutes)
            {
                data.TimeDifference *= 60m;
            }

            decimal meanMotion = 2 * (decimal)Math.Sqrt((double)data.StandardGravitationalParameter / Math.Pow((double)data.SemiParameter, 3));

            decimal cotangent2s = 1.5m * meanMotion * data.TimeDifference;
            decimal s = (decimal)Math.Atan(1 / (double)cotangent2s) / 2;
            decimal tangentS = (decimal)Math.Tan((double)s);
            decimal tangentLongitudeOfPeriapsis = (decimal)Math.Cbrt((double)tangentS);
            decimal logitudeOfPeriasis = (decimal)Math.Atan((double)tangentLongitudeOfPeriapsis);
            decimal parabolicAnomalyRadians = 2 * 1 / (decimal)Math.Tan(2 * (double)logitudeOfPeriasis);

            return new KepEqtnPResultModel { ParabolicAnomaly = parabolicAnomalyRadians };
        }
    }
}
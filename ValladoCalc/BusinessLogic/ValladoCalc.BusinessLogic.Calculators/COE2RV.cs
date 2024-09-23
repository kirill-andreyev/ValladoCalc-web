using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Calculators
{
    public static class COE2RV
    {
        public static COE2RVResultModel Calculate(COE2RVModel data)
        {
            if(data.ArgumentOfPerigee == 0 && data.AscendingNode == 0)
            {
                data.TrueAnomaly = data.TrueLongitude;
            }
            else if(data.ArgumentOfPerigee == 0)
            {
                data.TrueAnomaly = data.ArgumentOfLatitude;
            }
            else if(data.AscendingNode == 0)
            {
                data.ArgumentOfPerigee = data.TrueLongitudeOfPerigee;
            }

            COE2RVResultModel result = new COE2RVResultModel();

            result.RadiusVector =
            [
                data.SemiParameter * (decimal)Math.Cos((double)data.TrueAnomaly) / (1 + data.Eccentricity * (decimal)Math.Cos((double)data.TrueAnomaly)),
                data.SemiParameter * (decimal)Math.Sin((double)data.TrueAnomaly) / (1 + data.Eccentricity * (decimal)Math.Cos((double)data.TrueAnomaly)),
                0m
            ];

            result.SpeedVector =
           [
                - (decimal)Math.Sqrt((double)(data.StandardGravitationalParameter / data.SemiParameter)) * (decimal)Math.Sin((double)data.TrueAnomaly),
                (decimal)Math.Sqrt((double)(data.StandardGravitationalParameter / data.SemiParameter)) * (data.Eccentricity + (decimal)Math.Cos((double)data.TrueAnomaly)),
                0
           ];

            decimal[,] transformationMatrix =
            {
                { 
                    (decimal)Math.Cos((double)data.AscendingNode) * (decimal)Math.Cos((double)data.ArgumentOfPerigee) - (decimal)Math.Sin((double)data.AscendingNode) * (decimal)Math.Sin((double)data.ArgumentOfPerigee) * (decimal)Math.Cos((double)data.Inclination), 
                    -(decimal)Math.Cos((double)data.AscendingNode) * (decimal)Math.Sin((double)data.ArgumentOfPerigee) - (decimal)Math.Sin((double)data.AscendingNode) * (decimal)Math.Cos((double)data.ArgumentOfPerigee) * (decimal)Math.Cos((double)data.Inclination),
                    (decimal)Math.Sin((double)data.AscendingNode) * (decimal)Math.Sin((double)data.Inclination)
                },
                {
                    (decimal)Math.Sin((double)data.AscendingNode) * (decimal)Math.Cos((double)data.ArgumentOfPerigee) + (decimal)Math.Cos((double)data.AscendingNode)*(decimal)Math.Sin((double)data.ArgumentOfPerigee)*(decimal)Math.Cos((double)data.Inclination),
                    -(decimal)Math.Sin((double)data.AscendingNode) * (decimal)Math.Sin((double)data.ArgumentOfPerigee) + (decimal)Math.Cos((double)data.AscendingNode) * (decimal)Math.Cos((double)data.ArgumentOfPerigee) * (decimal)Math.Cos((double)data.Inclination),
                    -(decimal)Math.Cos((double)data.AscendingNode) * (decimal)Math.Sin((double)data.Inclination)
                },
                {
                    (decimal)Math.Sin((double)data.ArgumentOfPerigee)*(decimal)Math.Sin((double)data.Inclination),
                    (decimal)Math.Cos((double)data.ArgumentOfPerigee) * (decimal)Math.Sin((double)data.Inclination),
                    (decimal)Math.Cos((double)data.Inclination)
                }
            };

            result.RadiusVector =
            [
                transformationMatrix[0,0] * result.RadiusVector[0] + transformationMatrix[0,1] * result.RadiusVector[1],
                transformationMatrix[1,0] * result.RadiusVector[0] + transformationMatrix[1,1] * result.RadiusVector[1],
                transformationMatrix[2,0] * result.RadiusVector[0] + transformationMatrix[2,1] * result.RadiusVector[1],
            ];

            result.SpeedVector =
            [
                transformationMatrix[0,0] * result.SpeedVector[0] + transformationMatrix[0,1] * result.SpeedVector[1],
                transformationMatrix[1,0] * result.SpeedVector[0] + transformationMatrix[1,1] * result.SpeedVector[1],
                transformationMatrix[2,0] * result.SpeedVector[0] + transformationMatrix[2,1] * result.SpeedVector[1],
            ];

            return result;
        }
    }
}
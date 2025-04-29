using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementations.Services
{
    public class COE2RVService : ICOE2RVService
    {
        public async Task<COE2RVResultModel> CalculateVectors(COE2RVModel data)
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
                data.SemiParameter * Math.Cos(data.TrueAnomaly) / (1 + data.Eccentricity * Math.Cos(data.TrueAnomaly)),
                data.SemiParameter * Math.Sin(data.TrueAnomaly) / (1 + data.Eccentricity * Math.Cos(data.TrueAnomaly)),
                0
            ];

            result.VelocityVector =
           [
                - Math.Sqrt(data.StandardGravitationalParameter / data.SemiParameter) * Math.Sin(data.TrueAnomaly),
                Math.Sqrt(data.StandardGravitationalParameter / data.SemiParameter) * (data.Eccentricity + Math.Cos(data.TrueAnomaly)),
                0
           ];

            double[,] transformationMatrix =
            {
                { 
                    Math.Cos(data.AscendingNode) * Math.Cos(data.ArgumentOfPerigee) - Math.Sin(data.AscendingNode) * Math.Sin(data.ArgumentOfPerigee) * Math.Cos(data.Inclination), 
                    -Math.Cos(data.AscendingNode) * Math.Sin(data.ArgumentOfPerigee) - Math.Sin(data.AscendingNode) * Math.Cos(data.ArgumentOfPerigee) * Math.Cos(data.Inclination),
                    Math.Sin(data.AscendingNode) * Math.Sin(data.Inclination)
                },
                {
                    Math.Sin(data.AscendingNode) * Math.Cos(data.ArgumentOfPerigee) + Math.Cos(data.AscendingNode)*Math.Sin(data.ArgumentOfPerigee)*Math.Cos(data.Inclination),
                    -Math.Sin(data.AscendingNode) * Math.Sin(data.ArgumentOfPerigee) + Math.Cos(data.AscendingNode) * Math.Cos(data.ArgumentOfPerigee) * Math.Cos(data.Inclination),
                    -Math.Cos(data.AscendingNode) * Math.Sin(data.Inclination)
                },
                {
                    Math.Sin(data.ArgumentOfPerigee)*Math.Sin(data.Inclination),
                    Math.Cos(data.ArgumentOfPerigee) * Math.Sin(data.Inclination),
                    Math.Cos(data.Inclination)
                }
            };

            result.RadiusVector =
            [
                transformationMatrix[0,0] * result.RadiusVector[0] + transformationMatrix[0,1] * result.RadiusVector[1],
                transformationMatrix[1,0] * result.RadiusVector[0] + transformationMatrix[1,1] * result.RadiusVector[1],
                transformationMatrix[2,0] * result.RadiusVector[0] + transformationMatrix[2,1] * result.RadiusVector[1],
            ];

            result.VelocityVector =
            [
                transformationMatrix[0,0] * result.VelocityVector[0] + transformationMatrix[0,1] * result.VelocityVector[1],
                transformationMatrix[1,0] * result.VelocityVector[0] + transformationMatrix[1,1] * result.VelocityVector[1],
                transformationMatrix[2,0] * result.VelocityVector[0] + transformationMatrix[2,1] * result.VelocityVector[1],
            ];

            return result;
        }
    }
}

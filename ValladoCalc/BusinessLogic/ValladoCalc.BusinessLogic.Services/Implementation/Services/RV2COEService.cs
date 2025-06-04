using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementation.Services
{
    public class RV2COEService : IRV2COEService
    {
        public async Task<RV2COEResultModel> CalculateOrbitalParameters(RV2COEModel data)
        {
            if (data.StandardGravitationalParameter == 0)
            {
                data.StandardGravitationalParameter = 398600.4418;
            }
            
            double magnitudeOfRaduis = Math.Sqrt(data.RadiusVector[0] * data.RadiusVector[0] +
                                                 data.RadiusVector[1] * data.RadiusVector[1] +
                                                 data.RadiusVector[2] * data.RadiusVector[2]);

            double magnituteOfSpeed = Math.Sqrt(data.VelocityVector[0] * data.VelocityVector[0] +
                                                data.VelocityVector[1] * data.VelocityVector[1] + 
                                                data.VelocityVector[2] * data.VelocityVector[2]);

            double[] angularMomentum =
            [
                data.RadiusVector[1] * data.VelocityVector[2] - data.RadiusVector[2] * data.VelocityVector[1],
                -(data.RadiusVector[0] * data.VelocityVector[2] - data.RadiusVector[2] * data.VelocityVector[0]),
                data.RadiusVector[0] * data.VelocityVector[1] - data.RadiusVector[1] * data.VelocityVector[0],
            ];

            double magnitudeOfAngularMomentum = Math.Sqrt(angularMomentum[0] * angularMomentum[0] +
                                                          angularMomentum[1] * angularMomentum[1] +
                                                          angularMomentum[2] * angularMomentum[2]);

            double[] nodeVector =
            [
                -angularMomentum[1],
                angularMomentum[0],
            ];

            double magnitudeOfNodeVector = Math.Sqrt(nodeVector[0] * nodeVector[0] +
                                                     nodeVector[1] * nodeVector[1]);

            double eccentricityVectorPart = (magnituteOfSpeed * magnituteOfSpeed - data.StandardGravitationalParameter / magnitudeOfRaduis);
            double[] eccentricVectorPart1 =
            [
                eccentricityVectorPart * data.RadiusVector[0],
                eccentricityVectorPart * data.RadiusVector[1],
                eccentricityVectorPart * data.RadiusVector[2],
            ];
            double eccentricityVectorPart2 = data.RadiusVector[0] * data.VelocityVector[0] + data.RadiusVector[1] * data.VelocityVector[1] + data.RadiusVector[2] * data.VelocityVector[2];
            double[] eccentricityVectorPart3 =
            [
                eccentricityVectorPart2 * data.VelocityVector[0],
                eccentricityVectorPart2 * data.VelocityVector[1],
                eccentricityVectorPart2 * data.VelocityVector[2],
            ];
            double[] eccentricityVectorPart4 = 
            [
                eccentricVectorPart1[0] - eccentricityVectorPart3[0],
                eccentricVectorPart1[1] - eccentricityVectorPart3[1],
                eccentricVectorPart1[2] - eccentricityVectorPart3[2],
            ];

            double[] eccentricityVector = 
            [
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[0],
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[1],
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[2],
            ];

            double eccentricity = Math.Sqrt(eccentricityVector[0] * eccentricityVector[0] +
                                            eccentricityVector[1] * eccentricityVector[1] +
                                            eccentricityVector[2] * eccentricityVector[2]);

            double specificEnegry = ((magnituteOfSpeed * magnituteOfSpeed) / 2) - (data.StandardGravitationalParameter / magnitudeOfRaduis);

            double semiMajorAxis, semiParameter;

            if(eccentricity == 1)
            {
                semiMajorAxis = double.MaxValue;
                semiParameter = (magnitudeOfAngularMomentum * magnitudeOfAngularMomentum) / data.StandardGravitationalParameter;
            }
            else
            {
                semiMajorAxis = -data.StandardGravitationalParameter / (2 * specificEnegry);
                semiParameter = semiMajorAxis * (1 - eccentricity * eccentricity);
            }

            double cosInclination = angularMomentum[2] / magnitudeOfAngularMomentum;
            double cosAscendingNode = nodeVector[0] / magnitudeOfNodeVector;
            double cosLongitudeOfPerigee = (nodeVector[0] * eccentricityVector[0] + 
                nodeVector[1] * eccentricityVector[1]) /
                (magnitudeOfNodeVector * eccentricity);
            double cosTrueAnomaly = (eccentricityVector[0] * data.RadiusVector[0] + 
                eccentricityVector[1] * data.RadiusVector[1] + 
                eccentricityVector[2] * data.RadiusVector[2]) / 
                (eccentricity * magnitudeOfRaduis);
            double cosTrueLongitudeOfPerigee = eccentricityVector[0] / eccentricity;
            double cosArgumentOfLatitude = (nodeVector[0] * data.RadiusVector[0] + 
                nodeVector[1] * data.RadiusVector[1]) / 
                (magnitudeOfNodeVector * magnitudeOfRaduis);
            double cosTrueLongitude = data.RadiusVector[0] / magnitudeOfRaduis;

            RV2COEResultModel result = new RV2COEResultModel();

            result.SemiMajorAxis = semiMajorAxis;
            result.SemiParameter = semiParameter;
            result.Eccentricity = eccentricity;

            result.Inclination = Math.Acos(cosInclination);

            if (nodeVector[1] < 0)
            {
                result.AscendingNode = 2 * Math.PI - Math.Acos(cosAscendingNode);
            }
            else
            {
                result.AscendingNode = Math.Acos(cosAscendingNode);
            }

            if (eccentricityVector[2] < 0)
            {
                result.ArgumentOfPerigee = 2 * Math.PI - Math.Acos(cosLongitudeOfPerigee);
            }
            else
            {
                result.ArgumentOfPerigee = Math.Acos(cosLongitudeOfPerigee);
            }

            if (data.VelocityVector[0] * data.RadiusVector[0] + data.VelocityVector[1] * data.RadiusVector[1] + data.VelocityVector[2] * data.RadiusVector[2] < 0)
            {
                result.TrueAnomaly = 2 * Math.PI - Math.Acos(cosTrueAnomaly);
            }
            else
            {
                result.TrueAnomaly = Math.Acos(cosTrueAnomaly);
            }

            result.LongitudeOfPerigee = result.AscendingNode + result.ArgumentOfPerigee;

            if (eccentricityVector[1] < 0)
            {
                result.TrueLongitudeOfPerigee = 2 * Math.PI - Math.Acos(cosTrueLongitudeOfPerigee);
            }
            else
            {
                result.TrueLongitudeOfPerigee = Math.Acos(cosTrueLongitudeOfPerigee);
            }

            if (data.RadiusVector[2] < 0)
            {
                result.ArgumentOfLatitude = 2 * Math.PI - Math.Acos(cosArgumentOfLatitude);
            }
            else
            {
                result.ArgumentOfLatitude = Math.Acos(cosArgumentOfLatitude);
            }

            if (data.RadiusVector[1] < 0)
            {
                result.TrueLongitude = 2 * Math.PI - Math.Acos(cosTrueLongitude);
            }
            else
            {
                result.TrueLongitude = Math.Acos(cosTrueLongitude);
            }

            return result;
        }
    }
}
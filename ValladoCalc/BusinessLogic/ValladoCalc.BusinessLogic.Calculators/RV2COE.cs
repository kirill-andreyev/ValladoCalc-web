using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;

namespace ValladoCalc.BusinessLogic.Calculators
{
    public static class RV2COE
    {
        public static RV2COEResultModel Calculate(RV2COEModel data)
        {
            decimal magnitudeOfRaduis = (decimal)Math.Sqrt((double)(data.RadiusVector[0] * data.RadiusVector[0]) +
                (double)(data.RadiusVector[1] * data.RadiusVector[1]) +
                (double)(data.RadiusVector[2] * data.RadiusVector[2]));

            decimal magnituteOfSpeed = (decimal)Math.Sqrt((double)(data.SpeedVector[0] * data.SpeedVector[0]) +
                (double)(data.SpeedVector[1] * data.SpeedVector[1]) + 
                (double)(data.SpeedVector[2] * data.SpeedVector[2]));

            decimal[] angularMomentum =
            [
                data.RadiusVector[1] * data.SpeedVector[2] - data.RadiusVector[2] * data.SpeedVector[1],
                -(data.RadiusVector[0] * data.SpeedVector[2] - data.RadiusVector[2] * data.SpeedVector[0]),
                data.RadiusVector[0] * data.SpeedVector[1] - data.RadiusVector[1] * data.SpeedVector[0],
            ];

            decimal magnitudeOfAngularMomentum = (decimal)Math.Sqrt((double)(angularMomentum[0] * angularMomentum[0]) +
                (double)(angularMomentum[1] * angularMomentum[1]) +
                (double)(angularMomentum[2] * angularMomentum[2]));

            decimal[] nodeVector =
            [
                -angularMomentum[1],
                angularMomentum[0],
            ];

            decimal magnitudeOfNodeVector = (decimal)Math.Sqrt((double)(nodeVector[0] * nodeVector[0]) +
                (double)(nodeVector[1] * nodeVector[1]));

            decimal eccentricityVectorPart = (magnituteOfSpeed * magnituteOfSpeed - data.StandardGravitationalParameter / magnitudeOfRaduis);
            decimal[] eccentricVectorPart1 =
            [
                eccentricityVectorPart * data.RadiusVector[0],
                eccentricityVectorPart * data.RadiusVector[1],
                eccentricityVectorPart * data.RadiusVector[2],
            ];
            decimal eccentricityVectorPart2 = data.RadiusVector[0] * data.SpeedVector[0] + data.RadiusVector[1] * data.SpeedVector[1] + data.RadiusVector[2] * data.SpeedVector[2];
            decimal[] eccentricityVectorPart3 =
            [
                eccentricityVectorPart2 * data.SpeedVector[0],
                eccentricityVectorPart2 * data.SpeedVector[1],
                eccentricityVectorPart2 * data.SpeedVector[2],
            ];
            decimal[] eccentricityVectorPart4 = 
            [
                eccentricVectorPart1[0] - eccentricityVectorPart3[0],
                eccentricVectorPart1[1] - eccentricityVectorPart3[1],
                eccentricVectorPart1[2] - eccentricityVectorPart3[2],
            ];

            decimal[] eccentricityVector = 
            [
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[0],
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[1],
                1 / data.StandardGravitationalParameter * eccentricityVectorPart4[2],
            ];

            decimal eccentricity = (decimal)Math.Sqrt((double)(eccentricityVector[0] * eccentricityVector[0]) +
                (double)(eccentricityVector[1] * eccentricityVector[1]) +
                (double)(eccentricityVector[2] * eccentricityVector[2]));

            decimal specificEnegry = ((magnituteOfSpeed * magnituteOfSpeed) / 2) - (data.StandardGravitationalParameter / magnitudeOfRaduis);

            decimal semiMajorAxis, semiParameter;

            if(eccentricity == 1)
            {
                semiMajorAxis = decimal.MaxValue;
                semiParameter = (magnitudeOfAngularMomentum * magnitudeOfAngularMomentum) / data.StandardGravitationalParameter;
            }
            else
            {
                semiMajorAxis = -data.StandardGravitationalParameter / (2 * specificEnegry);
                semiParameter = semiMajorAxis * (1 - eccentricity * eccentricity);
            }

            decimal cosInclination = angularMomentum[2] / magnitudeOfAngularMomentum;
            decimal cosAscendingNode = nodeVector[0] / magnitudeOfNodeVector;
            decimal cosLongitudeOfPerigee = (nodeVector[0] * eccentricityVector[0] + 
                nodeVector[1] * eccentricityVector[1]) /
                (magnitudeOfNodeVector * eccentricity);
            decimal cosTrueAnomaly = (eccentricityVector[0] * data.RadiusVector[0] + 
                eccentricityVector[1] * data.RadiusVector[1] + 
                eccentricityVector[2] * data.RadiusVector[2]) / 
                (eccentricity * magnitudeOfRaduis);
            decimal cosTrueLongitudeOfPerigee = eccentricityVector[0] / eccentricity;
            decimal cosArgumentOfLatitude = (nodeVector[0] * data.RadiusVector[0] + 
                nodeVector[1] * data.RadiusVector[1]) / 
                (magnitudeOfNodeVector * magnitudeOfRaduis);
            decimal cosTrueLongitude = data.RadiusVector[0] / magnitudeOfRaduis;

            RV2COEResultModel result = new RV2COEResultModel();

            result.SemiMajorAxis = semiMajorAxis;
            result.SemiParameter = semiParameter;
            result.Eccentricity = eccentricity;

            result.Inclination = (decimal)Math.Acos((double)cosInclination);

            if (nodeVector[1] < 0)
            {
                result.AscendingNode = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosAscendingNode);
            }
            else
            {
                result.AscendingNode = (decimal)Math.Acos((double)cosAscendingNode);
            }

            if (eccentricityVector[2] < 0)
            {
                result.ArgumentOfPerigee = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosLongitudeOfPerigee);
            }
            else
            {
                result.ArgumentOfPerigee = (decimal)Math.Acos((double)cosLongitudeOfPerigee);
            }

            if (data.SpeedVector[0] * data.RadiusVector[0] + data.SpeedVector[1] * data.RadiusVector[1] + data.SpeedVector[2] * data.RadiusVector[2] < 0)
            {
                result.TrueAnomaly = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosTrueAnomaly);
            }
            else
            {
                result.TrueAnomaly = (decimal)Math.Acos((double)cosTrueAnomaly);
            }

            result.LongituteOfPerigee = result.AscendingNode + result.ArgumentOfPerigee;

            if (eccentricityVector[1] < 0)
            {
                result.TrueLongitudeOfPerigee = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosTrueLongitudeOfPerigee);
            }
            else
            {
                result.TrueLongitudeOfPerigee = (decimal)Math.Acos((double)cosTrueLongitudeOfPerigee);
            }

            if (data.RadiusVector[2] < 0)
            {
                result.ArgumentOfLatitude = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosArgumentOfLatitude);
            }
            else
            {
                result.ArgumentOfLatitude = (decimal)Math.Acos((double)cosArgumentOfLatitude);
            }

            if (data.RadiusVector[1] < 0)
            {
                result.TrueLongitude = 2m * (decimal)Math.PI - (decimal)Math.Acos((double)cosTrueLongitude);
            }
            else
            {
                result.TrueLongitude = (decimal)Math.Acos((double)cosTrueLongitude);
            }

            return result;
        }
    }
}
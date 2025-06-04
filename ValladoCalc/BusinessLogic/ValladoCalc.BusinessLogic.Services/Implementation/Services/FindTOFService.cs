using ValladoCalc.BusinessLogic.Models;
using ValladoCalc.BusinessLogic.Models.ExportModels;
using ValladoCalc.BusinessLogic.Models.ImportModels;
using ValladoCalc.BusinessLogic.Services.Interfaces.Services;

namespace ValladoCalc.BusinessLogic.Services.Implementation.Services
{
    public class FindTOFService : IFindTOFService
    {
        public async Task<FindTOFResultModel> FindTOF(FindTOFModel data)
        {
            if (data.StandardGravitationalParameter == 0)
            {
                data.StandardGravitationalParameter = 398600.4418;
            }
            
            var vectorMultiply = data.Radius0Vector[0] * data.RadiusVector[0] + data.Radius0Vector[1] * data.RadiusVector[1] + data.Radius0Vector[2] * data.RadiusVector[2];
            var vectorsLenght =
                Math.Sqrt(data.Radius0Vector[0] * data.Radius0Vector[0] +
                          data.Radius0Vector[1] * data.Radius0Vector[1] +
                          data.Radius0Vector[2] * data.Radius0Vector[2]) * 
                Math.Sqrt(data.RadiusVector[0] * data.RadiusVector[0] + 
                          data.RadiusVector[1] * data.RadiusVector[1] +
                          data.RadiusVector[2] * data.RadiusVector[2]);
            
            var cosOfTrueAnomaly = vectorMultiply / vectorsLenght;
            
            var k = vectorsLenght * (1 - cosOfTrueAnomaly);
            var l = Math.Sqrt(data.Radius0Vector[0] * data.Radius0Vector[0] + 
                              data.Radius0Vector[1] * data.Radius0Vector[1] +
                              data.Radius0Vector[2] * data.Radius0Vector[2]) +
                    Math.Sqrt(data.RadiusVector[0] * data.RadiusVector[0] + 
                              data.RadiusVector[1] * data.RadiusVector[1] +
                              data.RadiusVector[2] * data.RadiusVector[2]);
            
            var m = vectorsLenght * (1 + cosOfTrueAnomaly);
            var a = (m * k * data.SemiParameter) / ((2 * m - l * l) * data.SemiParameter * data.SemiParameter +
                2 * k * l * data.SemiParameter - k * k);
            var r = Math.Sqrt(data.RadiusVector[0] * data.RadiusVector[0] + 
                              data.RadiusVector[1] * data.RadiusVector[1] +
                              data.RadiusVector[2] * data.RadiusVector[2]);
            var r0 = Math.Sqrt(data.Radius0Vector[0] * data.Radius0Vector[0] + 
                              data.Radius0Vector[1] * data.Radius0Vector[1] +
                              data.Radius0Vector[2] * data.Radius0Vector[2]);
            var f = 1 - (r/data.SemiParameter) * (1 - cosOfTrueAnomaly);
            var sinOfTrueAnomaly = Math.Sqrt(1 - cosOfTrueAnomaly * cosOfTrueAnomaly);
            var g = (vectorsLenght * sinOfTrueAnomaly) /
                    (Math.Sqrt(data.StandardGravitationalParameter * data.SemiParameter));

            if (a > 0)
            {
                var f1 = Math.Sqrt(data.StandardGravitationalParameter / data.SemiParameter) * Math.Tan(Math.Atan(cosOfTrueAnomaly) / 2) * ((1 - cosOfTrueAnomaly)/data.SemiParameter - 1/r0 - 1/r);
                var sinDeltaE = (-r0 * r * f1) / Math.Sqrt(data.StandardGravitationalParameter * a);
                return new FindTOFResultModel
                {
                    TOF = g + Math.Sqrt((a * a * a) / data.StandardGravitationalParameter) *
                        (Math.Asin(sinDeltaE) - sinDeltaE)
                };
            }
            else if (a < 0)
            {
                var coshDeltaH = 1 + (f - 1) * (r0 / a);
                return new FindTOFResultModel
                {
                    TOF = g + Math.Sqrt((-a * -a * -a) / data.StandardGravitationalParameter) *
                        (Math.Sqrt(1 - coshDeltaH * coshDeltaH) - Math.Acos(coshDeltaH))
                };
            }
            else if(double.IsPositiveInfinity(a))
            {
                var c = Math.Sqrt(r0 * r0 - 2 * r0 * r * cosOfTrueAnomaly);
                var s = (r0 + r + c) / 2;
                return new FindTOFResultModel
                {
                    TOF = 2.0 / 3.0 * Math.Sqrt((s * s * s) / 2 * data.StandardGravitationalParameter) *
                          (1 - Math.Pow((s - c) / s, 3.0 / 2.0))
                };
            }
            
            return null;
        }
    }
}
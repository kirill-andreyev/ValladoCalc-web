using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class KepEqtnEModel
    {
        public KepEqtnEModel() { }
        public KepEqtnEModel(KepEqtnEModel oldModel)
        {
            this.Eccentricity = oldModel.Eccentricity;
            this.Tolerance = oldModel.Tolerance;
            this.AngleType = oldModel.AngleType;
            this.MeanAnomality = oldModel.MeanAnomality;
        }

        
        [Required]
        [JsonPropertyName("meanAnomality")]
        public double MeanAnomality { get; set; }
        
        [JsonPropertyName("tolerance")]
        public double Tolerance { get; set; }
        
        [Required]
        [JsonPropertyName("eccentricity")]
        public double Eccentricity { get; set; }
        
        [Required]
        [JsonPropertyName("angleType")]
        public AngleDimension AngleType { get; set; }
    }
}
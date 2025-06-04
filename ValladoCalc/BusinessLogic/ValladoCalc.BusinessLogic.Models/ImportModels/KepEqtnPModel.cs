using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class KepEqtnPModel
    {
        public KepEqtnPModel() { }
        public KepEqtnPModel(KepEqtnPModel other)
        {
            this.TimeDifference = other.TimeDifference;
            this.SemiParameter = other.SemiParameter;
            this.StandardGravitationalParameter = other.StandardGravitationalParameter;
            this.TimeDimension = other.TimeDimension;
        }

        [Required]
        [JsonPropertyName("timeDifference")]
        public double TimeDifference { get; set; }
        
        [Required]
        [JsonPropertyName("semiParameter")]
        public double SemiParameter { get; set; }

        [JsonPropertyName("standardGravitationalParameter")]
        public double StandardGravitationalParameter { get; set; }
        
        [Required]
        [JsonPropertyName("timeDimension")]
        public TimeDimension TimeDimension { get; set; }

    }
}
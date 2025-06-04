using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class RV2COEModel
    {
        public RV2COEModel() 
        {
            RadiusVector = new Double[3];
            VelocityVector = new Double[3];
        }

        public RV2COEModel(RV2COEModel model)
        {
            RadiusVector = new Double[3];
            VelocityVector = new Double[3];

            for(int i = 0; i < 3; i++)
            {
                this.VelocityVector[i] = model.VelocityVector[i];
            }
            for(int i = 0;i < 3; i++)
            {
                this.RadiusVector[i] = model.RadiusVector[i];
            }

            this.StandardGravitationalParameter = model.StandardGravitationalParameter;
        }

        [Required]
        [JsonPropertyName("radiusVector")]
        public double[] RadiusVector { get; set; }
        
        [Required]
        [JsonPropertyName("velocityVector")]
        public double[] VelocityVector { get; set; }

        [JsonPropertyName("standardGravitationalParameter")]
        public double StandardGravitationalParameter { get; set; }
    }
}
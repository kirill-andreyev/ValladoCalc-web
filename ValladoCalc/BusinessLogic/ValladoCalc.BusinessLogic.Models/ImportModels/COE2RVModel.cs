using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class COE2RVModel
    {
        public COE2RVModel() { }

        public COE2RVModel(COE2RVModel model)
        {
            this.SemiParameter = model.SemiParameter;
            this.Eccentricity = model.Eccentricity;
            this.Inclination = model.Inclination;
            this.AscendingNode = model.AscendingNode;
            this.ArgumentOfPerigee = model.ArgumentOfPerigee;
            this.TrueAnomaly = model.TrueAnomaly;
            this.ArgumentOfLatitude = model.ArgumentOfLatitude;
            this.TrueLongitude = model.TrueLongitude;
            this.TrueLongitudeOfPerigee = model.TrueLongitudeOfPerigee;
            this.StandardGravitationalParameter = model.StandardGravitationalParameter;
        }

        [Required]
        [JsonPropertyName("semiParameter")]
        public double SemiParameter { get; set; }
        
        [Required]
        [JsonPropertyName("eccentricity")]
        public double Eccentricity { get; set; }
        
        [Required]
        [JsonPropertyName("inclination")]
        public double Inclination { get; set; }
        
        [Required]
        [JsonPropertyName("ascendingNode")]
        public double AscendingNode { get; set; }
        
        [Required]
        [JsonPropertyName("argumentOfPerigee")]
        public double ArgumentOfPerigee { get; set; }
        
        [Required]
        [JsonPropertyName("trueAnomaly")]
        public double TrueAnomaly { get; set; }
        
        [Required]
        [JsonPropertyName("argumentOfLatitude")]
        public double ArgumentOfLatitude { get; set; }
        
        [Required]
        [JsonPropertyName("trueLongitude")]
        public double TrueLongitude { get; set; }
        
        [Required]
        [JsonPropertyName("trueLongitudeOfPerigee")]
        public double TrueLongitudeOfPerigee { get; set; }

        [JsonPropertyName("standardGravitationalParameter")]
        public double StandardGravitationalParameter { get; set; }

    }
}
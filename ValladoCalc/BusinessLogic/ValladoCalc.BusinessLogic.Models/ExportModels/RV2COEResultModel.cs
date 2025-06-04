using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels
{
    public class RV2COEResultModel
    {
        [JsonPropertyName("semiParameter")]
        public double SemiParameter { get; set; }
        
        [JsonPropertyName("semiMajorAxis")]
        public double SemiMajorAxis { get; set; }
        
        [JsonPropertyName("eccentricity")]
        public double Eccentricity { get; set; }
        
        [JsonPropertyName("inclination")]
        public double Inclination { get; set; }
        
        [JsonPropertyName("ascendingNode")]
        public double AscendingNode { get; set; }
        
        [JsonPropertyName("argumentOfPerigee")]
        public double ArgumentOfPerigee { get; set; }
        
        [JsonPropertyName("longitudeOfPerigee")]
        public double LongitudeOfPerigee { get; set; }
        
        [JsonPropertyName("trueAnomaly")]
        public double TrueAnomaly { get; set; }
        
        [JsonPropertyName("argumentOfLatitude")]
        public double ArgumentOfLatitude { get; set; }
        
        [JsonPropertyName("trueLongitude")]
        public double TrueLongitude { get; set; }
        
        [JsonPropertyName("trueLongitudeOfPerigee")]
        public double TrueLongitudeOfPerigee { get; set; }
    }
}
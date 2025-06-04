using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class AnomalyToTrueAnomalyModel
{
    [Required]
    [JsonPropertyName("eccentricity")]
    public double Eccentricity { get; set; }
    
    [JsonPropertyName("anomaly")]
    public double Anomaly { get; set; }
    
    [JsonPropertyName("p")]
    public double P { get; set; }
    
    [JsonPropertyName("r")]
    public double R { get; set; }
    
    [JsonPropertyName("angleType")]
    public AngleDimension AngleType { get; set; }
}
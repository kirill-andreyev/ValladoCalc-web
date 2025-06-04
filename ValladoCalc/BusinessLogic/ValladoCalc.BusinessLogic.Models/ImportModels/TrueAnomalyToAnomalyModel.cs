using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class TrueAnomalyToAnomalyModel
{
    [Required]
    [JsonPropertyName("eccentricity")]
    public double Eccentricity { get; set; }
    
    [Required]
    [JsonPropertyName("trueAnomaly")]
    public double TrueAnomaly { get; set; }
    
    [Required]
    [JsonPropertyName("angleType")]
    public AngleDimension AngleType { get; set; }
}
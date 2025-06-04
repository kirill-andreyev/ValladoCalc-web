using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class KeplerCOEModel
{
    [Required]
    [JsonPropertyName("vectors")]
    public RV2COEModel vectors { get; set; }
    
    [Required]
    [JsonPropertyName("deltaT")]
    public double deltaT { get; set; }
}
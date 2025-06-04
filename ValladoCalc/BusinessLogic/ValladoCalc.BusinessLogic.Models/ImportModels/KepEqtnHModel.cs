using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class KepEqtnHModel
{
    public KepEqtnHModel() { }
    public KepEqtnHModel(KepEqtnEModel oldModel)
    {
        this.Eccentricity = oldModel.Eccentricity;
        this.Tolerance = oldModel.Tolerance;
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
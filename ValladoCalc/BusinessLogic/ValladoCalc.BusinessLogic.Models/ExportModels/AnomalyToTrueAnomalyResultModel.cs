using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels;

public class AnomalyToTrueAnomalyResultModel
{
    [JsonPropertyName("eccentricity")]
    public double Eccentricity { get; set; }
    
    [JsonPropertyName("trueAnomaly")]
    public double TrueAnomaly { get; set; }
}
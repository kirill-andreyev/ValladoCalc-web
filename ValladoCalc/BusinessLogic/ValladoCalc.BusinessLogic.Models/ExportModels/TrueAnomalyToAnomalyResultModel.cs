using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels;

public class TrueAnomalyToAnomalyResultModel
{
    [JsonPropertyName("anomaly")]
    public double Anomaly { get; set; }
    
    [JsonPropertyName("eccentricity")]
    public double Eccentricity { get; set; }
}
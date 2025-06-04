using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels;

public class KepEqtnHResultModel
{
    [JsonPropertyName("hyperbolicAnomaly")]
    public double HyperbolicAnomaly { get; set; }
}
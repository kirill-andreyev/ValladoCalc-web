using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels;

public class PsiToC2C3ResultModel
{
    [JsonPropertyName("c2")]
    public double C2 { get; set; }
    [JsonPropertyName("c3")]
    public double C3 { get; set; }
}
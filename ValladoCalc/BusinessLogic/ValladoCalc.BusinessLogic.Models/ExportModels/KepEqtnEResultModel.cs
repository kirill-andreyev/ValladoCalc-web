using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels
{
    public class KepEqtnEResultModel
    {
        [JsonPropertyName("eccentricAnomaly")]
        public double EccentricAnomaly { get; set; }
    }
}
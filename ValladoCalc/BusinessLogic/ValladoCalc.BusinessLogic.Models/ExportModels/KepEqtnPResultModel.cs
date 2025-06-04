using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ExportModels
{
    public class KepEqtnPResultModel
    {
        [JsonPropertyName("parabolicAnomaly")]
        public double ParabolicAnomaly { get; set; }
    }
}
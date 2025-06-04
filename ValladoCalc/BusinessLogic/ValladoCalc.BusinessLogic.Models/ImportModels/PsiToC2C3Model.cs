using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class PsiToC2C3Model
{
    [Required]
    [JsonPropertyName("psi")]
    public double Psi { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValladoCalc.BusinessLogic.Models.ImportModels;

public class FindTOFModel
{
    public FindTOFModel() 
    {
        RadiusVector = new Double[3];
        Radius0Vector = new Double[3];
    }

    public FindTOFModel(FindTOFModel model)
    {
        Radius0Vector = new Double[3];
        RadiusVector = new Double[3];

        for(int i = 0; i < 3; i++)
        {
            this.RadiusVector[i] = model.RadiusVector[i];
        }
        for(int i = 0;i < 3; i++)
        {
            this.Radius0Vector[i] = model.Radius0Vector[i];
        }

        this.SemiParameter = model.SemiParameter;
    }

    [Required]
    [JsonPropertyName("radius0Vector")]
    public double[] Radius0Vector { get; set; }
        
    [Required]
    [JsonPropertyName("radiusVector")]
    public double[] RadiusVector { get; set; }

    [JsonPropertyName("semiParameter")]
    public double SemiParameter { get; set; }
    
    [JsonPropertyName("standardGravitationalParameter")]
    public double StandardGravitationalParameter { get; set; }
}
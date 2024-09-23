namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class KepEqtnEModel
    {
        public KepEqtnEModel() { }
        public KepEqtnEModel(KepEqtnEModel oldModel)
        {
            this.Eccentricity = oldModel.Eccentricity;
            this.Tolerance = oldModel.Tolerance;
            this.AngleType = oldModel.AngleType;
            this.MeanAnomality = oldModel.MeanAnomality;
        }

        public decimal MeanAnomality { get; set; }
        public decimal Tolerance { get; set; }
        public decimal Eccentricity { get; set; }
        public AngleDimension AngleType { get; set; }
    }
}
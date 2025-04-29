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

        public double MeanAnomality { get; set; }
        public double Tolerance { get; set; }
        public double Eccentricity { get; set; }
        public AngleDimension AngleType { get; set; }
    }
}
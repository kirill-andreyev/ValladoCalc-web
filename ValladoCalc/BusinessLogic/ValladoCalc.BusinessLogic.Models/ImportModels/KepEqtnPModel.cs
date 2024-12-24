namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class KepEqtnPModel
    {
        public KepEqtnPModel() { }
        public KepEqtnPModel(KepEqtnPModel other)
        {
            this.TimeDifference = other.TimeDifference;
            this.SemiParameter = other.SemiParameter;
            this.StandardGravitationalParameter = other.StandardGravitationalParameter;
            this.TimeDimension = other.TimeDimension;
        }

        public decimal TimeDifference { get; set; }
        public decimal SemiParameter { get; set; }
        public decimal StandardGravitationalParameter { get; set; }
        public TimeDimension TimeDimension { get; set; }

    }
}
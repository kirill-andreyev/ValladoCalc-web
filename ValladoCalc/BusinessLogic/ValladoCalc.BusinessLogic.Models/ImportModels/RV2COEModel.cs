namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class RV2COEModel
    {
        public RV2COEModel() 
        {
            RadiusVector = new Double[3];
            VelocityVector = new Double[3];
        }

        public RV2COEModel(RV2COEModel model)
        {
            RadiusVector = new Double[3];
            VelocityVector = new Double[3];

            for(int i = 0; i < 3; i++)
            {
                this.VelocityVector[i] = model.VelocityVector[i];
            }
            for(int i = 0;i < 3; i++)
            {
                this.RadiusVector[i] = model.RadiusVector[i];
            }

            this.StandardGravitationalParameter = model.StandardGravitationalParameter;
        }

        public double[] RadiusVector { get; set; }
        public double[] VelocityVector { get; set; }
        public double StandardGravitationalParameter { get; set; }
    }
}
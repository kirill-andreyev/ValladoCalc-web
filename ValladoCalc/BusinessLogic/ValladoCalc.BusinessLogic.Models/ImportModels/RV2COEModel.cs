﻿using System.Numerics;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class RV2COEModel
    {
        public RV2COEModel() 
        {
            RadiusVector = new decimal[3];
            VelocityVector = new decimal[3];
        }

        public RV2COEModel(RV2COEModel model)
        {
            RadiusVector = new decimal[3];
            VelocityVector = new decimal[3];

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

        public decimal[] RadiusVector { get; set; }
        public decimal[] VelocityVector { get; set; }
        public decimal StandardGravitationalParameter { get; set; }
    }
}
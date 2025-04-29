using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValladoCalc.BusinessLogic.Models.ExportModels
{
    public class COE2RVResultModel
    {
        public COE2RVResultModel()
        {
            RadiusVector = new Double[3];
            VelocityVector = new Double[3];
        }

        public double[] RadiusVector { get; set; }
        public double[] VelocityVector { get; set; }
    }
}
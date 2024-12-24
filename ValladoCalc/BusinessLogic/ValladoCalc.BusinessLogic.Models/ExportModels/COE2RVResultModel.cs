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
            RadiusVector = new decimal[3];
            VelocityVector = new decimal[3];
        }

        public decimal[] RadiusVector { get; set; }
        public decimal[] VelocityVector { get; set; }
    }
}
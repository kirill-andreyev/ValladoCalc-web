using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValladoCalc.BusinessLogic.Models.ExportModels
{
    public class COE2RVModel
    {
        public COE2RVModel()
        {
            RadiusVector = new decimal[3];
            SpeedVector = new decimal[3];
        }

        public decimal[] RadiusVector { get; set; }
        public decimal[] SpeedVector { get; set; }
    }
}
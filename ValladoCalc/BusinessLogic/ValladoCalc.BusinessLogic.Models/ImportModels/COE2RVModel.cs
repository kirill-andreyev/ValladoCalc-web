using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValladoCalc.BusinessLogic.Models.ImportModels
{
    public class COE2RVModel
    {
        public COE2RVModel() { }

        public COE2RVModel(COE2RVModel model)
        {
            this.SemiParameter = model.SemiParameter;
            this.Eccentricity = model.Eccentricity;
            this.Inclination = model.Inclination;
            this.AscendingNode = model.AscendingNode;
            this.ArgumentOfPerigee = model.ArgumentOfPerigee;
            this.TrueAnomaly = model.TrueAnomaly;
            this.ArgumentOfLatitude = model.ArgumentOfLatitude;
            this.TrueLongitude = model.TrueLongitude;
            this.TrueLongitudeOfPerigee = model.TrueLongitudeOfPerigee;
            this.StandardGravitationalParameter = model.StandardGravitationalParameter;
        }

        public decimal SemiParameter { get; set; }
        public decimal Eccentricity { get; set; }
        public decimal Inclination { get; set; }
        public decimal AscendingNode { get; set; }
        public decimal ArgumentOfPerigee { get; set; }
        public decimal TrueAnomaly { get; set; }
        public decimal ArgumentOfLatitude { get; set; }
        public decimal TrueLongitude { get; set; }
        public decimal TrueLongitudeOfPerigee { get; set; }
        public decimal StandardGravitationalParameter { get; set; }

    }
}
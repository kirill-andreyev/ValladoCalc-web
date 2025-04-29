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

        public double SemiParameter { get; set; }
        public double Eccentricity { get; set; }
        public double Inclination { get; set; }
        public double AscendingNode { get; set; }
        public double ArgumentOfPerigee { get; set; }
        public double TrueAnomaly { get; set; }
        public double ArgumentOfLatitude { get; set; }
        public double TrueLongitude { get; set; }
        public double TrueLongitudeOfPerigee { get; set; }
        public double StandardGravitationalParameter { get; set; }

    }
}
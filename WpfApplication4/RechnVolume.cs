using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    class RechnVolume
    {

        private const double CubicFeet2CubicMeter = 0.0283168;
        private const double CubicFeet2Barrel = 0.237476809;

        private List<long> tops;
        private RechnParameters rpm;

        public RechnVolume(List<long> tops, ref RechnParameters rechnParam)
        {
            this.tops = tops;
            this.rpm = rechnParam;
        }

        public double ReVolume()
        {
            double vol = 0.0;
            double sum = 0.0;
            double bot = 0.0;
            
            

            foreach (long top in tops)
            {
                bot = top + rpm.BASEDELTA;
                sum += top >= rpm.FLUIDCONTACT ? 0.0 : bot > rpm.FLUIDCONTACT ? rpm.FLUIDCONTACT - top : bot - top;
            }

            switch (rpm.UNIT)
            {
                case VolumeUnit.CubicFeet:
                    vol = rpm.CELLAREA * sum;
                    break;
                case VolumeUnit.CubicMeter:
                    vol = rpm.CELLAREA * sum * CubicFeet2CubicMeter;
                    break;
                case VolumeUnit.Barrel:
                    vol = rpm.CELLAREA * sum * CubicFeet2Barrel;
                    break;
                default:
                    break;
            }

            return vol;
        }
    }
}

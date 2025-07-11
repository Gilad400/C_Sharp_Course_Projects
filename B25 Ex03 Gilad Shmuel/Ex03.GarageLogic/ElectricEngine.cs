using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryTimeInHours, float i_BatteryTimeLeftInHours)
            : base(i_MaxBatteryTimeInHours, i_BatteryTimeLeftInHours)
        {
        }

        public void ChargeBattery(float i_HoursAmount)
        {
            AddEnergy(i_HoursAmount);
        }

        public override string ToString()
        {
            return string.Format("Battery Time: {0}, Max: {1}", CurrentEnergy, MaxEnergy);
        }
    }
}

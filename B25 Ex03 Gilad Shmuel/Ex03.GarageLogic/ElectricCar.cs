using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const string k_CurrentBatteryTimeKey = "CurrentBatteryTime (hours)";

        public ElectricCar(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
            Engine = new ElectricEngine(4.8f, 0f);
        }

        public override List<string> GetVehicleSpecificDataRequirements()
        {
            List<string> requirements = base.GetVehicleSpecificDataRequirements();

            requirements.Add(k_CurrentBatteryTimeKey);

            return requirements;
        }

        public override void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            base.SetVehicleSpecificProperties(i_VehicleData);
            if (i_VehicleData.ContainsKey(k_CurrentBatteryTimeKey))
            {
                if (float.TryParse(i_VehicleData[k_CurrentBatteryTimeKey], out float battery))
                {
                    ((ElectricEngine)Engine).ChargeBattery(battery);
                }
                else
                {
                    throw new FormatException("Current battery time has to be a number");
                }
            }
        }
    }
}

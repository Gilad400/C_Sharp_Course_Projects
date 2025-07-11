using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        private const string k_CurrentFuelAmountKey = "CurrentFuelAmount (liters)";

        public FuelMotorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
            Engine = new FuelEngine(5.8f, 0f, eFuelType.Octan98);
        }

        public override List<string> GetVehicleSpecificDataRequirements()
        {
            List<string> requirements = base.GetVehicleSpecificDataRequirements();

            requirements.Add(k_CurrentFuelAmountKey);

            return requirements;
        }

        public override void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            base.SetVehicleSpecificProperties(i_VehicleData);
            if (i_VehicleData.ContainsKey(k_CurrentFuelAmountKey))
            {
                if (float.TryParse(i_VehicleData[k_CurrentFuelAmountKey], out float fuel))
                {
                    ((FuelEngine)Engine).RefuelInLiter(fuel, eFuelType.Octan98);
                }
                else
                {
                    throw new FormatException("Current fuel amount has to be a number");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsCarryDangerousMaterials;
        private float m_CarryCapacity;
        private const string k_CarriesDangerousMaterialsKey = "CarriesDangerousMaterials (true/false)";
        private const string k_CurrentFuelAmountKey = "CurrentFuelAmount (liters)";

        public Truck(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, 12)
        {
            Engine = new FuelEngine(135f, 0f, eFuelType.Soler);
        }

        public bool IsCarryDangerousMaterials
        {
            get {  return m_IsCarryDangerousMaterials; }
        }

        public float CarryCapacity
        {
            get { return m_CarryCapacity; }
        }

        protected override float GetMaxWheelPressure()
        {
            return 27f;
        }

        public override List<string> GetVehicleSpecificDataRequirements()
        {
            List<string> requirements = base.GetVehicleSpecificDataRequirements();

            requirements.Add(k_CarriesDangerousMaterialsKey);
            requirements.Add("CarryCapacity");
            requirements.Add(k_CurrentFuelAmountKey);

            return requirements;
        }

        public override void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            base.SetVehicleSpecificProperties(i_VehicleData);
            if (i_VehicleData.ContainsKey(k_CarriesDangerousMaterialsKey))
            {
                if (bool.TryParse(i_VehicleData[k_CarriesDangerousMaterialsKey], out bool carries))
                {
                    m_IsCarryDangerousMaterials = carries;
                }
                else
                {
                    throw new FormatException("Carries dangerous materials has to be true or false");
                }
            }

            if (i_VehicleData.ContainsKey("CarryCapacity"))
            {
                if (float.TryParse(i_VehicleData["CarryCapacity"], out float volume))
                {
                    m_CarryCapacity = volume;
                }
                else
                {
                    throw new FormatException("Carry capacity has to be number");
                }
            }

            if (i_VehicleData.ContainsKey(k_CurrentFuelAmountKey))
            {
                if (float.TryParse(i_VehicleData[k_CurrentFuelAmountKey], out float fuel))
                {
                    ((FuelEngine)Engine).RefuelInLiter(fuel, eFuelType.Soler);
                }
                else
                {
                    throw new FormatException("Current fuel amount has to be true or false");
                }
            }
        }

        public override string GetVehicleSpecificDetails()
        {
            return string.Format("Carries Dangerous Materials: {0}\nCarry Capacity: {1}", m_IsCarryDangerousMaterials, m_CarryCapacity);
        }
    }
}


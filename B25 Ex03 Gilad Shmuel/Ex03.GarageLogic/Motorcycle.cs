using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private const string k_LicenseTypeKey = "LicenseType (0=A, 1=A2, 2=AB, 3=B2)";

        protected Motorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, 2)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
        }

        protected override float GetMaxWheelPressure()
        {
            return 30f;
        }

        public override List<string> GetVehicleSpecificDataRequirements()
        {
            List<string> requirements = base.GetVehicleSpecificDataRequirements();

            requirements.Add(k_LicenseTypeKey);
            requirements.Add("EngineCapacity");

            return requirements;
        }

        public override void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            base.SetVehicleSpecificProperties(i_VehicleData);
            if (i_VehicleData.ContainsKey(k_LicenseTypeKey))
            {
                if (Enum.TryParse<eLicenseType>(i_VehicleData[k_LicenseTypeKey], out eLicenseType licenseType)
                    && Enum.IsDefined(typeof(eLicenseType), licenseType))
                {
                    m_LicenseType = licenseType;
                }
                else
                {
                    throw new ValueRangeExceptioncs(k_LicenseTypeKey, 0, 3);
                }
            }

            if (i_VehicleData.ContainsKey("EngineCapacity"))
            {
                if (int.TryParse(i_VehicleData["EngineCapacity"], out int capacity))
                {
                    m_EngineCapacity = capacity;
                }
                else
                {
                    throw new FormatException("Engine capacity has to be a number");
                }
            }
        }

        public override string GetVehicleSpecificDetails()
        {
            return string.Format("License Type: {0}\nEngine Capacity: {1}", m_LicenseType, m_EngineCapacity);
        }
    }
}

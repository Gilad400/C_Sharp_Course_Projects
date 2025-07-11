using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private readonly int r_NumberOfWheels;
        private Engine m_Engine;

        protected Vehicle(string i_LicenseNumber, string i_ModelName, int i_NumberOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>(i_NumberOfWheels);
            r_NumberOfWheels = i_NumberOfWheels;
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public Engine Engine
        {
            get { return m_Engine; }   
            set { m_Engine = value; }
        }

        public float EnergyPercentage()
        {
            return m_Engine.GetEnergyPercentage();
        }

        private void initializeWheels(string i_ManufacturerName, float i_CurrentPressure)
        {
            float maxPressure = GetMaxWheelPressure();

            if (i_CurrentPressure <= maxPressure)
            {
                for (int i = 0; i < r_NumberOfWheels; i++)
                {
                    r_Wheels.Add(new Wheel(i_ManufacturerName, i_CurrentPressure, maxPressure));
                }
            }
            else
            {
                throw new ValueRangeExceptioncs("wheel current pressure", 0, maxPressure);
            } 
        }

        public void InflateWheelsToMaximum()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateToMaximum();
            }
        }

        public virtual void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            if (i_VehicleData.ContainsKey("WheelManufacturer") &&
                i_VehicleData.ContainsKey("CurrentTirePressure"))
            {
                string manufacturer = i_VehicleData["WheelManufacturer"];

                if (float.TryParse(i_VehicleData["CurrentTirePressure"], out float pressure))
                {
                    initializeWheels(manufacturer, pressure);
                }
                else
                {
                    throw new FormatException("Current tire pressure has to be a number");
                }
            }
        }
        
        public virtual List<string> GetVehicleSpecificDataRequirements()
        {
            return new List<string>
            {
                "WheelManufacturer",
                "CurrentTirePressure"
            };
        }

        public abstract string GetVehicleSpecificDetails();

        protected abstract float GetMaxWheelPressure();

        public override string ToString()
        {
            float energyPercentage = EnergyPercentage();
            StringBuilder stringVehicle = new StringBuilder();

            stringVehicle.AppendLine(string.Format("License Number: {0}", r_LicenseNumber));
            stringVehicle.AppendLine(string.Format("Model Name: {0}", r_ModelName));
            stringVehicle.AppendLine(string.Format("Energy Percentage: {0}%", energyPercentage));
            stringVehicle.AppendLine(string.Format("Engine Details: {0}", m_Engine));
            stringVehicle.AppendLine(string.Format("Wheels: {0}", r_Wheels[0].ToString()));
            stringVehicle.AppendLine(GetVehicleSpecificDetails());
            
            return stringVehicle.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eDoorsAmount m_DoorsAmount;
        private const string k_CarColorKey = "CarColor (0=Yellow, 1=Black, 2=White, 3=Silver)";
        private const string k_NumberOfDoorsKey = "NumberOfDoors (2, 3, 4, or 5)";

        protected Car(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName, 5)
        {
        }

        public eCarColor CarColor
        {
            get {  return m_CarColor; }
        }

        public eDoorsAmount DoorsAmount
        {
            get { return m_DoorsAmount;  }
        }

        protected override float GetMaxWheelPressure()
        {
            return 32f;
        }
        
        public override List<string> GetVehicleSpecificDataRequirements()
        {
            List<string> requirements = base.GetVehicleSpecificDataRequirements();

            requirements.Add(k_CarColorKey);
            requirements.Add(k_NumberOfDoorsKey);

            return requirements;
        }

        public override void SetVehicleSpecificProperties(Dictionary<string, string> i_VehicleData)
        {
            base.SetVehicleSpecificProperties(i_VehicleData);
            if (i_VehicleData.ContainsKey(k_CarColorKey))
            {
                if (Enum.TryParse<eCarColor>(i_VehicleData[k_CarColorKey], out eCarColor color)
                    && Enum.IsDefined(typeof(eCarColor), color))
                {
                    m_CarColor = color;
                }
                else
                {
                    throw new ValueRangeExceptioncs(k_CarColorKey, 0, 3);
                }
            }

            if (i_VehicleData.ContainsKey(k_NumberOfDoorsKey))
            {
                if (Enum.TryParse<eDoorsAmount>(i_VehicleData[k_NumberOfDoorsKey], out eDoorsAmount doors)
                    && Enum.IsDefined(typeof(eDoorsAmount), doors))
                {
                    m_DoorsAmount = doors;
                }
                else
                {
                    throw new ValueRangeExceptioncs("number of doors", 2, 5);
                }
            }
        }

        public override string GetVehicleSpecificDetails()
        {
            return string.Format("Car Color: {0}\nNumber of Doors: {1}", m_CarColor, m_DoorsAmount);
        } 
    }
}

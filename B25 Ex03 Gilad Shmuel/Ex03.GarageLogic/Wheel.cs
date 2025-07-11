using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_TirePressure;
        private readonly float r_MaxTirePressure;

        public Wheel(string i_ManufacturerName, float i_TirePressure, float i_MaxTirePressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_TirePressure = i_TirePressure;
            r_MaxTirePressure = i_MaxTirePressure;
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float TirePressure
        {
            get { return m_TirePressure; }
        }

        public float MaxTirePressure
        {
            get { return r_MaxTirePressure; }
        }

        public void InflateWheel(float i_AirAmount)
        {
            if (i_AirAmount < 0)
            {
                throw new ArgumentException("Air amount cannot be negative");
            }

            if (m_TirePressure + i_AirAmount > r_MaxTirePressure)
            {
                throw new ValueRangeExceptioncs("air adding amount", 0, r_MaxTirePressure - m_TirePressure);
            }

            m_TirePressure += i_AirAmount;
        }

        public void InflateToMaximum()
        {
            m_TirePressure = r_MaxTirePressure;
        }

        public override string ToString()
        {
            return string.Format("Manufacturer: {0}, Pressure: {1}/{2}", r_ManufacturerName, m_TirePressure, r_MaxTirePressure);
        }
    }
}

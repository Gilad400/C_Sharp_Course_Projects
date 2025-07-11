using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
            m_CurrentEnergy = i_CurrentEnergy;
        }

        public float MaxEnergy
        {
            get { return r_MaxEnergy; }
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
        }

        protected void AddEnergy(float i_AddingAmount)
        {
            if (i_AddingAmount < 0)
            {
                throw new ArgumentException("Energy amount cannot be negative");
            }

            if (m_CurrentEnergy + i_AddingAmount > r_MaxEnergy)
            {
                throw new ValueRangeExceptioncs("engine amount", 0, r_MaxEnergy - m_CurrentEnergy);
            }

            m_CurrentEnergy += i_AddingAmount;
        }

        public float GetEnergyPercentage()
        {
            return (m_CurrentEnergy / r_MaxEnergy) * 100f;
        }
    }
}

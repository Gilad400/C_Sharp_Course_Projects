using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxFuelInLiter, float i_FuelLeftInLiter, eFuelType i_FuelType)
            : base(i_MaxFuelInLiter, i_FuelLeftInLiter)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void RefuelInLiter(float i_LiterAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("Wrong fuel type. This vehicle uses {0}", r_FuelType));
            }

            AddEnergy(i_LiterAmount);
        }

        public override string ToString()
        {
            return string.Format("Fuel Type: {0}, Current: {1}, Max: {2}", r_FuelType, CurrentEnergy, MaxEnergy);
        }
    }
}

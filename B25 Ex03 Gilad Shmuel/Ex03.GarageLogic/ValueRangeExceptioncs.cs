using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class ValueRangeExceptioncs : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueRangeExceptioncs(string i_TypeOfField,float i_MinValue, float i_MaxValue) 
            : base(string.Format("Invalid {0}, Minimal value is {1}, and maximal value is {2}", i_TypeOfField, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }
    }
}

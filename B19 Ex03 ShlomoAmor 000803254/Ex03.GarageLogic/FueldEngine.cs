using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FueldEngine : Engine
    {
        eFuelEngineType m_FuelEngineType;
        public FueldEngine(float i_MaxEnergyCapacity, eFuelEngineType i_FuelEngineType)
        {
            m_MaxEngergyCapacity = i_MaxEnergyCapacity;
            m_FuelEngineType = i_FuelEngineType;
        }

        public override object Type
        {
            get { return m_FuelEngineType; }
        }
    }
}

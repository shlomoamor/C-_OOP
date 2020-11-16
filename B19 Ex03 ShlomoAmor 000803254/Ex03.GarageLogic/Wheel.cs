using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufactorName;
        private float m_CurrentAirPressure = 0.0f;
        
        public Wheel(string i_ManufactorName)
        {
            r_ManufactorName = i_ManufactorName;

        }
        public void InflateWheels(float i_AdditionAirPressue)
        {
            m_CurrentAirPressure += i_AdditionAirPressue;
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        public string WheelManufactorer
        {
            get { return r_ManufactorName; }

        }
    }
}

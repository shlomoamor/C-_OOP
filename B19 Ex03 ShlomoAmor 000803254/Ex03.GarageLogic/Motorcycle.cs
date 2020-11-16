using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume = 0;

        public Motorcycle(eTypeOfVehicle i_TypeOfVehicle, string i_OwnerPhoneNumber, string i_LicenseNumber, string i_OwnerName, string i_ModelName, string i_WheelManufactorName)
             : base(i_TypeOfVehicle, i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName, i_WheelManufactorName)
        {
            m_MaxAirPressure = 33f;
            AddWheels(k_NumberOfWheels);
            if (m_TypeOfVehicle == eTypeOfVehicle.ElectricMotorcycle)
            {
                m_Engine = new ElectricEngine(1.4f);
            }
            else if (m_TypeOfVehicle == eTypeOfVehicle.FueldMotorcycle)
            {
                m_Engine = new FueldEngine(8f, eFuelEngineType.Octane95);
            }
            m_Properties.Add(m_LicenseType);
            m_Properties.Add(m_EngineVolume);
            m_PropetiesDetails.Add("The motorcycle license type:");
            m_PropetiesDetails.Add("The motorcycle engine type:");
        }

        internal override void SetProperties(List<object> i_OtherProperties)
        {
            m_Properties = i_OtherProperties;
            m_LicenseType = (eLicenseType)i_OtherProperties.ElementAt(0);
            m_EngineVolume = (int)i_OtherProperties.ElementAt(1);
        }
    }
}

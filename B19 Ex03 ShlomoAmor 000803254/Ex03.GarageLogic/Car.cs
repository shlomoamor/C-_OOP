using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private eCarColour m_CarColour;
        private eCarNumberOfDoors m_CarNumberOfDoors;

        public Car(eTypeOfVehicle i_TypeOfVehicle, string i_OwnerPhoneNumber, string i_LicenseNumber, string i_OwnerName, string i_ModelName, string i_WheelManufactorName)
             : base(i_TypeOfVehicle, i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName, i_WheelManufactorName)
        {
            AddWheels(k_NumberOfWheels);
            m_MaxAirPressure = 31f;
            if (m_TypeOfVehicle == eTypeOfVehicle.ElectricCar)
            {
                m_Engine = new ElectricEngine(1.8f);
            }
            else if (m_TypeOfVehicle == eTypeOfVehicle.FueldCar)
            {
                m_Engine = new FueldEngine(8f, eFuelEngineType.Octane95);
            }
            m_Properties.Add(m_CarColour);
            m_Properties.Add(m_CarNumberOfDoors);
            m_PropetiesDetails.Add("The car's colour is:");
            m_PropetiesDetails.Add("The car's number of doors's are");

        }

        public eCarColour Colour
        {
            get { return m_CarColour; }
            set { m_CarColour = value; }
        }

        internal override void SetProperties(List<object> i_OtherProperties)
        {
            m_Properties = i_OtherProperties;
            m_CarColour = (eCarColour)i_OtherProperties.ElementAt(0);
            m_CarNumberOfDoors = (eCarNumberOfDoors)i_OtherProperties.ElementAt(1);
        }
    }
}

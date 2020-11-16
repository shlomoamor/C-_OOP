using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        private readonly string r_OwnerPhoneNumber;
        private readonly string r_LicenseNumber;
        private readonly string r_OwnerName;
        private readonly string r_ModelName;

        protected  float m_MaxAirPressure = 0.0f;
        protected Engine m_Engine = null;
        protected List<object> m_Properties = new List<Object>();
        protected List<Wheel> m_WheelsList = new List<Wheel>();
        protected eVehicleStatus m_VehicleStatus;
        protected eTypeOfVehicle m_TypeOfVehicle;
        protected string m_WheelManufactorName;
        protected List<string> m_PropetiesDetails = new List<string>();

       

        public Vehicle(eTypeOfVehicle i_TypeOfVehicle, string i_OwnerPhoneNumber, string i_LicenseNumber, string i_OwnerName, string i_ModelName, string i_WheelManufactorName)
        {
            m_WheelManufactorName = i_WheelManufactorName;
            m_TypeOfVehicle = i_TypeOfVehicle;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            r_LicenseNumber = i_LicenseNumber;
            r_OwnerName = i_OwnerName;
            r_ModelName = i_ModelName;

        }

        internal abstract void SetProperties(List<object> i_OtherProperties);

        public void AddWheels(int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel NewWheel = new Wheel( m_WheelManufactorName);
                m_WheelsList.Add(NewWheel);
            }
        }
        public List<Object> Properties
        {
            get { return m_Properties; }
            set { m_Properties = value; }
        }
        public List<string> PropertiesDetails
        {
            get { return m_PropetiesDetails; }
        }


        public List<Wheel> Wheels
        {
            get { return m_WheelsList; }
            set { m_WheelsList = value; }
        }
        public Engine CurrEngine
        {
            get { return m_Engine; }
            set { m_Engine = value; }

        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }
        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
            
        }
        public int NumberOfWheels
        {
            get;
        }
        public eTypeOfVehicle VehicleType
        {
            get { return m_TypeOfVehicle; }
            set { m_TypeOfVehicle = value; }

        }
        public string ModelName
        {
            get { return r_ModelName;  }
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }


    }
}

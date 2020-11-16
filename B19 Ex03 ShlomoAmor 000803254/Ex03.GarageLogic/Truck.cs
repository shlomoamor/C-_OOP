using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private Boolean m_IsDangerous = false;
        private float m_VolumeOfCargo = 0.0f;

        public Truck(string i_OwnerPhoneNumber, string i_LicenseNumber, string i_OwnerName, string i_ModelName, string i_WheelManufactorName)
             : base(eTypeOfVehicle.Truck, i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName,  i_WheelManufactorName)
        {
            AddWheels(k_NumberOfWheels);
            m_MaxAirPressure = 26f;
            m_Engine = new FueldEngine(110f, eFuelEngineType.Solar);
            m_Properties.Add(m_IsDangerous);
            m_Properties.Add(m_VolumeOfCargo);
            m_PropetiesDetails.Add("The truck's cargo is dangerous:");
            m_PropetiesDetails.Add("The trucks volume of cargo is:");

        }
        public bool DangerousMaterials
        {
            get { return m_IsDangerous; }
        }
        internal override void SetProperties(List<Object> i_OtherProperties)
        {
            m_Properties = i_OtherProperties;
            m_IsDangerous = (bool)i_OtherProperties.ElementAt(0);
            m_VolumeOfCargo = (float)i_OtherProperties.ElementAt(1);
        }
    }
}

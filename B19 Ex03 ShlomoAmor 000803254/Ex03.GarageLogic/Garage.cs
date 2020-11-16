using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.GarageLogic
{
    public class Garage 
    {
        private List<Vehicle> m_VehicleList = new List<Vehicle>();

        public bool IsInGarage(string i_LicenseNumber )
        {
            Vehicle desiredVehicle = FindVehicle(i_LicenseNumber);
            bool wasFound = desiredVehicle != null;
            return wasFound;
        }

        public Vehicle InsertNewVehicle(eTypeOfVehicle i_TypeOfVehicle, string i_OwnerPhoneNumber, string i_LicenseNumber, string i_OwnerName, string i_ModelName, string i_WheelManufactorName)
        {
            Vehicle newVehicle = null;
            switch ((eTypeOfVehicle)i_TypeOfVehicle)
            {
                case eTypeOfVehicle.ElectricCar:
                case eTypeOfVehicle.FueldCar:
                    newVehicle = new Car(i_TypeOfVehicle, i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName, i_WheelManufactorName);
                    break;
                case eTypeOfVehicle.ElectricMotorcycle:
                case eTypeOfVehicle.FueldMotorcycle:
                    newVehicle = new Motorcycle(i_TypeOfVehicle, i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName, i_WheelManufactorName);                   
                    break;
                case eTypeOfVehicle.Truck:
                    newVehicle = new Truck(i_OwnerPhoneNumber, i_LicenseNumber, i_OwnerName, i_ModelName, i_WheelManufactorName);
                    break;
                default:
                    break;
            }

            newVehicle.VehicleStatus = eVehicleStatus.InRepair;
            m_VehicleList.Add(newVehicle);
            return newVehicle;
        }

        public void InsertAdditionalProperties(Vehicle i_Vehicle, float i_EnergyCapacity, float i_CurrentAirPressure, List<object> i_Properties)
        {
            i_Vehicle.CurrEngine.EngineCurrentCapacity = i_EnergyCapacity;
            foreach (Wheel currWheel in i_Vehicle.Wheels)
            {
                currWheel.InflateWheels(i_CurrentAirPressure);
            }
            i_Vehicle.SetProperties(i_Properties);

        }


        public List<string> DisplayByFilter(eVehicleStatus i_FilterStatus)
        {
            List<string> licencesNumbers = new List<string>();
            foreach (Vehicle currVehicle in m_VehicleList)
                if (currVehicle.VehicleStatus == i_FilterStatus)
                {
                    licencesNumbers.Add(currVehicle.LicenseNumber);
                }

                return licencesNumbers;
        }
        
        public Vehicle FindVehicle(string i_LicenseNumber)
        {
            Vehicle desiredVehicle = null;
            foreach (Vehicle currVehicle in m_VehicleList)
                if (currVehicle.LicenseNumber == i_LicenseNumber)
                {
                    desiredVehicle = currVehicle;
                    break;
                }
            return desiredVehicle;
        }
    }
}
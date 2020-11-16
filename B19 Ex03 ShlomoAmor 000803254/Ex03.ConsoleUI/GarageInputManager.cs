using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageInputManager
    {
        protected Garage m_Garage;
        bool m_IsOpen = true;
        public GarageInputManager(Garage i_Garage)
        {
            m_Garage = i_Garage;
        }
        public void ServeCustomer()
        {
           
            while(m_IsOpen)
            {
                this.displayMainMenu();
                eMenuResults userMenuResult = (eMenuResults)this.getUserMenuResult();
                switch (userMenuResult)
                {
                    case eMenuResults.AddVehicle:
                        addVehicle();
                        break;
                    case eMenuResults.ChangeVehicleState:
                        changeVehicleState();
                        break;
                    case eMenuResults.DisplayAllLicenseNumbers:
                        displayAllLicenseNumbers();
                        break;
                    case eMenuResults.DisplayFullData:
                        displayFullData();
                        break;
                    case eMenuResults.InflateWheels:
                        inflateWheels();
                        break;
                    case eMenuResults.RechargeVehicle:
                        rechargeVehicle();
                        break;
                    case eMenuResults.RefuelVehicle:
                        refuelVehicle();
                        break;
                    case eMenuResults.Exit:
                        exitGarage();
                        break;

                }
            }

        }
        private String getCarLicenseNumber(out bool io_IsVehicleExist)
        {
            Console.Clear();
            Console.WriteLine("Please Enter your license number: ");
            string carLicenseNumber = Console.ReadLine();
            io_IsVehicleExist =  m_Garage.IsInGarage(carLicenseNumber);
            return carLicenseNumber; 
        }

        private void exitGarage()
        {
            m_IsOpen = false;
        }

        private void refuelVehicle()
        {
            bool isExists;

            String licensePlate = getCarLicenseNumber(out isExists);
            if (!isExists)
            {
                Console.WriteLine("The car doesn't exist.");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
            else
            {
                Vehicle currVehicle = m_Garage.FindVehicle(licensePlate);
                Console.Clear();
                Console.WriteLine("What kind of fuel would you like to add? ");
                eFuelEngineType vehicleFuelType;
                int i = 1;
                foreach (eFuelEngineType type in Enum.GetValues(typeof(eFuelEngineType)))
                {
                    Console.WriteLine("({0}) {1}", i, type.ToString());
                    i++;
                }
                int getInput = 0;
                bool isValidInput = false;
                while (!isValidInput)
                {
                    try
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                        if ((eFuelEngineType)getInput == (eFuelEngineType)currVehicle.CurrEngine.Type)
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            isValidInput = false;
                            Console.WriteLine("Invalid option. Please try again.");
                        }
                    }
                    catch (FormatException e)
                    {
                        isValidInput = false;
                        Console.WriteLine(e.Message);
                    }
                }
                vehicleFuelType = (eFuelEngineType)getInput;
                Console.Clear();
                Console.WriteLine("How much would you like to add from {0}? ", (eFuelEngineType)getInput);
                float amount = 0.0f;
                isValidInput = false;
                float maxEnergyCapacity = currVehicle.CurrEngine.MaxEngergyCapacity;
                float CurrEnergyCapacity = currVehicle.CurrEngine.EngineCurrentCapacity;

                while (!isValidInput)
                {
                    
                    isValidInput = float.TryParse(Console.ReadLine(), out amount);
                    if (amount == 0)
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");

                    }
                    else if (amount < 0 || amount > (maxEnergyCapacity - CurrEnergyCapacity))
                    {
                        throw new ValueOutOfRangeException(0.0f, (maxEnergyCapacity - CurrEnergyCapacity));
                    }
                    else
                    {
                        currVehicle.CurrEngine.EngineCurrentCapacity += amount;
                    }          
                 }   

            }
            
        }

        private void rechargeVehicle() 
        {
            bool isExists;
            bool isValidInput = false;
            String licensePlate = getCarLicenseNumber(out isExists);
            if (!isExists)
            {
                Console.WriteLine("The car doesn't exist.");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
            else
            {
                Vehicle currVehicle = m_Garage.FindVehicle(licensePlate);
                Console.Clear();
                if (!(currVehicle.CurrEngine is ElectricEngine))
                {
                    isValidInput = false;
                    Console.WriteLine("Invalid option. Please try again.");
                    throw new Exception("Not electric engine.");

                }
                Console.WriteLine("How much would you like to add? ");
                float amount = 0.0f;
                float maxEnergyCapacity = currVehicle.CurrEngine.MaxEngergyCapacity;
                float currEnergyCapacity = currVehicle.CurrEngine.EngineCurrentCapacity;
                isValidInput = false;
                while (!isValidInput)
                {

                    isValidInput = float.TryParse(Console.ReadLine(), out amount);
                    if (amount == 0)
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");

                    }
                    else if (amount < 0 || amount > (maxEnergyCapacity - currEnergyCapacity))
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                        throw new ValueOutOfRangeException(0.0f, (maxEnergyCapacity - currEnergyCapacity));
                    }
                    else
                    {
                        currVehicle.CurrEngine.EngineCurrentCapacity += amount;
                    }
                }

            }

        }

        private void inflateWheels()
        {
            bool isExists;
            bool isValidInput = false;
            String licensePlate = getCarLicenseNumber(out isExists);
            if (!isExists)
            {
                Console.WriteLine("The car doesn't exist.");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
            else
            {
                Vehicle currVehicle = m_Garage.FindVehicle(licensePlate);
                float maxAirPressure = currVehicle.MaxAirPressure;
                foreach (Wheel currWheel in currVehicle.Wheels)
                {
                    currWheel.InflateWheels(maxAirPressure - currWheel.CurrentAirPressure);
                }
                Console.WriteLine("All wheels were inflated to max!");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
        }

        private void displayFullData()
        {
            bool isExists;
            String licensePlate = getCarLicenseNumber(out isExists);
            if (!isExists)
            {
                Console.WriteLine("The car doesn't exist.");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
            else
            {
                Vehicle currVehicle = m_Garage.FindVehicle(licensePlate);
                StringBuilder vehicleFullData = new StringBuilder();
                vehicleFullData.AppendFormat("The license number is    : {0}{1}", licensePlate, Environment.NewLine);
                vehicleFullData.AppendFormat("The model name is        : {0}{1}", currVehicle.ModelName, Environment.NewLine);
                vehicleFullData.AppendFormat("The owner name is        : {0}{1}", currVehicle.OwnerName, Environment.NewLine);
                vehicleFullData.AppendFormat("The vehicle Status       : {0}{1}", currVehicle.VehicleStatus.ToString(), Environment.NewLine);
                vehicleFullData.AppendFormat("The wheel's status is    : {1}{0}", this.showWheelDetails(currVehicle.Wheels), Environment.NewLine);
                vehicleFullData.AppendFormat("The energy Status{1}{0}", this.showFuelDetails(currVehicle), Environment.NewLine);
                vehicleFullData.AppendFormat("{0}", this.showAdditionalInformation(currVehicle));
                Console.Clear();
                Console.WriteLine(vehicleFullData.ToString());
                Console.ReadLine();




            }
        }

        private object showAdditionalInformation(Vehicle i_Vehicle)
        {

            StringBuilder additionalInformation = new StringBuilder();
            
            for(int i =0; i < i_Vehicle.Properties.Count; i++)
            {
                additionalInformation.AppendFormat("{0} {1} {2}", i_Vehicle.PropertiesDetails.ElementAt(i), i_Vehicle.Properties.ElementAt(i), Environment.NewLine);
            }
            return additionalInformation.ToString();
        }

        private object showFuelDetails(Vehicle i_CurrVehicle)
        {
            StringBuilder energyData = new StringBuilder();
            if (i_CurrVehicle.CurrEngine is ElectricEngine)
            {
               
                energyData.AppendFormat("The battery status is    : {0}{1}", ((i_CurrVehicle.CurrEngine.EngineCurrentCapacity) / i_CurrVehicle.CurrEngine.MaxEngergyCapacity), Environment.NewLine);

            }

            else if(i_CurrVehicle.CurrEngine is FueldEngine)
            {
                eFuelEngineType fuelType = (eFuelEngineType)i_CurrVehicle.CurrEngine.Type;
                energyData.AppendFormat("The fuel status is    : {0}%{1}", ((i_CurrVehicle.CurrEngine.EngineCurrentCapacity) / i_CurrVehicle.CurrEngine.MaxEngergyCapacity) * 100, Environment.NewLine);
                energyData.AppendFormat("The fuel type is      : {0}{1}", fuelType.ToString(), Environment.NewLine);

            }
            return energyData.ToString();
        }

        private object showWheelDetails(List<Wheel> i_Wheels)
        {
            StringBuilder wheelData = new StringBuilder();
            int i = 1;
            foreach (Wheel currWheel in i_Wheels)
            {
                wheelData.AppendFormat("({0})manufactorer name is: {1}{2}", i, currWheel.WheelManufactorer, Environment.NewLine);
                wheelData.AppendFormat("The air pressure         : {0}{1}", currWheel.CurrentAirPressure, Environment.NewLine);
                i++;
            }
            return wheelData.ToString();
        }

        private void displayAllLicenseNumbers()
        {
            List<String> licenseNumber = null; 
            Console.Clear();
            Console.WriteLine("What do you want to filter? ");
            int i = 1;
            foreach (eVehicleStatus type in Enum.GetValues(typeof(eVehicleStatus)))
            {
                Console.WriteLine("({0}) {1}", i, type.ToString());
                i++;
            }
            Console.WriteLine("({0}) All", i);
            int getInput = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                    int sizeOfTypes = Enum.GetValues(typeof(eVehicleStatus)).Length + 1;
                    if (getInput <= sizeOfTypes && getInput > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }
            }
            Console.Clear();
            Console.WriteLine("The number plates found: ");
            if (getInput == 4)
            {
                foreach (eVehicleStatus type in Enum.GetValues(typeof(eVehicleStatus)))
                {
                    Console.WriteLine("{0}:", type.ToString());
                    licenseNumber = (m_Garage.DisplayByFilter(type));
                    for (int j = 0; j < licenseNumber.Count; j++)
                    {
                        Console.WriteLine("The number plate: {0}", licenseNumber.ElementAt(j));
                    }
                }
            }
            else
            {
                licenseNumber = (m_Garage.DisplayByFilter((eVehicleStatus)getInput));
                Console.WriteLine("{0}:", ((eVehicleStatus)getInput).ToString());
            }
            for (int j = 0; j < licenseNumber.Count; j++)
            {
                Console.WriteLine("The number plate: {0}", licenseNumber.ElementAt(j));
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        private void changeVehicleState()
        {
            bool isExists;
            bool isValidInput = false;
            String licensePlate = getCarLicenseNumber(out isExists);
            if (!isExists)
            {
                Console.WriteLine("The car doesn't exist.");
                Console.WriteLine("Press any button to continue.");
                Console.ReadLine();
            }
            else
            {
                Vehicle currVehicle = m_Garage.FindVehicle(licensePlate);
                Console.Clear();
                Console.WriteLine("Choose a car status option: ");
                eVehicleStatus vehicleStatus;
                int i = 1;
                foreach (eVehicleStatus type in Enum.GetValues(typeof(eVehicleStatus)))
                {
                    Console.WriteLine("({0}) {1}", i, type.ToString());
                    i++;
                }
                int getInput = 0;
                while (!isValidInput)
                {
                    try
                    {
                        isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                        int sizeOfTypes = Enum.GetValues(typeof(eVehicleStatus)).Length;
                        if (getInput <= sizeOfTypes && getInput > 0)
                        {
                            isValidInput = true;
                        }
                        else
                        {
                            isValidInput = false;
                            Console.WriteLine("Invalid option. Please try again.");
                        }
                    }
                    catch (FormatException e)
                    {
                        isValidInput = false;
                        Console.WriteLine(e.Message);
                    }
                }
                currVehicle.VehicleStatus = (eVehicleStatus)getInput;
            }
        }

        private void addVehicle()
        {
            bool isInGarage = false;
            string licesnseNumber = this.getCarLicenseNumber(out isInGarage);
            if(!isInGarage)
            {
                string userName = getUserName();
                string userPhoneNumber = getUserPhoneNumber();
                string modelName = getModelName();
                eTypeOfVehicle vehicle = getTypeOfVehichle();
                string wheelBrand = getWheelBrand();
                Vehicle currVehicle = m_Garage.InsertNewVehicle(vehicle, userPhoneNumber, licesnseNumber, userName, modelName, wheelBrand);
                float engineCapacity = getEngineCurrCapacity(currVehicle);
                float currAirPressure = getCurrAirPressure(currVehicle);
                List<object> properties = getProperties(currVehicle);
                m_Garage.InsertAdditionalProperties(currVehicle, engineCapacity, currAirPressure, properties);     
            }
            else
            {
                m_Garage.FindVehicle(licesnseNumber).VehicleStatus = eVehicleStatus.InRepair;
            }
        }

        private List<object> getProperties(Vehicle i_Vehicle)
        {
            List<Object> properties = new List<Object>();
            switch (i_Vehicle.VehicleType)
            {
                case eTypeOfVehicle.Truck:
                    setTruckProperty(i_Vehicle, properties);
                    break;
                case eTypeOfVehicle.ElectricCar:
                case eTypeOfVehicle.FueldCar:
                    setCarProperty(i_Vehicle, properties);
                    break;
                case eTypeOfVehicle.ElectricMotorcycle:
                case eTypeOfVehicle.FueldMotorcycle:
                    setMotorcycleProperty(i_Vehicle, properties);
                    break;
            }
            return properties;

        }

        private void setMotorcycleProperty(Vehicle i_Vehicle, List<object> i_Properties)
        {
            Console.Clear();
            Console.WriteLine("What is your motorcycle's license type? ");
            eLicenseType vehicleLicenseType;
            int i = 1;
            foreach (eLicenseType type in Enum.GetValues(typeof(eLicenseType)))
            {
                Console.WriteLine("({0}) {1}", i, type.ToString());
                i++;
            }
            int getInput = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                    int sizeOfTypes = Enum.GetValues(typeof(eLicenseType)).Length;
                    if (getInput <= sizeOfTypes && getInput > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }
            }
            vehicleLicenseType = (eLicenseType)getInput;

            Console.Clear();
            Console.WriteLine("What is your motorcycle's engine volume: ");
            int engineVolume =  0;
            isValidInput = false;
            getInput = 0;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out engineVolume);
                    if (engineVolume > 0)
                    {
                        isValidInput = true;

                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid engine volume. Please try again.");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }

            }
            i_Properties.Add(vehicleLicenseType);
            i_Properties.Add(engineVolume);

        }

        private void setCarProperty(Vehicle i_Vehicle, List<object> i_Properties)
        {
            Console.Clear();
            Console.WriteLine("What is your car's colour? ");
            eCarColour vehicleColour;
            int i = 1;
            foreach (eCarColour type in Enum.GetValues(typeof(eCarColour)))
            {
                Console.WriteLine("({0}) {1}", i, type.ToString());
                i++;
            }
            int getInput = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                    int sizeOfTypes = Enum.GetValues(typeof(eCarColour)).Length;
                    if (getInput <= sizeOfTypes && getInput > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }
            }
            vehicleColour = (eCarColour)getInput;

            Console.Clear();
            Console.WriteLine("What is the number of door's? ");
            eCarNumberOfDoors vehicleNumberOfDoors;
            i = 1;
            foreach (eCarNumberOfDoors type in Enum.GetValues(typeof(eCarNumberOfDoors)))
            {
                Console.WriteLine("({0}) {1}", i, type.ToString());
                i++;
            }
            getInput = 0;
            isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                    int sizeOfTypes = Enum.GetValues(typeof(eCarNumberOfDoors)).Length;
                    if (getInput <= sizeOfTypes && getInput > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }
            }
            vehicleNumberOfDoors = (eCarNumberOfDoors)getInput;
            i_Properties.Add(vehicleColour);
            i_Properties.Add(vehicleNumberOfDoors);

        }

        private void setTruckProperty(Vehicle i_Vehicle, List<Object> i_Properties)
        {
            bool isDangerous = false;
            float volumeOfCargo = 0.0f;
            Console.Clear();
            Console.WriteLine("Does your vehicle's contain any dangerous material? true or false");
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "true")
                    {
                        isDangerous = true;
                        isValidInput = true;

                    }
                    else if (input.ToLower() == "false")
                    {
                        isDangerous = false;
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid cargo dangerous option. Please try again.");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }

            }
            Console.Clear();
            Console.WriteLine("What is the volume of your cargo? ");
            isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = float.TryParse(Console.ReadLine(), out volumeOfCargo);
                    if (volumeOfCargo > 0)
                    {
                        isValidInput = true;

                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid volume of cargo. Please try again.");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }

            }
            i_Properties.Add(isDangerous);
            i_Properties.Add(volumeOfCargo);
            
        }

        private float getCurrAirPressure(Vehicle i_Vehicle)
        {
            float maxAirPressure = i_Vehicle.MaxAirPressure;
            Console.Clear();
            Console.WriteLine("Please enter a air pressure between 0 and {0}", maxAirPressure);
            bool isVlaidAirPressue = false;
            float input = 0.0f;
            while (!isVlaidAirPressue)
            {
                try
                {
                    isVlaidAirPressue = float.TryParse(Console.ReadLine(), out input);
                    if (input <= maxAirPressure && input > 0.0f)
                    {
                        isVlaidAirPressue = true;
                    }
                    else
                    {
                        isVlaidAirPressue = false;
                        Console.WriteLine("Invalid air pressure. Please try again.");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    isVlaidAirPressue = false;
                    Console.WriteLine(e.Message);
                }

            }
            return input;
        }

        private float getEngineCurrCapacity(Vehicle i_Vehicle)
        {
            float maxCapacity = i_Vehicle.CurrEngine.MaxEngergyCapacity;
            Console.Clear();
            Console.WriteLine("Please enter current remaining energy levels between 0 and {0}", maxCapacity);
            bool isVlaidCapacity = false;
            float input = 0.0f;
            while (!isVlaidCapacity)
            {
                try
                {
                    isVlaidCapacity = float.TryParse(Console.ReadLine(), out input);
                    if (input <= maxCapacity && input > 0.0f)
                    {
                        isVlaidCapacity = true;
                    }
                    else
                    {
                        isVlaidCapacity = false;
                        Console.WriteLine("Invalid energy level. Please try again.");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    isVlaidCapacity = false;
                    Console.WriteLine(e.Message);
                }

            }
            return input;

        }

        private string getWheelBrand()
        {
            Console.Clear();
            Console.WriteLine("For choosing the wheel manufactorer: ");
            string wheelBrand;
            isValidName(out wheelBrand);
            return wheelBrand;
        }

        private eTypeOfVehicle getTypeOfVehichle()
        {
            Console.Clear();
            Console.WriteLine("Choose a type of vehicle: ");
            eTypeOfVehicle vehicleType = eTypeOfVehicle.ElectricCar;
            int i = 1;
            foreach( eTypeOfVehicle type in Enum.GetValues(typeof(eTypeOfVehicle)))
            {
                Console.WriteLine("({0}) {1}",i, type.ToString());
                i++;
            }
            int getInput = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    isValidInput = int.TryParse(Console.ReadLine(), out getInput);
                    int  sizeOfTypes = Enum.GetValues(typeof(eTypeOfVehicle)).Length;
                    if (getInput <= sizeOfTypes && getInput > 0)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        isValidInput = false;
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    isValidInput = false;
                    Console.WriteLine(e.Message);
                }
            }
            vehicleType = (eTypeOfVehicle)getInput;
        

            return vehicleType;
        }

        private string getModelName()
        {
            Console.Clear();
            Console.WriteLine("For choosing your car manufactor name: ");
            string modelName;
            isValidName(out modelName);
            return modelName;
        }

        private string getUserPhoneNumber()
        { 
            string phoneNumber = "";
            Console.Clear();
            bool isValidPhoneNumber = false;
            while (!isValidPhoneNumber)
            {
                
                Console.WriteLine("Please Enter your phone number: ");
                phoneNumber = Console.ReadLine();
                isValidPhoneNumber = true;
                try
                {
                    for (int i = 0; i < phoneNumber.Length; i++)
                    {
                        if (!char.IsDigit(phoneNumber[i]))
                        {
                            Console.WriteLine("Invalid phone number! Please try again");
                            isValidPhoneNumber = false;
                            break;
                        }
                    }
                }
                catch (FormatException e)
                {
                    isValidPhoneNumber = false;
                    Console.WriteLine(e.Message);
                }
            }

            return phoneNumber;
        }

        private string getUserName()
        {
            Console.Clear();
            Console.WriteLine("For your contact details: ");
            string name;
            isValidName(out name);
            return name;
        }

        private bool isValidName(out string io_Name)
        {
            io_Name = "";
            bool isValidName = false;
            while (!isValidName)
            {
                Console.WriteLine("Please enter name: ");
                io_Name = Console.ReadLine();
                isValidName = true;
                try
                {
                    for (int i = 0; i < io_Name.Length; i++)
                    {
                        if (!char.IsLetter(io_Name[i]))
                        {
                            Console.WriteLine("Invalid name! Please try again");
                            isValidName = false;
                            break;
                        }
                    }
                }
                catch (FormatException e)
                {
                    isValidName = false;
                    Console.WriteLine(e.Message);
                }
            }

            return isValidName;
        }

        private void displayMainMenu()
        {
            Console.Clear();
            string messageForUser = string.Format(@"Hello! Welcome to our Garage, 
please enter the number of the action you want to do:
(1) Add a vehicle to the garage
(2) Display all vehicle license numbers(option for filtering)
(3) Change a vehicle state
(4) Inflate vehicle's wheels to maximum
(5) Refuel vehicle
(6) Recharge vehicle
(7) Display full data on a vehicle
(8) Exit garage");

            Console.WriteLine(messageForUser);
        }

        private int getUserMenuResult()
        {
            int userMenuResult = 0;
            bool isValidResult = false;
            while (!isValidResult)
            {
                isValidResult = int.TryParse(Console.ReadLine(), out userMenuResult);
                if (userMenuResult > 8 || userMenuResult < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please try again!");
                    System.Threading.Thread.Sleep(1000);
                    this.displayMainMenu();
                    isValidResult = false;
                }
            }
            return userMenuResult;
        }
    }
}
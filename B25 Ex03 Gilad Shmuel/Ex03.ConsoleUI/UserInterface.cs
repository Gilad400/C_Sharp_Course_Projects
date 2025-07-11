using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private readonly Garage r_Garage;
        private bool m_IsWorkingGarage;

        public UserInterface()
        {
            m_IsWorkingGarage = true;
            r_Garage = new Garage();
        }

        public void ShowGarageMenu()
        {
            while (m_IsWorkingGarage)
            {
                Console.WriteLine("Welcome to the Garage Management System! which service do you need?");
                foreach (KeyValuePair<int, string> service in r_Garage.GarageServices)
                {
                    Console.WriteLine("If you want to {0} insert: {1}", service.Value, service.Key);
                }

                int userChoice = getValidChoiceNumber(1, r_Garage.GarageServices.Count);
                performService(userChoice);
                if (m_IsWorkingGarage)
                {
                    Console.WriteLine("Press enter to continue");
                }
                
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void performService(int i_ChosenService)
        {
            switch (i_ChosenService)
            {
                case 1:
                    loadVehiclesFromFile();
                    break;
                case 2:
                    addNewVehicleToGarage();
                    break;
                case 3:
                    displayAllLicenseNumber();
                    break;
                case 4:
                    changingVeichleStatus();
                    break;
                case 5:
                    inflateVehicleWheelsToMaxAirPressure();
                    break;
                case 6:
                    addFuelToFuelVehicle();
                    break;
                case 7:
                    chargeElectricVehicle();
                    break;
                case 8:
                    displayAllDataOfGivenVehicle();
                    break;
                case 9:
                    m_IsWorkingGarage = false;
                    Console.WriteLine("Thank you, Goodbye");
                    break;
            }
        }

        private void loadVehiclesFromFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Vehicles.db");
                int vehiclesLoaded = 0;
                int vehiclesUpdated = 0;

                foreach (string line in lines)
                {
                    if (line.StartsWith("*"))
                    {
                        break;
                    }

                    try
                    {
                        bool wasAlreadyInGarage = addVehicleFromLine(line);

                        if (wasAlreadyInGarage)
                        {
                            vehiclesUpdated++;
                        }
                        else
                        {
                            vehiclesLoaded++;
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error processing line: {0}", line);
                        Console.WriteLine("Error: {0}", exception.Message);
                    }
                }

                Console.WriteLine("Successfully loaded {0} vehicles from file and updated {1} vehicles from file", vehiclesLoaded, vehiclesUpdated);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error loading file: {0}", exception.Message);
            }  
        }

        private bool addVehicleFromLine(string i_Line)
        {
            string[] parts = i_Line.Split(',');

            if (parts.Length < 8)
            {
                throw new ArgumentException("Invalid line format");
            }

            string vehicleType = parts[0].Trim();
            string licenseNumber = parts[1].Trim();
            string modelName = parts[2].Trim();
            float energyPercentage = float.Parse(parts[3].Trim());
            string wheelManufacturer = parts[4].Trim();
            float currentTirePressure = float.Parse(parts[5].Trim());
            string ownerName = parts[6].Trim();
            string ownerPhone = parts[7].Trim();
            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licenseNumber, modelName);
            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type: {0}", vehicleType);
            }

            float maxEnergy = vehicle.Engine.MaxEnergy;
            float currentEnergyAmount = (energyPercentage / 100f) * maxEnergy;
            Dictionary<string, string> vehicleData = getVehicleDataFromFile(vehicle, parts, currentEnergyAmount, wheelManufacturer, currentTirePressure);
            vehicle.SetVehicleSpecificProperties(vehicleData);

            return r_Garage.AddVehicleToGarage(vehicle, ownerName, ownerPhone);
        }

        private Dictionary<string, string> getVehicleDataFromFile(Vehicle i_Vehicle, string[] i_FileParts, float i_CurrentEnergyAmount, string i_WheelManufacturer, float i_CurrentTirePressure)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            List<string> requirements = i_Vehicle.GetVehicleSpecificDataRequirements();
            int currentIndex = 8;

            data[requirements[0]] = i_WheelManufacturer;
            data[requirements[1]] = i_CurrentTirePressure.ToString();
            data[requirements[requirements.Count - 1]] = i_CurrentEnergyAmount.ToString();
            for (int i = 2; i < requirements.Count - 1; i++)
            {
                data[requirements[i]] = i_FileParts[currentIndex++];
            }

            return data;
        }

        private void addNewVehicleToGarage()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Please Enter your license number:");
                string licenseNumber = Console.ReadLine();
                try
                {
                    r_Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                    Console.WriteLine("Your vehicle already exists in this garage, current status is: In Repair");
                    isValidInput = true;
                }
                catch
                {
                    Console.WriteLine("Please Enter your name:");
                    string ownerFullName = Console.ReadLine();
                    Console.WriteLine("Please Enter your phone number:");
                    string ownerPhoneNumber = Console.ReadLine();
                    Console.WriteLine("What is your vehicle model?");
                    string vehicleModel = Console.ReadLine();
                    Console.WriteLine("What is the type of your vehicle?");
                    int numOfChoice = 1;
                    foreach (string typeVehicle in VehicleCreator.SupportedTypes)
                    {
                        Console.WriteLine("For {0} insert: {1}", typeVehicle, numOfChoice);
                        numOfChoice++;
                    }

                    try
                    {
                        int numOfVehiclesTypes = VehicleCreator.SupportedTypes.Count;
                        numOfChoice = getValidChoiceNumber(1, numOfVehiclesTypes);
                        string vehicleType = VehicleCreator.SupportedTypes[numOfChoice - 1];
                        Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licenseNumber, vehicleModel);
                        Dictionary<string, string> vehicleDictionary = getVehicleDataFromUser(newVehicle);
                        newVehicle.SetVehicleSpecificProperties(vehicleDictionary);
                        bool isAlreadyInGarage = r_Garage.AddVehicleToGarage(newVehicle, ownerFullName, ownerPhoneNumber);
                        if (!isAlreadyInGarage)
                        {
                            Console.WriteLine("Your vehicle has been added to the garage!");
                        }
                        else
                        {
                            Console.WriteLine("Your vehicle already exists in this garage, current status is: In Repair");
                        }

                        isValidInput = true;
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (ValueRangeExceptioncs exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        private Dictionary<string, string> getVehicleDataFromUser(Vehicle i_Vehicle)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            List<string> requirements = i_Vehicle.GetVehicleSpecificDataRequirements();

            Console.WriteLine("Please enter the following vehicle information:");
            foreach (string requirement in requirements)
            {
                Console.WriteLine("Enter {0}:", requirement);
                string userInput = Console.ReadLine();
                data[requirement] = userInput;
            }

            return data;
        }

        private void displayAllLicenseNumber()
        {
            Console.WriteLine("Would you like to see a specific status of cars? choose from options below:");
            Console.WriteLine(@"For in repair vehicles: insert 1
For repaired and unpaid: insert 2
For repaired and paid: insert 3
For all vehicles: insert 4");
            int userAnswer = getValidChoiceNumber(1, 4);
            List<string> licenseNumbertoDisplay = new List<string>();
            if (userAnswer == 4)
            {
                licenseNumbertoDisplay = r_Garage.GetAllLicenseNumbers();
            }
            else
            {
                eVehicleStatus enumStatus = (eVehicleStatus)(userAnswer - 1);

                licenseNumbertoDisplay = r_Garage.GetLicenseNumbersByStatus(enumStatus);
            }

            if (licenseNumbertoDisplay.Count == 0 && userAnswer == 4)
            {
                Console.WriteLine("No vehicles in the garage at the moment!");
            }
            else if (licenseNumbertoDisplay.Count == 0)
            {
                Console.WriteLine("No vehicles with this status in the garage at the moment!");
            }
            else
            {
                Console.WriteLine("License Numbers:");
                foreach (string licenseNumber in licenseNumbertoDisplay)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private void changingVeichleStatus()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                string customerLicenceNumber = getClientLicense();
                
                Console.WriteLine("Enter your desired status to update. choose from options below:");
                Console.WriteLine(@"For in repair vehicles: insert 1
For repaired and unpaid: insert 2
For repaired and paid: insert 3");
                int userAnswer = getValidChoiceNumber(1, 3);
                eVehicleStatus newStatus = (eVehicleStatus)(userAnswer - 1);
                try
                {
                    r_Garage.ChangeVehicleStatus(customerLicenceNumber, newStatus);
                    Console.WriteLine("Status updated as your request!");
                    isValidInput = true;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void inflateVehicleWheelsToMaxAirPressure()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                string clientLicenceNumber = getClientLicense();

                try
                {
                    r_Garage.InflateWheelsToMaxCapacity(clientLicenceNumber);
                    Console.WriteLine("All wheels inflated to max pressure!");
                    isValidInput= true;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void addFuelToFuelVehicle()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                string customerLicenceNumber = getClientLicense();
                Console.WriteLine("Which type of gas do you want? choose from options below:");
                Console.WriteLine(@"For soler: insert 1
For octan95: insert 2
For octan96: insert 3
For octan98: insert 4");
                int userAnswer = getValidChoiceNumber(1, 4);
                eFuelType fuelType = (eFuelType)(userAnswer - 1);
                Console.WriteLine("How much gas do you want to fill? (in liters)");
                string amountOfFuel = Console.ReadLine();
                try
                {
                    float fuelAmount = float.Parse(amountOfFuel);
                    r_Garage.RefuelVehicle(customerLicenceNumber, fuelType, fuelAmount);
                    Console.WriteLine("Gas added successfully!");
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid fuel amount. please enter a valid number");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ValueRangeExceptioncs exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }  
        }

        private void chargeElectricVehicle()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                string customerLicenceNumber = getClientLicense();

                Console.WriteLine("Please enter number of minutes you'd like to charge:");
                string minutesToCharge = Console.ReadLine();
                try
                {
                    float minutes = float.Parse(minutesToCharge);

                    r_Garage.ChargeElectricVehicle(customerLicenceNumber, minutes / 60);
                    Console.WriteLine("Recharged successfully!");
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. please enter a valid number of minutes");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ValueRangeExceptioncs exception)
                {
                    float minValueInMinutes = exception.MinValue * 60;
                    float maxValueInMinutes = exception.MaxValue * 60;
                    Console.WriteLine("Invalid engine adding amount, Minimal value is {0}, and maximal value is {1}", minValueInMinutes, maxValueInMinutes);
                }
            }   
        }

        private void displayAllDataOfGivenVehicle()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                string customerLicenceNumber = getClientLicense();

                try
                {
                    Console.WriteLine(r_Garage.GetFullVehicleInformation(customerLicenceNumber));
                    isValidInput = true;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private string getClientLicense()
        {
            Console.WriteLine("Please enter your license number:");
            string clientLicense = Console.ReadLine();

            return clientLicense;
        }

        private static int getValidChoiceNumber(int i_LowerBoundOfChoice, int i_UpperBoundOfChoice)
        {
            int choiceNumber;
            string chosenService = Console.ReadLine();
            bool isValidNumber = int.TryParse(chosenService, out choiceNumber);

            while (!isValidNumber || choiceNumber < i_LowerBoundOfChoice || choiceNumber > i_UpperBoundOfChoice)
            {
                Console.WriteLine("Invalid choice. please enter a number between {0} and {1} from the options above", i_LowerBoundOfChoice, i_UpperBoundOfChoice);
                chosenService = Console.ReadLine();
                isValidNumber = int.TryParse(chosenService, out choiceNumber);
            }

            return choiceNumber;
        }
    }
}


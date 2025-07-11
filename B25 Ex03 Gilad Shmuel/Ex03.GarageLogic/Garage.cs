using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Client> r_ClientsByLicenseNumber;
        private readonly Dictionary<int, string> r_GarageServices;

        public Garage()
        {
            r_ClientsByLicenseNumber = new Dictionary<string, Client>();
            r_GarageServices = new Dictionary<int, string>
            {
                { 1, "Load vehicles from file" },
                { 2, "Add new vehicle to garage" },
                { 3, "Display license numbers by status" },
                { 4, "Change vehicle status" },
                { 5, "Inflate wheels to maximum pressure" },
                { 6, "Fuel a gas vehicle" },
                { 7, "Charge an electric vehicle" },
                { 8, "Display full vehicle information" },
                { 9, "Exit garage system" }
            };
        }

        public Dictionary<int, string> GarageServices
        {
            get { return r_GarageServices; }
        }

        private Client getClientByLicenseNumber(string i_LicenseNumber)
        {
            if (!r_ClientsByLicenseNumber.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No such client in our garage");
            }

            return r_ClientsByLicenseNumber[i_LicenseNumber];
        }

        private Vehicle getVehicleByLicenseNumber(string i_LicenseNumber)
        {
            return getClientByLicenseNumber(i_LicenseNumber).Vehicle;
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_ClientsByLicenseNumber.ContainsKey(i_LicenseNumber);
        }

        public bool AddVehicleToGarage(Vehicle i_VehicleToAdd, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            bool isAlreadyInGarage = true;
            string currentClientLicense = i_VehicleToAdd.LicenseNumber;

            if (r_ClientsByLicenseNumber.ContainsKey(currentClientLicense))
            {
                r_ClientsByLicenseNumber[currentClientLicense].CurrentVehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                Client newClientToAdd = new Client(i_OwnerName, i_OwnerPhoneNumber, i_VehicleToAdd);

                r_ClientsByLicenseNumber.Add(currentClientLicense, newClientToAdd);
                isAlreadyInGarage = false;
            }

            return isAlreadyInGarage;
        }

        public List<string> GetLicenseNumbersByStatus(eVehicleStatus i_Status)
        {
            Dictionary<eVehicleStatus, List<string>> dictionaryToCheck = getLicenseDictionaryByStatus();
            List<string> listByStatus = new List<string>();

            if (dictionaryToCheck.ContainsKey(i_Status))
            {
                listByStatus = dictionaryToCheck[i_Status];
            }

            return listByStatus;
        }

        private Dictionary<eVehicleStatus, List<string>> getLicenseDictionaryByStatus()
        {
            Dictionary<eVehicleStatus, List<string>> licenseDictionaryByStatus = new Dictionary<eVehicleStatus, List<string>>();

            foreach (string licenseNumber in r_ClientsByLicenseNumber.Keys)
            {
                eVehicleStatus currentStatus = r_ClientsByLicenseNumber[licenseNumber].CurrentVehicleStatus;

                if (!licenseDictionaryByStatus.ContainsKey(currentStatus))
                {
                    List<string> licenseNumbersByStatus = new List<string>();

                    licenseNumbersByStatus.Add(licenseNumber);
                    licenseDictionaryByStatus.Add(currentStatus, licenseNumbersByStatus);
                }
                else
                {
                    licenseDictionaryByStatus[currentStatus].Add(licenseNumber);
                }
            }

            return licenseDictionaryByStatus;
        }

        public List<string> GetAllLicenseNumbers()
        {
            List<string> allLicenseNumbers = new List<string>();

            foreach (string licenseNumber in r_ClientsByLicenseNumber.Keys)
            {
                allLicenseNumbers.Add(licenseNumber);
            }

            return allLicenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            Client currentClient = getClientByLicenseNumber(i_LicenseNumber);

            currentClient.CurrentVehicleStatus = i_NewStatus;
        }

        public void InflateWheelsToMaxCapacity(string i_LicenseNumber)
        {
            Vehicle currentVehicle = getVehicleByLicenseNumber(i_LicenseNumber);

            currentVehicle.InflateWheelsToMaximum();
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmount)
        {
            Vehicle currentVehicle = getVehicleByLicenseNumber(i_LicenseNumber);

            if (currentVehicle.Engine is FuelEngine)
            {
                FuelEngine vehicleFuelEngine = (FuelEngine)currentVehicle.Engine;

                vehicleFuelEngine.RefuelInLiter(i_FuelAmount, i_FuelType);
            }
            else
            {
                throw new ArgumentException("Cannot refuel a non-fuel vehicle");
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_HoursToCharge)
        {
            Vehicle currentVehicle = getVehicleByLicenseNumber(i_LicenseNumber);

            if (currentVehicle.Engine is ElectricEngine)
            {
                ElectricEngine vehicleElectricEngine = (ElectricEngine)currentVehicle.Engine;

                vehicleElectricEngine.ChargeBattery(i_HoursToCharge);
            }
            else
            {
                throw new ArgumentException("Cannot charge a non-electric vehicle");
            }
        }

        public string GetFullVehicleInformation(string i_LicenseNumber)
        {
            Client client = getClientByLicenseNumber(i_LicenseNumber);

            return client.ToString();
        }
    }
}

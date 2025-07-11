using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Client;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_ClientVehicle;
        private eVehicleStatus m_CurrentStatus;

        public Client(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_ClientVehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            r_ClientVehicle = i_ClientVehicle;
            m_CurrentStatus = eVehicleStatus.InRepair;
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public Vehicle Vehicle
        {
            get { return r_ClientVehicle; }
        }

        public eVehicleStatus CurrentVehicleStatus
        {
            get { return m_CurrentStatus; }

            set { m_CurrentStatus = value; }
        }

        public override string ToString()
        {
            return string.Format("Owner Name: {0}\nOwner Phone: {1}\nVehicle Status: {2}\n{3}", r_OwnerName, r_OwnerPhoneNumber, m_CurrentStatus, r_ClientVehicle);
        }
    }
}

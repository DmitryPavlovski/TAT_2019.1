using System;
using Task_DEV_10.InformationClassCreaters;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handles address.
    /// </summary>
    public class AddressCreater : BaseDataCreater
    {
        Address Address { get; }

        /// <summary>
        /// Constructor of HandleAddress.
        /// </summary>
        public AddressCreater()
        {
            this.Address = new Address();
        }

        /// <summary>
        /// Method creates object of address, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Address CreateAddress()
        {
            Console.WriteLine("Enter ID:");
            this.Address.ID = this.GetIntData();

            Console.WriteLine("Enter country:");
            this.Address.Country = this.GetStringData();

            Console.WriteLine("Enter city:");
            this.Address.City = this.GetStringData();

            Console.WriteLine("Enter street:");
            this.Address.Street = this.GetStringData();

            Console.WriteLine("Enter house number:");
            this.Address.HouseNumber = this.GetIntData();
            
            return this.Address;
        }
    }
}
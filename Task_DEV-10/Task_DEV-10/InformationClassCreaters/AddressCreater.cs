using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handles address.
    /// </summary>
    public class AddressCreater : BaseDataCreater
    {
        /// <summary>
        /// Method creates object of address, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Address CreateAddress(List<Address> addresses)
        {
            var address = new Address();

            Console.WriteLine("Enter ID:");
            address.ID = this.GetIntNewID(addresses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter country:");
            address.Country = this.GetStringValue();

            Console.WriteLine("Enter city:");
            address.City = this.GetStringValue();

            Console.WriteLine("Enter street:");
            address.Street = this.GetStringValue();

            Console.WriteLine("Enter house number:");
            address.HouseNumber = this.GetIntValue();

            return address;
        }
    }
}
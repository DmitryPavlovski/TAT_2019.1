using System;

namespace Task_DEV_10
{
    /// <summary>
    /// Class handles address.
    /// </summary>
    public class AddressCreater
    {
        Address Address { get; }
        bool existenceID;
        bool existenceHouseNumber;

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

            while (existenceID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int id))
                {
                    Address.ID = id;
                    existenceID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter country:");
            Address.Country = Console.ReadLine();

            Console.WriteLine("Enter city:");
            Address.City = Console.ReadLine();

            Console.WriteLine("Enter street:");
            Address.Street = Console.ReadLine();

            Console.WriteLine("Enter house number:");

            while (existenceHouseNumber == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int houseNumber))
                {
                    Address.HouseNumber = houseNumber;
                    existenceHouseNumber = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return Address;
        }
    }
}
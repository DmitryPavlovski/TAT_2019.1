using System;

namespace Task_DEV_10
{
    /// <summary>
    /// the class creates new ware house.
    /// </summary>
    public class WareHouseCreater
    {
        WareHouse WareHouse { get; }
        bool existenceID;
        bool existenceAddressID;

        /// <summary>
        /// Constructor of HandlerWareHoyse.
        /// </summary>
        public WareHouseCreater()
        {
            this.WareHouse = new WareHouse();
        }

        /// <summary>
        /// Method creates object of adware housedress, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public WareHouse CreateWareHouse()
        {
            Console.WriteLine("Enter ID:");

            while (existenceID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int id))
                {
                    WareHouse.ID = id;
                    existenceID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter name:");
            WareHouse.Name = Console.ReadLine();

            Console.WriteLine("Enter address ID:");

            while (existenceAddressID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int addressID))
                {
                    WareHouse.AddressID = addressID;
                    existenceAddressID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            return WareHouse;
        }
    }
}

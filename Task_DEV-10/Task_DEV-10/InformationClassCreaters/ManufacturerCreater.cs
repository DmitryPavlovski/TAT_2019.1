using System;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new manufacturer
    /// </summary>
    public class ManufacturerCreater
    {
        Manufacturer Manufacturer { get; }
        bool existenceID;
        bool existenceRegistrasionAddressID;

        /// <summary>
        /// Constructor of HandlerManufacturer.
        /// </summary>
        public ManufacturerCreater()
        {
            this.Manufacturer = new Manufacturer();
        }

        /// <summary>
        /// Method creates object of manufacturer, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Manufacturer CreateManufacturer()
        {
            Console.WriteLine("Enter ID:");

            while (existenceID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int id))
                {
                    Manufacturer.ID = id;
                    existenceID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter name:");
            Manufacturer.Name = Console.ReadLine();

            Console.WriteLine("Enter registrasion address ID:");

            while (existenceRegistrasionAddressID == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out int registrasionAddressID))
                {
                    Manufacturer.RegistrasionAddressID = registrasionAddressID;
                    existenceRegistrasionAddressID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");
                }
            }

            Console.WriteLine("Enter country:");
            Manufacturer.Country = Console.ReadLine();

            return Manufacturer;
        }
    }
}
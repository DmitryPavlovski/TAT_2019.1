using System;
using Task_DEV_10.InformationClassCreaters;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new manufacturer
    /// </summary>
    public class ManufacturerCreater : BaseDataCreater
    {
        Manufacturer Manufacturer { get; }

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
            this.Manufacturer.ID = this.GetIntData();

            Console.WriteLine("Enter name:");
            this.Manufacturer.Name = this.GetStringData();

            Console.WriteLine("Enter registrasion address ID:");
            this.Manufacturer.RegistrasionAddressID = this.GetIntData();

            Console.WriteLine("Enter country:");
            this.Manufacturer.Country = this.GetStringData();

            return this.Manufacturer;
        }
    }
}
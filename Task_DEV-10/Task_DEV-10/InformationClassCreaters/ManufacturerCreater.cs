using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new manufacturer
    /// </summary>
    public class ManufacturerCreater : BaseDataCreater
    {
        /// <summary>
        /// Method creates object of manufacturer, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Manufacturer CreateManufacturer(List<Manufacturer> manufacturers)
        {
            var manufacturer = new Manufacturer();

            Console.WriteLine("Enter ID:");
            manufacturer.ID = this.GetIntNewID(manufacturers.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            manufacturer.Name = this.GetStringValue();

            Console.WriteLine("Enter registrasion address ID:");
            manufacturer.RegistrasionAddressID = this.GetIntValue();

            Console.WriteLine("Enter country:");
            manufacturer.Country = this.GetStringValue();

            return manufacturer;
        }
    }
}
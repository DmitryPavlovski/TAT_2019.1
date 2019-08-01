using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// the class creates new ware house.
    /// </summary>
    public class WareHouseCreater : BaseDataCreater
    {
        /// <summary>
        /// Method creates object of adware housedress, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public WareHouse CreateWareHouse(List<WareHouse> wareHouses)
        {
            var wareHouse = new WareHouse();

            Console.WriteLine("Enter ID:");
            wareHouse.ID = this.GetIntNewID(wareHouses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            wareHouse.Name = this.GetStringValue();

            Console.WriteLine("Enter address ID:");
            wareHouse.AddressID = this.GetIntValue();

            return wareHouse;
        }
    }
}

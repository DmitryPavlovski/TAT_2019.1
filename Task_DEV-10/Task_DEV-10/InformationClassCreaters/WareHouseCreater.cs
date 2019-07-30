using System;
using Task_DEV_10.InformationClassCreaters;

namespace Task_DEV_10
{
    /// <summary>
    /// the class creates new ware house.
    /// </summary>
    public class WareHouseCreater : BaseDataCreater
    {
        WareHouse WareHouse { get; }

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
            this.WareHouse.ID = this.GetIntData();
           
            Console.WriteLine("Enter name:");
            this.WareHouse.Name = this.GetStringData();

            Console.WriteLine("Enter address ID:");
            this.WareHouse.AddressID = this.GetIntData();           

            return this.WareHouse;
        }
    }
}

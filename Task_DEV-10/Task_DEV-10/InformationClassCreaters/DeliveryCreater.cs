using System;
using Task_DEV_10.InformationClassCreaters;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new delivery.
    /// </summary>
    public class DeliveryCreater : BaseDataCreater
    {
        Delivery Delivery { get; }

        public DeliveryCreater()
        {
            this.Delivery = new Delivery();
        }

        /// <summary>
        /// Method creates object of delivery, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Delivery CreateDelivery()
        {
                Console.WriteLine("Enter ID:");
                this.Delivery.ID = this.GetIntData();

                Console.WriteLine("Enter house Description:");
                this.Delivery.Description = this.GetStringData();                

                Console.WriteLine("Enter delivery date:");
                this.Delivery.DeliveryDate = this.GetStringData();             

            return this.Delivery;
        }
    }
}

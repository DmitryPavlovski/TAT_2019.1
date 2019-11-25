using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new delivery.
    /// </summary>
    public class DeliveryCreater : BaseDataCreater
    {
        /// <summary>
        /// Method creates object of delivery, fill his and return.
        /// </summary>
        /// <returns>Object of address</returns>
        public Delivery CreateDelivery(List<Delivery> deliveries)
        {
            var delivery = new Delivery();

            Console.WriteLine("Enter delivery ID:");
            delivery.ID = this.GetIntNewID(deliveries.Select(t => t.ID).ToList());

            Console.WriteLine("Enter house Description:");
            delivery.Description = this.GetStringValue();

            Console.WriteLine("Enter delivery date:");
            delivery.DeliveryDate = this.GetStringValue();

            return delivery;
        }
    }
}

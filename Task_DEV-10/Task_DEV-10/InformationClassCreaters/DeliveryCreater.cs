using System;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new delivery.
    /// </summary>
    public class DeliveryCreater
    {
        Delivery Delivery { get; }
        bool existenceID;
        bool existenceDescription;
        bool existenceDeliveryDate;

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
            string request;

            while (true)
            {
                Console.WriteLine("Enter ID:");

                if (Int32.TryParse(Console.ReadLine(), out int id) && existenceID == false)
                {
                    Delivery.ID = id;
                    existenceID = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");

                    continue;
                }

                Console.WriteLine("Enter house Description:");
                request = Console.ReadLine();

                if (request != string.Empty && existenceDescription == false)
                {
                    Delivery.Description = request;
                    existenceDescription = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");

                    continue;
                }

                Console.WriteLine("Enter delivery date:");
                request = Console.ReadLine();

                if (request != string.Empty && existenceDeliveryDate == false)
                {
                    Delivery.DeliveryDate = request;
                    existenceDeliveryDate = true;
                }
                else
                {
                    Console.WriteLine("Try again! Incorrect value");

                    continue;
                }

                break;
            }

            return Delivery;
        }
    }
}

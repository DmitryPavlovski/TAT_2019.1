using System;

namespace Task_DEV_10
{
    /// <summary>
    /// The class finds id.
    /// </summary>
    public class FinderID
    {
        Shop Shop { get; }

        /// <summary>
        /// Constructor of FinderID.
        /// </summary>
        /// <param name="shop"></param>
        public FinderID(Shop shop)
        {
            this.Shop = shop;
        }

        /// <summary>
        /// Method finds id of product.
        /// </summary>
        /// <returns></returns>
        public int FindProductID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var product in Shop.products)
                {
                    if (request == product.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Method finds id of address.
        /// </summary>
        /// <returns></returns>
        public int FindAddressID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var address in Shop.addresses)
                {
                    if (request == address.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Method finds id of delivery.
        /// </summary>
        /// <returns></returns>
        public int FindDeliveryID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var delivery in Shop.deliveries)
                {
                    if (request == delivery.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Method finds id of manufacturer.
        /// </summary>
        /// <returns></returns>
        public int FindManufacturerID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var manufacturer in Shop.manufacturers)
                {
                    if (request == manufacturer.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Method finds id of warehouse.
        /// </summary>
        /// <returns></returns>
        public int FindWareHouseID()
        {
            bool existenceID = false;
            int request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                Int32.TryParse(Console.ReadLine(), out request);

                foreach (var wareHouse in Shop.wareHouses)
                {
                    if (request == wareHouse.ID)
                    {
                        existenceID = true;

                        break;
                    }
                }
            }

            return request;
        }
    }
}

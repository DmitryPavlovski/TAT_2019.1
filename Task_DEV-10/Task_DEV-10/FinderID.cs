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
            var existenceID = false;
            var request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);

                foreach (var product in this.Shop.products)
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
            var existenceID = false;
            var request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);

                foreach (var address in this.Shop.addresses)
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
            var existenceID = false;
            var request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);

                foreach (var delivery in this.Shop.deliveries)
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
            var existenceID = false;
            var request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);

                foreach (var manufacturer in this.Shop.manufacturers)
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
            var existenceID = false;
            var request = 0;

            while (existenceID == false)
            {
                Console.WriteLine("Enter existing ID:");
                int.TryParse(Console.ReadLine(), out request);

                foreach (var wareHouse in this.Shop.wareHouses)
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

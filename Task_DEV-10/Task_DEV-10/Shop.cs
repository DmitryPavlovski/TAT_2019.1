using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task_DEV_10
{
    /// <summary>
    /// Class manages products.
    /// </summary>
    public class Shop
    {
        public List<Product> products;
        public List<Delivery> deliveries;
        public List<Address> addresses;
        public List<Manufacturer> manufacturers;
        public List<WareHouse> wareHouses;

        /// <summary>
        /// Constructor of Shop.
        /// </summary>
        public Shop()
        {
            this.products = new List<Product>();
            this.deliveries = new List<Delivery>();
            this.addresses = new List<Address>();
            this.manufacturers = new List<Manufacturer>();
            this.wareHouses = new List<WareHouse>();
        }

        /// <summary>
        /// Method adds new element of T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="t"></param>
        public void AddNewElement<T>(List<T> list, T t)
        {
            list.Add(t);
        }

        /// <summary>
        /// Method deletes element of T type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listID"></param>
        /// <param name="list"></param>
        /// <param name="id"></param>
        public void DeleteElement<T>(List<int> listID, List<T> list, int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(listID[i] == id)
                {
                    list.Remove(list[i]);

                    return;
                }
            }
        }

        /// <summary>
        /// Method displays products to console.
        /// </summary>
        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {product.ID}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Number: {product.Number}");
                Console.WriteLine($"Manufacturer ID: {product.ManufacturerID}");
                Console.WriteLine($"Ware House ID: {product.WareHouseID}");
                Console.WriteLine($"Delivery ID: {product.DeliveryID}");
                Console.WriteLine($"Address ID: {product.AddressID}");
                Console.WriteLine($"Manufacture Date: {product.ManufactureDate}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method displays addresses to console.
        /// </summary>
        public void DisplaAddresses()
        {
            foreach (var address in addresses)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {address.ID}");
                Console.WriteLine($"Country: {address.Country}");
                Console.WriteLine($"City: {address.City}");
                Console.WriteLine($"Street: {address.Street}");
                Console.WriteLine($"House Number: {address.HouseNumber}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method displays deliveries to console.
        /// </summary>
        public void DisplayDeliveries()
        {
            foreach (var delivery in deliveries)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {delivery.ID}");
                Console.WriteLine($"Description: {delivery.Description}");
                Console.WriteLine($"Delivery Date: {delivery.DeliveryDate}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method displays manufacturers to console.
        /// </summary>
        public void DisplayManufacturers()
        {
            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {manufacturer.ID}");
                Console.WriteLine($"Name: {manufacturer.Name}");
                Console.WriteLine($"Registrasion Address ID: {manufacturer.RegistrasionAddressID}");
                Console.WriteLine($"Country: {manufacturer.Country}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method displays ware houses to console.
        /// </summary>
        public void DisplayWareHouses()
        {
            foreach (var wareHouse in wareHouses)
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"ID: {wareHouse.ID}");
                Console.WriteLine($"Name: {wareHouse.Name}");
                Console.WriteLine($"Address ID: {wareHouse.AddressID}");
            }
            Console.WriteLine("________________________");
        }

        /// <summary>
        /// Method checks that this id use in some product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckOnUsingtoProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.AddressID == id)
                {
                    Console.WriteLine("Sorry, this address using for product! Before delete this product!");

                    return true;
                }
            }

            return false;
        }
    }
}
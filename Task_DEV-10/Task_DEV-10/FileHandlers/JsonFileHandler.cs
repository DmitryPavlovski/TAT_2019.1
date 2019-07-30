using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task_DEV_10
{
    /// <summary>
    /// The class handles json files.
    /// </summary>
    public class JsonFileHandler
    {
        string ProductsPath { get; } = "../../InformationJSON/products.json";
        string AddressesPath { get; } = "../../InformationJSON/addresses.json";
        string DeliveriesPath { get; } = "../../InformationJSON/deliveries.json";
        string ManufacturersPath { get; } = "../../InformationJSON/manufacturers.json";
        string WareHousePath { get; } = "../../InformationJSON/warehouses.json";

        /// <summary>
        /// Method reads json files and write to lists of shop.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public void ReadAndWriteFromJson(object obj, ObjectEventArgs args)
        {
            if (obj is RequestHandler)
            {
                DataContractJsonSerializer jsonFormatter;

                using (var fileStream = new FileStream(this.ProductsPath, FileMode.OpenOrCreate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                    args.Shop.products = (List<Product>)jsonFormatter.ReadObject(fileStream);
                }

                using (var fileStream = new FileStream(this.AddressesPath, FileMode.OpenOrCreate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                    args.Shop.addresses = (List<Address>)jsonFormatter.ReadObject(fileStream);
                }

                using (var fileStream = new FileStream(this.DeliveriesPath, FileMode.OpenOrCreate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                    args.Shop.deliveries = (List<Delivery>)jsonFormatter.ReadObject(fileStream);
                }

                using (var fileStream = new FileStream(this.ManufacturersPath, FileMode.OpenOrCreate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                    args.Shop.manufacturers = (List<Manufacturer>)jsonFormatter.ReadObject(fileStream);
                }

                using (var fileStream = new FileStream(this.WareHousePath, FileMode.OpenOrCreate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                    args.Shop.wareHouses = (List<WareHouse>)jsonFormatter.ReadObject(fileStream);
                }
            }
        }

        /// <summary>
        /// Method writes to json file updating data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="t"></param>
        public void UpdateJsonFile(object obj, ObjectEventArgs args)
        {
            if (obj is ICommand)
            {
                DataContractJsonSerializer jsonFormatter;

                using (var fileStream = new FileStream(this.ProductsPath, FileMode.Truncate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                    jsonFormatter.WriteObject(fileStream, args.Shop.products);
                }

                using (var fileStream = new FileStream(this.AddressesPath, FileMode.Truncate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                    jsonFormatter.WriteObject(fileStream, args.Shop.addresses);
                }

                using (var fileStream = new FileStream(this.DeliveriesPath, FileMode.Truncate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                    jsonFormatter.WriteObject(fileStream, args.Shop.deliveries);
                }

                using (var fileStream = new FileStream(this.ManufacturersPath, FileMode.Truncate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                    jsonFormatter.WriteObject(fileStream, args.Shop.manufacturers);
                }

                using (var fileStream = new FileStream(this.WareHousePath, FileMode.Truncate))
                {
                    jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                    jsonFormatter.WriteObject(fileStream, args.Shop.wareHouses);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Task_DEV_10
{
    /// <summary>
    /// The class handles json files.
    /// </summary>
    public class JsonFileHandler
    {
        Shop Shop { get; }
        string ProductsPath { get; } = "../../InformationJSON/products.json";
        string AddressesPath { get; } = "../../InformationJSON/addresses.json";
        string DeliveriesPath { get; } = "../../InformationJSON/deliveries.json";
        string ManufacturersPath { get; } = "../../InformationJSON/manufacturers.json";
        string WareHousePath { get; } = "../../InformationJSON/warehouses.json";

        public JsonFileHandler(Shop shop)
        {
            this.Shop = shop;
        }

        /// <summary>
        /// Method reads json files and write to lists of shop.
        /// </summary>
        /// <param name="requestHandler"></param>
        public void ReadAndWriteFromJson(RequestHandler requestHandler)
        {
            if(requestHandler == null)
            {
                throw new ArgumentNullException(nameof(requestHandler));
            }

            DataContractJsonSerializer jsonFormatter;

            using(var fileStream = new FileStream(this.ProductsPath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                this.Shop.products = (List<Product>)jsonFormatter.ReadObject(fileStream);
            }

            using(var fileStream = new FileStream(this.AddressesPath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                this.Shop.addresses = (List<Address>)jsonFormatter.ReadObject(fileStream);
            }

            using(var fileStream = new FileStream(this.DeliveriesPath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                this.Shop.deliveries = (List<Delivery>)jsonFormatter.ReadObject(fileStream);
            }

            using(var fileStream = new FileStream(this.ManufacturersPath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                this.Shop.manufacturers = (List<Manufacturer>)jsonFormatter.ReadObject(fileStream);
            }

            using(var fileStream = new FileStream(this.WareHousePath, FileMode.OpenOrCreate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                this.Shop.wareHouses = (List<WareHouse>)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Method writes to json file updating data.
        /// </summary>
        /// <param name="command"></param>
        public void UpdateJsonFile(ICommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            DataContractJsonSerializer jsonFormatter;

            using(var fileStream = new FileStream(this.ProductsPath, FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));
                jsonFormatter.WriteObject(fileStream, this.Shop.products);
            }

            using(var fileStream = new FileStream(this.AddressesPath, FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
                jsonFormatter.WriteObject(fileStream, this.Shop.addresses);
            }

            using(var fileStream = new FileStream(this.DeliveriesPath, FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Delivery>));
                jsonFormatter.WriteObject(fileStream, this.Shop.deliveries);
            }

            using(var fileStream = new FileStream(this.ManufacturersPath, FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Manufacturer>));
                jsonFormatter.WriteObject(fileStream, this.Shop.manufacturers);
            }

            using(var fileStream = new FileStream(this.WareHousePath, FileMode.Truncate))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<WareHouse>));
                jsonFormatter.WriteObject(fileStream, this.Shop.wareHouses);
            }
        }
    }
}
using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new product.
    /// </summary>
    public class ProductCreater : BaseDataCreater
    {
        /// <summary>
        /// Method creates object of product, fill his and return.
        /// Check that new product has existing delivery, manufacturer, address, warehouse.
        /// </summary>
        /// <returns>Object of address</returns>
        public Product CreateProduct(Shop shop)
        {
            var product = new Product();

            Console.WriteLine("Enter ID:");
            product.ID = this.GetIntNewID(shop.products.Select(t => t.ID).ToList());

            Console.WriteLine("Enter name:");
            product.Name = this.GetStringValue();

            Console.WriteLine("Enter number:");
            product.Number = this.GetIntValue();

            Console.WriteLine("Enter manufacturer date:");
            product.ManufactureDate = this.GetStringValue();

            Console.WriteLine("Enter existing address ID:");
            product.AddressID = this.GetIntExistingID(shop.addresses.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing delivery ID:");
            product.DeliveryID = this.GetIntExistingID(shop.deliveries.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing manufacturer ID:");
            product.ManufacturerID = this.GetIntExistingID(shop.manufacturers.Select(t => t.ID).ToList());

            Console.WriteLine("Enter existing ware house ID:");
            product.WareHouseID = this.GetIntExistingID(shop.wareHouses.Select(t => t.ID).ToList());

            return product;
        }
    }
}
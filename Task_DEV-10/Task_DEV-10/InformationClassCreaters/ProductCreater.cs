using System;
using System.Linq;
using Task_DEV_10.InformationClassCreaters;

namespace Task_DEV_10
{
    /// <summary>
    /// The class creates new product.
    /// </summary>
    public class ProductCreater : BaseDataCreater
    {
        Product Product { get; }

        /// <summary>
        /// Constructor of HandlerProduct.
        /// </summary>
        public ProductCreater()
        {
            this.Product = new Product();
        }

        /// <summary>
        /// Method creates object of product, fill his and return.
        /// Check that new product has existing delivery, manufacturer, address, warehouse.
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>Object of address</returns>
        public Product CreateProduct(Shop shop)
        {
            Console.WriteLine("Enter ID:");
            this.Product.ID = this.GetIntData();            

            Console.WriteLine("Enter name:");
            this.Product.Name = this.GetStringData();

            Console.WriteLine("Enter number:");
            this.Product.Number = this.GetIntData();            

            Console.WriteLine("Enter manufacturer date:");
            this.Product.ManufactureDate = this.GetStringData();

            Console.WriteLine("Enter existing address ID:");
            this.Product.AddressID = this.GetIntExistingID(shop.addresses.Select(t => t.ID).ToList());
            
            Console.WriteLine("Enter existing delivery ID:");
            this.Product.DeliveryID = this.GetIntExistingID(shop.deliveries.Select(t => t.ID).ToList());          

            Console.WriteLine("Enter existing manufacturer ID:");
            this.Product.ManufacturerID = this.GetIntExistingID(shop.manufacturers.Select(t => t.ID).ToList());            

            Console.WriteLine("Enter existing ware house ID:");
            this.Product.WareHouseID = this.GetIntExistingID(shop.wareHouses.Select(t => t.ID).ToList());           

            return this.Product;
        }
    }
}
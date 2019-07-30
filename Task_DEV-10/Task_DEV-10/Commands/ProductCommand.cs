using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ProductCommand : ICommand
    {
        Shop Shop { get; }
        ProductCreater ProductCreater { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/products.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of ProductCommand.
        /// </summary>
        public ProductCommand(Shop shop)
        {
            this.Shop = shop;
            this.ProductCreater = new ProductCreater();
            this.FinderID = new FinderID(this.Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML() => this.XMLFileHandler.WriteToXML(this.PathXML, this.Shop.products);

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            this.Shop.AddNewElement(this.Shop.products, this.ProductCreater.CreateProduct(this.Shop));
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var listID = new List<int>();

            foreach (var product in this.Shop.products)
            {
                listID.Add(product.ID);
            }
            this.Shop.DeleteElement(listID, this.Shop.products, this.FinderID.FindProductID());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayProducts();
    }
}

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
            this.FinderID = new FinderID(Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.products);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewElement(Shop.products, ProductCreater.CreateProduct(Shop));
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            List<int> listID = new List<int>();

            foreach (var product in Shop.products)
            {
                listID.Add(product.ID);
            }
            Shop.DeleteElement(listID, Shop.products, FinderID.FindProductID());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayProducts();
        }
    }
}

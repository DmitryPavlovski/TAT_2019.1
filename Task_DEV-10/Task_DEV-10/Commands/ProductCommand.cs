using System;
using System.Linq;

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
        public event Action<ICommand> UpdateData;

        /// <summary>
        /// Constructor of ProductCommand.
        /// </summary>
        public ProductCommand(Shop shop)
        {
            this.Shop = shop;
            this.ProductCreater = new ProductCreater();
            this.FinderID = new FinderID();
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
            var product = this.ProductCreater.CreateProduct(this.Shop);
            this.Shop.AddNewElement(this.Shop.products, product);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var id = this.FinderID.Find(this.Shop.products.Select(t => t.ID).ToList());
            var product = this.Shop.products.Where(t => t.ID == id).First();
            this.Shop.DeleteElement(this.Shop.products, product);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayAllInformation(this.Shop.products);
    }
}

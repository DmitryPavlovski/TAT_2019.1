using System;
using System.Linq;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ManufacturerCommand : ICommand
    {
        public event Action<ICommand> UpdateData;
        Shop Shop { get; }
        ManufacturerCreater HandlerManufacturer { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/manufacturers.xml";

        /// <summary>
        /// Constructor of ManufacturerCommand.
        /// </summary>
        public ManufacturerCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerManufacturer = new ManufacturerCreater();
            this.FinderID = new FinderID();
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML() => this.XMLFileHandler.WriteToXML(this.PathXML, this.Shop.manufacturers);

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            var manufacturer = this.HandlerManufacturer.CreateManufacturer(this.Shop.manufacturers);
            this.Shop.AddNewElement(this.Shop.manufacturers, manufacturer);
            UpdateData?.Invoke(this);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var id = this.FinderID.Find(this.Shop.manufacturers.Select(t => t.ID).ToList());

            if(this.Shop.products.Where(t => t.ManufacturerID == id).Count() == 0)
            {
                var manufacturer = this.Shop.manufacturers.Where(t => t.ID == id).First();
                this.Shop.DeleteElement(this.Shop.manufacturers, manufacturer);
                UpdateData?.Invoke(this);
            }
            else
            {
                Console.WriteLine("Sorry, this id using in products, before delete product!");
            }
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayAllInformation(this.Shop.manufacturers);
    }
}

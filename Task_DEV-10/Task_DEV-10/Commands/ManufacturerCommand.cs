using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class ManufacturerCommand : ICommand
    {
        Shop Shop { get; }
        ManufacturerCreater HandlerManufacturer { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/manufacturers.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of ManufacturerCommand.
        /// </summary>
        public ManufacturerCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerManufacturer = new ManufacturerCreater();
            this.FinderID = new FinderID(this.Shop);
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
            this.Shop.AddNewElement(this.Shop.manufacturers, this.HandlerManufacturer.CreateManufacturer());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var listID = new List<int>();

            foreach (var manufacturer in this.Shop.manufacturers)
            {
                listID.Add(manufacturer.ID);
            }
            this.Shop.DeleteElement(listID, this.Shop.manufacturers, this.FinderID.FindManufacturerID());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayManufacturers();
    }
}

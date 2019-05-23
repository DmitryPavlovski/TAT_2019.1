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
            this.FinderID = new FinderID(Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.manufacturers);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewElement(Shop.manufacturers, HandlerManufacturer.CreateManufacturer());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            List<int> listID = new List<int>();

            foreach (var manufacturer in Shop.manufacturers)
            {
                listID.Add(manufacturer.ID);
            }
            Shop.DeleteElement(listID, Shop.manufacturers, FinderID.FindManufacturerID());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayManufacturers();
        }
    }
}

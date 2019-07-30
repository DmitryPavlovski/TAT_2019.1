using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    public class DeliveryCommand : ICommand
    {
        Shop Shop { get; }
        DeliveryCreater HandlerDelivery { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/deliveries.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of DeliveryCommand.
        /// </summary>
        public DeliveryCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerDelivery = new DeliveryCreater();
            this.FinderID = new FinderID(this.Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML() => this.XMLFileHandler.WriteToXML(this.PathXML, this.Shop.deliveries);

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            this.Shop.AddNewElement(this.Shop.deliveries, this.HandlerDelivery.CreateDelivery());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            var listID = new List<int>();

            foreach (var delivery in this.Shop.deliveries)
            {
                listID.Add(delivery.ID);
            }
            this.Shop.DeleteElement(listID, this.Shop.deliveries, this.FinderID.FindDeliveryID());
            UpdateData?.Invoke(this, new ObjectEventArgs(this.Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements() => this.Shop.DisplayDeliveries();
    }
}

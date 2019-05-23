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
            this.FinderID = new FinderID(Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.deliveries);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewElement(Shop.deliveries, HandlerDelivery.CreateDelivery());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            List<int> listID = new List<int>();

            foreach (var delivery in Shop.deliveries)
            {
                listID.Add(delivery.ID);
            }
            Shop.DeleteElement(listID, Shop.deliveries, FinderID.FindDeliveryID());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayDeliveries();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Task_DEV_10
{
    /// <summary>
    /// The class for pattern command.
    /// </summary>
    class WareHouseCommand : ICommand
    {
        Shop Shop { get; }
        WareHouseCreater HandlerWareHouse { get; }
        FinderID FinderID { get; }
        XMLFileHandler XMLFileHandler { get; }
        string PathXML { get; } = "../../InformationXML/warehouses.xml";
        public event EventHandler<ObjectEventArgs> UpdateData;

        /// <summary>
        /// Constructor of WareHouseCommand.
        /// </summary>
        /// <param name="shop"></param>
        public WareHouseCommand(Shop shop)
        {
            this.Shop = shop;
            this.HandlerWareHouse = new WareHouseCreater();
            this.FinderID = new FinderID(Shop);
            this.XMLFileHandler = new XMLFileHandler();
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void WriteToXML()
        {
            XMLFileHandler.WriteToXML(PathXML, Shop.wareHouses);
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void AddNewElement()
        {
            Shop.AddNewElement(Shop.wareHouses, HandlerWareHouse.CreateWareHouse());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DeleteElement()
        {
            List<int> listID = new List<int>();

            foreach (var wareHouse in Shop.wareHouses)
            {
                listID.Add(wareHouse.ID);
            }
            Shop.DeleteElement(listID, Shop.wareHouses, FinderID.FindWareHouseID());
            UpdateData?.Invoke(this, new ObjectEventArgs(Shop));
        }

        /// <summary>
        /// Implemented method.
        /// </summary>
        public void DisplayElements()
        {
            Shop.DisplayWareHouses();
        }
    }
}
